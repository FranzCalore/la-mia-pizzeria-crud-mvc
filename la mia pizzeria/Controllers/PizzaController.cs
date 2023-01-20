using Azure;
using la_mia_pizzeria.Database;
using la_mia_pizzeria.Models;
using la_mia_pizzeria.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult LeNostrePizze()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Pizza> ListaPizze = db.Pizze.ToList<Pizza>();

                return View("LeNostrePizze", ListaPizze);
            }

        }

        public IActionResult Index()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Pizza>? ListaPizze = db.Pizze.Where(p=>p.Categoria.Nome=="Pizze Speciali").ToList<Pizza>();

                return View("Index", ListaPizze);
            }
        }
        public IActionResult Dettagli(int ID)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza? pizza = db.Pizze.Where(p=>p.Id==ID).Include(pi=>pi.Categoria).Include(piz=>piz.Ingredienti).FirstOrDefault();
                if (pizza != null)
                {
                    return View(pizza);
                }
                else
                {
                    return NotFound("La pizza ricercata non è presente a listino");
                }

            }
        }

        [HttpGet]
        public IActionResult NuovaPizza()
        {
            using PizzeriaContext db = new();
            List<Categoria> Categorie= db.Categorie.ToList();
            List<Ingrediente> Ingredienti = db.Ingredienti.ToList();
            CategoriaPizzaView modelloView = new()
            {
                Pizza = new Pizza(),
                Categorie = Categorie,
                ListaIngredienti = SelectItemManager.ConverterListIngredient()
            };

            return View("NuovaPizza", modelloView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NuovaPizza(CategoriaPizzaView formData)
        {
            if (!ModelState.IsValid)
            {
                using PizzeriaContext db = new();
                List<Categoria> categorie = db.Categorie.ToList();
                formData.Categorie = categorie;
                formData.ListaIngredienti = SelectItemManager.ConverterListIngredient();
                return View("NuovaPizza", formData);
            }

            using (PizzeriaContext db = new PizzeriaContext())
            {
                if(formData.ListaIdIngredienti != null)
                {
                    formData.Pizza.Ingredienti = new();
                    foreach(string IdIngrediente in formData.ListaIdIngredienti)
                    {
                        int IDNumero = int.Parse(IdIngrediente);
                        Ingrediente? ingrediente = db.Ingredienti.Where(i=>i.IngredienteId== IDNumero).FirstOrDefault();
                        formData.Pizza.Ingredienti.Add(ingrediente);
                    }
                }
                db.Pizze.Add(formData.Pizza);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ModificaPizza(int ID)
        {

            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza? pizza = db.Pizze.Where(p=>p.Id==ID).Include(pi=>pi.Ingredienti).FirstOrDefault();
                if (pizza != null)
                {
                    List<Categoria> Categorie = db.Categorie.ToList();
                    CategoriaPizzaView modelloView = new()
                    {
                        Pizza = pizza,
                        Categorie = Categorie
                    };
                    List<Ingrediente> IngredientiDb = db.Ingredienti.ToList();
                    List<SelectListItem> ListItem = new();
                    foreach(Ingrediente ingrediente in IngredientiDb)
                    {
                        bool Selected = pizza.Ingredienti.Any(ing => ing.IngredienteId == ingrediente.IngredienteId);

                        SelectListItem Option = new SelectListItem() { 
                            Text = ingrediente.Condimento,
                            Value = ingrediente.IngredienteId.ToString(),
                            Selected = Selected };
                        ListItem.Add(Option);
                    }
                    modelloView.ListaIngredienti = ListItem;
                    return View("ModificaPizza", modelloView);
                }
                else
                {
                    return NotFound("La pizza ricercata non è presente a listino");
                }

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificaPizza(int ID, CategoriaPizzaView formData)
        {
            if (!ModelState.IsValid)
            {
                using PizzeriaContext db = new();
                List<Categoria> categorie = db.Categorie.ToList();
                formData.Categorie = categorie;
                return View("ModificaPizza", formData);
            }

            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza? pizza = db.Pizze.Where(p => p.Id == ID).Include(pi => pi.Ingredienti).FirstOrDefault();
                if (pizza != null)
                {
                    pizza.Nome = formData.Pizza.Nome;
                    pizza.Descrizione = formData.Pizza.Descrizione;
                    pizza.Immagine = formData.Pizza.Immagine;
                    pizza.Prezzo = formData.Pizza.Prezzo;
                    pizza.CategoriaNome = formData.Pizza.CategoriaNome;

                    pizza.Ingredienti.Clear();
                    if (formData.ListaIdIngredienti != null)
                    {
                        foreach (string IdIngrediente in formData.ListaIdIngredienti)
                        {
                            int IDNumero = int.Parse(IdIngrediente);
                            Ingrediente? ingrediente = db.Ingredienti.Where(i => i.IngredienteId == IDNumero).FirstOrDefault();
                            pizza.Ingredienti.Add(ingrediente);
                        }
                    }

                    db.SaveChanges();
                }

            }
            return RedirectToAction("Index");
        }

        public IActionResult EliminaPizza(int ID)
        {

            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza? pizzadaEliminare = (from pi in db.Pizze
                                           where pi.Id == ID
                                           select pi).FirstOrDefault();
                if (pizzadaEliminare != null)
                {
                    db.Remove(pizzadaEliminare);

                    db.SaveChanges();
                }

            }
            return RedirectToAction("Index");
        }
    }
}

