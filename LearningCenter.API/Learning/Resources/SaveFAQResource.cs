using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.Learning.Resources;

[SwaggerSchema(Required = new []{"Question", "Answer"})]
public class SaveFAQResource
{
    [SwaggerSchema("Pregunta")]
    [Required(ErrorMessage = "La pregunta es obligatoria.")]
    public string Question { get; set; }

    [SwaggerSchema("Respuesta")]
    [Required(ErrorMessage = "La respuesta es obligatoria.")]
    public string Answer { get; set; }
}