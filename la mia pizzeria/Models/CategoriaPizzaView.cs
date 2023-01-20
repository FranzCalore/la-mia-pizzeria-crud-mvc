using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria.Models
{
    public class CategoriaPizzaView
    {
        public Pizza Pizza { get; set; }

        public List<Categoria>? Categorie { get; set; }

        public List<SelectListItem>? ListaIngredienti { get; set; }

        public List<string>? ListaIdIngredienti { get; set; }
    }

}
