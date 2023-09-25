using System.ComponentModel.DataAnnotations;

namespace LearningCenter.API.Learning.Resources;

public class SaveServiceResource
{
    [Required(ErrorMessage = "El precio del servicio es obligatorio.")]
    public int Price { get; set; }

    [Required(ErrorMessage = "La descripción del servicio es obligatoria.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "La ubicación del servicio es obligatoria.")]
    public string Location { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    public int Phone { get; set; }

    [Required(ErrorMessage = "El DNI es obligatorio.")]
    public int Dni { get; set; }

    [Required(ErrorMessage = "Especificar que eres cuidador es obligatorio.")]
    public bool Cuidador { get; set; }

    [Required(ErrorMessage = "La identificación del usuario es obligatoria.")]
    public int UserId { get; set; }
}