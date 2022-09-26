using Microsoft.AspNetCore.Mvc;
using tallerconfiable53.Datos;
using tallerconfiable53.Models;

namespace tallerconfiable53.Controllers
{
    public class MecanicoController : Controller
    {
        mecanicoDatos _MecanicoDatos = new mecanicoDatos();
        public IActionResult Listar()
        {
            //listar contactos
            var oLista = _MecanicoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //devuelve la vista

            return View();
        }

        [HttpPost]
        public IActionResult Guardar(mecanicoModelo oMecanico)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();
            //recibe un objeto y guarda en la base de datos
            var respuesta = _MecanicoDatos.Guardar(oMecanico);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int idPersona)
        {
            //devuelve la vista
            var opersona = _MecanicoDatos.Obtener(idPersona);
            return View(opersona);
        }

        [HttpPost]
        public IActionResult Editar(mecanicoModelo oMecanico)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();
            //recibe un objeto y guarda en la base de datos
            var respuesta = _MecanicoDatos.Editar(oMecanico);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idPersona)
        {
            //devuelve la vista
            var opersona = _MecanicoDatos.Eliminar(idPersona);
            return View();
        }

        [HttpPost]
        public IActionResult Eliminar(personaModelo oMecanico)
        {
            //recibe un objeto y guarda en la base de datos
            var respuesta = _MecanicoDatos.Eliminar(oMecanico.idPersona);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    
        public IActionResult Index()
        {
            return View();
        }
    }
}
