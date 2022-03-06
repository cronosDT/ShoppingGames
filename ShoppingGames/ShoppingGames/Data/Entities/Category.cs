using System.ComponentModel.DataAnnotations;

namespace ShoppingGames.Data.Entities
{
    public class Category
    {
        public int Id{ get; set; }
        
        [Display(Name = "Categoria" )]
        [MaxLength(50, ErrorMessage = "El campo {0} Debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio. ")]
        public string Name { get; set; }    
    }
}
