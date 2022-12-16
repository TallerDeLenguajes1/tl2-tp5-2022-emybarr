using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CadeteriaWeb.Models.Entidades;
using Microsoft.Data.Sqlite ;
using AutoMapper;
using CadeteriaWeb.Models.ViewModels;
using System.Data.SQLite;
using CadeteriaWeb.Models.Repositorios;



namespace CadeteriaWeb.Controllers
{
   [Route("[controller]")]
    public class CadeteController : Controller
    {
        private readonly ILogger<CadeteController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepositorioCadete _repoCadete;
      

        public CadeteController(ILogger<CadeteController> logger , IMapper mapper, IRepositorioCadete repoCadete)
        {
            _logger = logger;
            _mapper = mapper;
            _repoCadete = repoCadete;
            
        }

        [Route("/Cadete/Index")]
        [HttpGet]
        public IActionResult Index()
        {
          
            return View();
        }

        [Route("/Cadete/ListaCadete")]
        [HttpGet]
        public IActionResult ListaCadete()
        {
            var cadete = _repoCadete.getAllCadetes();
            var cadeteVM = _mapper.Map<List<CadeteViewModel>>(cadete);
        
            return View(cadeteVM);
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            _repoCadete.EliminarCadete(id);
        
    
            return RedirectToAction("ListaCadete");
        }

        [Route("/Cadete/CargarCadete")]
        [HttpGet]
        public IActionResult CargarCadete()
        {
            return View("CargarCadete");
        }


        [HttpPost ("/Cadete/CargarCadete") ]

        public IActionResult CargarCadete(CadeteViewModel cadeteVM)
        {
            if(ModelState.IsValid)
            {
                var cadete = _mapper.Map<Cadete>(cadeteVM);
                _repoCadete.InsertarCadete(cadete);
            }else
            {
                return RedirectToAction("Error");

            }

            return RedirectToAction("ListaCadete");

        }

       [Route("/Cadete/ModificarCadete")]
        [HttpGet]
    public IActionResult ModificarCadete(int id)
    {
        var cadete = _repoCadete.BuscarId(id);
        if (cadete is null) return RedirectToAction("ListaCadete");
        var cadeteVM = _mapper.Map<ModificaCadeteViewModel>(cadete);
        return View(cadeteVM);
    }

    [HttpPost ("/Cadete/ModificarCadete")]
    public IActionResult ModificarCadete(ModificaCadeteViewModel cadeteVM)
    {
        if (ModelState.IsValid)
        {
            var cadete = _mapper.Map<Cadete>(cadeteVM);
            _repoCadete.ModificarCadete(cadete);
        }
        else
        {
            Console.WriteLine("error");
        }

        return RedirectToAction("ListaCadete");
    }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}