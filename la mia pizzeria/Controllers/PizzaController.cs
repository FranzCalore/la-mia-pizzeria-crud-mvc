using la_mia_pizzeria.Database;
using la_mia_pizzeria.Models;
using Microsoft.AspNetCore.Mvc;
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
                Pizza? pizza = db.Pizze.Where(pi=>pi.Id==ID).Include(p=>p.Categoria).FirstOrDefault();
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
            CategoriaPizzaView modelloView = new();
            modelloView.Pizza = new Pizza();
            modelloView.Categorie = Categorie;

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
                return View("NuovaPizza", formData);
            }

            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizzaDaInserire = formData.Pizza;
                db.Pizze.Add(pizzaDaInserire);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ModificaPizza(int ID)
        {

            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza? pizza =
                    (from pi in db.Pizze
                     where pi.Id == ID
                     select pi).FirstOrDefault();
                if (pizza != null)
                {
                    List<Categoria> Categorie = db.Categorie.ToList();
                    CategoriaPizzaView modelloView = new();
                    modelloView.Pizza = pizza;
                    modelloView.Categorie = Categorie;
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
        public IActionResult ModificaPizza(CategoriaPizzaView formData)
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
                Pizza? pizzadamodificare = (from pi in db.Pizze
                                           where pi.Id == formData.Pizza.Id
                                           select pi).FirstOrDefault();
                if (pizzadamodificare != null)
                {
                    pizzadamodificare.Nome = formData.Pizza.Nome;
                    pizzadamodificare.Descrizione = formData.Pizza.Descrizione;
                    pizzadamodificare.Immagine = formData.Pizza.Immagine;
                    pizzadamodificare.Prezzo = formData.Pizza.Prezzo;
                    pizzadamodificare.CategoriaNome = formData.Pizza.CategoriaNome;

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

