using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria.Models
{
    public class Categoria
    {
        [Key]
        public string Nome { get; set; }

        public List<Pizza>? ListaProdotti { get; set; }

        public Categoria() 
        { 

        }
    }
}
