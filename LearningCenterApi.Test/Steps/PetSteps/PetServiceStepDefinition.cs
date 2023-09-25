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

namespace LearningCenterApi.Test.Steps.PetSteps;

[Binding]
public sealed class PetServiceStepDefinition : WebApplicationFactory<Program>
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly WebApplicationFactory<Program> _factory;


    public PetServiceStepDefinition(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    private HttpClient Client { get; set; }
    private Uri BaseUri { get; set; }

    private Task<HttpResponseMessage> Response { get; set; }


    [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/pet is 
available")]
    public void GivenTheEndpointHttpsLocalhostApiVPetIsAvailable(int port,
        int version)
    {
        BaseUri = new Uri($"https://localhost:{port}/api/v{version}/tutorials");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = BaseUri
        });
    }

    [When(@"a Put Request is sent")]
    public void WhenAPutRequestIsSent(Table savePetResource)
    {
        var resource =
            savePetResource.CreateSet<SavePetResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8,
            MediaTypeNames.Application.Json);
        Response = Client.PutAsync(BaseUri, content);

    }
    
    [Then(@"A Response is received with Status (.*)")]
    public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
    {
        var expectedStatusCode = 
            ((HttpStatusCode)expectedStatus).ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
 
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }

    
    [Then(@"a Tutorial Resource is included in Response Body")]
    public async Task ThenATutorialResourceIsIncludedInResponseBody(Table 
        expectedTutorialResource)
    {
        var expectedResource = 
            expectedTutorialResource.CreateSet<PetResource>().First();
        var responseData = await 
            Response.Result.Content.ReadAsStringAsync();
        var resource = 
            JsonConvert.DeserializeObject<PetResource>(responseData);
        Assert.Equal(expectedResource.Name, resource.Name);
        Assert.Equal(expectedResource.Description, resource.Description);
        Assert.Equal(expectedResource.Castrado, resource.Castrado);
    }
    
    [Given(@"A Pet has not been stored in the database")]
    public async void GivenAPethasnotbeenstoredinthedatabase(Table 
        petResource)
    {
        var resource = 
            petResource.CreateSet<PetResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, 
            MediaTypeNames.Application.Json);
        Response = Client.PutAsync(BaseUri, content);
        var responseData = await 
            Response.Result.Content.ReadAsStringAsync();
        var responseResource = 
            JsonConvert.DeserializeObject<PetResource>(responseData);
        Assert.NotEqual(resource.Id, responseResource.Id);
    }
    
    [Then(@"An Error Message is returned with value ""(.*)""")]
    public void ThenAnErrorMessageIsReturnedWithValue(string 
        expectedMessage)
    {
        var message = Response.Result.Content.ReadAsStringAsync().Result;
        Assert.Equal(expectedMessage, message);
    }



}