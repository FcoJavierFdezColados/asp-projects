using Microsoft.AspNetCore.Mvc;
using PruebasMVC.ViewModels;

namespace PruebasMVC.Controllers
{
    public class PruebasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MeGustas(int id, string nombre, int meGustas)
        {
            PruebasVM pruebasVM = new PruebasVM();

            pruebasVM.Id = id;
            pruebasVM.Nombre = nombre;
            pruebasVM.MeGustas = meGustas;

            //return View(pruebasVM);

            List<PruebasVM> listaPruebasVM = new List<PruebasVM>();

            listaPruebasVM.Add(pruebasVM);

            return View(listaPruebasVM);
        }
    }
}
