using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }

        [Required]       
        public string Nome { get; set; }
        [Required]
        public string Descrizione { get; set; }

        [Required]
        [Range(1,100)]
        public double Prezzo { get; set; }

        [Required]
        public string Immagine { get; set; }

        public Categoria? Categoria { get; set; }

        [ForeignKey("Categoria")]
        public string CategoriaNome { get; set; }

        public List<Ingrediente>? Ingredienti { get; set; }

        public Pizza()
        {

        }

        public Pizza (string nome, string descrizione, double prezzo, string immagine)
        {
            this.Nome = nome;
            this.Descrizione = descrizione;
            this.Prezzo = prezzo;
            this.Immagine = immagine;
        }
    }
}
