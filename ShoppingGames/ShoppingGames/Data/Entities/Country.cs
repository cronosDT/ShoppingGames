using System.ComponentModel.DataAnnotations;

namespace ShoppingGames.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }

        //Form to create DataAnnotations, Restrictions or rules to our vars
        // using System.ComponentModel.DataAnnotations 

        [Display(Name = "Pais")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        // {0} This gonna replace for the country, Camp "Name"
        //{1} Replace for the camp en the restriccion, in this case for the name 50
        public string Name { get; set; }

    }
}
