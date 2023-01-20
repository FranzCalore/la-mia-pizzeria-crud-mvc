using la_mia_pizzeria.Database;
using la_mia_pizzeria.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace la_mia_pizzeria.Utils
{
    public static class SelectItemManager
    {
        public static List<SelectListItem> ConverterListIngredient()
        {
            using PizzeriaContext db = new();
            List<SelectListItem> list = new();
            foreach(Ingrediente ingrediente in db.Ingredienti)
            {
                SelectListItem Item = new() { Text=ingrediente.Condimento, Value=ingrediente.IngredienteId.ToString()};
                list.Add(Item);
            }
            return list;
        }
    }
}
