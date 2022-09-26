using Microsoft.AspNetCore.Mvc;
using tallerconfiable53.Datos;
using tallerconfiable53.Models;

namespace tallerconfiable53.Controllers
{
    public class MantenedorController : Controller
    {
        personaDatos _PersonaDatos = new personaDatos();
        public IActionResult Listar()
        {
            //listar contactos
            var oLista = _PersonaDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //devuelve la vista

            return View();
        }

        [HttpPost]
        public IActionResult Guardar(personaModelo oPersona)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();
            //recibe un objeto y guarda en la base de datos
            var respuesta = _PersonaDatos.Guardar(oPersona);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int idPersona)
        {
            //devuelve la vista
            var opersona = _PersonaDatos.Obtener(idPersona);
            return View(opersona);
        }

        [HttpPost]
        public IActionResult Editar(personaModelo oPersona)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();
            //recibe un objeto y guarda en la base de datos
            var respuesta = _PersonaDatos.Editar(oPersona);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idPersona)
        {
            //devuelve la vista
            var opersona = _PersonaDatos.Eliminar(idPersona);
            return View();
        }

        [HttpPost]
        public IActionResult Eliminar(personaModelo oPersona)
        {
            //recibe un objeto y guarda en la base de datos
            var respuesta = _PersonaDatos.Eliminar(oPersona.idPersona);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}