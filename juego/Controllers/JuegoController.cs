using juego.Datos;
using juego.Models;
using Microsoft.AspNetCore.Mvc;

namespace juego.Controllers
{
    public class JuegoController : Controller
    {
        PlataformaDatos BD = new PlataformaDatos();
        public IActionResult Index()
        {
            return View(BD.ListaJuegos(0));
        }

        public IActionResult Create()
        {
            ViewBag.Desarrollador = BD.listarDesarrollador(0);
            return View();
        }

        [HttpPost]

        public IActionResult Create(Juego juego)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View();
                }
                ViewBag.Desarrollador = BD.listarDesarrollador(0);
                ViewBag.Error = BD.CrearJuego(juego);
                if (ViewBag.Error != "")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Details(int id)
        {
            return View(BD.ListaJuegos(id).FirstOrDefault());
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Desarrollador = BD.listarDesarrollador(0);
            return View(BD.ListaJuegos(id).FirstOrDefault());
        }
        [HttpPost]

        public IActionResult Edit(Juego juego)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                ViewBag.Error = BD.EditarJuego(juego);
                if (ViewBag.Error != "")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }

        }
        public IActionResult Delete(int id)
        {
            return View(BD.ListaJuegos(id).FirstOrDefault());
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (BD.ListaJuegos(id).Any())
                {
                    ViewBag.Error = BD.EliminarJuego(id);

                    if (ViewBag.Error != "")
                    {
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return BadRequest();
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
