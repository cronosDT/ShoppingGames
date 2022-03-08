using System.ComponentModel.DataAnnotations;

namespace ShoppingGames.Models
{
    public class StatesViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Departamento/eEstado")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        public int CountryId { get; set; } 
    }
}
