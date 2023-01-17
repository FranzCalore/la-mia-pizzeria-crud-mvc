using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria.Models
{
    public class CategoriaPizzaView
    {
        public Pizza Pizza { get; set; }

        public List<Categoria>? Categorie { get; set; }
    }
}
