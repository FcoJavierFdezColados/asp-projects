using System.ComponentModel.DataAnnotations;

namespace PruebasMVC.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [Display(Name="Nombre del Curso")]
        public required string Nombre { get; set; }
    }
}
