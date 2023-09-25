using System.Net;
using System.Net.Mime;
using System.Text;
using LearningCenter.API.Learning.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace LearningCenterApi.Test.Steps.PaymentSteps;

[Binding]
public class PaymentServiceStepDefinition : WebApplicationFactory<Program>
{
    private readonly WebApplicationFactory<Program> _factory;

    public PaymentServiceStepDefinition(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    private HttpClient Client { get; set; }
    private Uri BaseUri { get; set; }
    private Task<HttpResponseMessage> Response { get; set; }

    [Given(@$"the Endpoint https://localhost:(.*)/api/v(.*)/payment is available")]
    public void GivenTheEnpointHttpsLocahostApiVPaymentIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"https://localhost:{port}/api/v{version}/payment");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = BaseUri
        });
    }

    [When(@"a post Request is sent")]
    public void WhenAPostRequestIsSent(Table savePaymentResource)
    {
        var resource = savePaymentResource.CreateSet<savePaymentResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
    }

    [Then(@"A Response is received with Status (.*)")]
    public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
    {
        var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();

        Assert.Equal(expectedStatusCode, actualStatusCode);
    }

    [Then(@"a Payment Resource is included in Response Body")]
    public async Task ThenAPetResourceIsIncludedInResponseBody(Table expectedPaymentResource)
    {
        var expectedResource = expectedPaymentResource.CreateSet<PaymentResource>().First();
        var responseData = await
            Response.Result.Content.ReadAsStringAsync();
        var resource = JsonConvert.DeserializeObject<PaymentResource>(responseData);
        Assert.Equal(expectedResource.Id, resource.Id);
    }
    
    [Then(@"An Error Message is returned with value ""(.*)""")]
    public void ThenAnErrorMessageIsReturnedWithValue(string 
        expectedMessage)
    {
        var message = Response.Result.Content.ReadAsStringAsync().Result;
        Assert.Equal(expectedMessage, message);
    }

    
}