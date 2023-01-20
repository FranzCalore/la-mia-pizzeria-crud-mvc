using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace la_mia_pizzeria.Models
{
    public class Ingrediente
    {
        [Key]
        public int IngredienteId { get; set; }

        public string Condimento { get; set; }

        public List<Pizza>? PizzeCondite {get;set;}

        public Ingrediente() { }
    }
}
