
using Microsoft.AspNetCore.Mvc;
using tallerconfiable53.Datos;
using tallerconfiable53.Models;

namespace tallerconfiable53.Controllers
{
    public class vehiculoController : Controller
    {
        vehiculoDatos _VehiculoDatos = new vehiculoDatos();
        public IActionResult Listar()
        {
            //listar contactos
            var oLista = _VehiculoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //devuelve la vista

            return View();
        }

        [HttpPost]
        public IActionResult Guardar(vehiculoModelo oVehiculo)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();
            //recibe un objeto y guarda en la base de datos
            var respuesta = _VehiculoDatos.Guardar(oVehiculo);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int idVehiculo)
        {
            //devuelve la vista
            var ovehiculo = _VehiculoDatos.Obtener(idVehiculo);
            return View(ovehiculo);
        }

        [HttpPost]
        public IActionResult Editar(vehiculoModelo oVehiculo)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();
            //recibe un objeto y guarda en la base de datos
            var respuesta = _VehiculoDatos.Editar(oVehiculo);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idVehiculo)
        {
            //devuelve la vista
            var opersona = _VehiculoDatos.Eliminar(idVehiculo);
            return View();
        }

        [HttpPost]
        public IActionResult Eliminar(vehiculoModelo oVehiculo)
        {
            //recibe un objeto y guarda en la base de datos
            var respuesta = _VehiculoDatos.Eliminar(oVehiculo.idVehiculo);
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