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

        [HttpGet]
        public IActionResult Index()
        {
            //var cadete = _repoCadete.getAllCadetes();
            //var cadeteVM = _mapper.Map<List<CadeteViewModel>>(cadete);
        
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}