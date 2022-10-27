using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CadeteriaWeb.Models;

namespace CadeteriaWeb.Controllers
{
    [Route("[controller]")]
    public class CadeteController : Controller
    {
        private readonly ILogger<CadeteController> _logger;

        public CadeteController(ILogger<CadeteController> logger)
        {
            _logger = logger;
        }

         [HttpGet]

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult crearCadete(string nombre, string direccion, string tel) 
        {
            int id=0;

            id++; //??
            Cadete nuevoCadete = new Cadete(id,nombre,direccion,tel);
            List<Cadete>listaCadetes = new List<Cadete>();
            listaCadetes.Add(nuevoCadete);
            return View("MostrarCadetes",listaCadetes);
        }

        public IActionResult MostrarCadetes(){
            return View();

        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}