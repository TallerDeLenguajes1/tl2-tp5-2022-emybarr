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
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
         private readonly IMapper _mapper;
        private readonly IRepositorioCliente _repoCliente;

        public ClienteController(ILogger<ClienteController> logger, IMapper mapper,IRepositorioCliente repoCliente )
        {
            _logger = logger;
            _mapper = mapper;
            _repoCliente = repoCliente;

        }

        public IActionResult Index()
        {
            return View();
        }


         [Route("/Cliente/ListaCliente")]
        [HttpGet]
        public IActionResult ListaCliente()
        {
            var cliente = _repoCliente.getAllClientes();
            var clienteVM = _mapper.Map<List<ClienteViewModel>>(cliente);

            return View(clienteVM);
        }
        
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            _repoCliente.EliminarCliente(id);
        
            return RedirectToAction("ListaCliente");
        }

        [Route("/Cliente/CargarCliente")]
        [HttpGet]
        public IActionResult CargarCliente()
        {
            return View("CargarCliente");
        }

        [HttpPost ("/Cliente/CargarCliente") ]

        public IActionResult CargarCliente(ClienteViewModel clienteVM)
        {
            if(ModelState.IsValid)
            {
                var cliente = _mapper.Map<Cliente>(clienteVM);
                _repoCliente.InsertarCliente(cliente);
            }

            return RedirectToAction("ListaCliente");

        }

        [Route("/Cliente/ModificarCliente")]
        [HttpGet]
    public IActionResult ModificarCliente(int id)
    {
        var cliente = _repoCliente.BuscarId(id);
        if (cliente is null) return RedirectToAction("ListaCliente");
        var clienteVM = _mapper.Map<ModificarClienteViewModel>(cliente);
        return View(clienteVM);
    }

    [HttpPost ("/Cliente/ModificarCliente")]
    public IActionResult ModificarCliente(ModificarClienteViewModel clienteVM)
    {
        if (ModelState.IsValid)
        {
            var cliente = _mapper.Map<Cliente>(clienteVM);
            _repoCliente.ModificarCliente(cliente);
        }
        else
        {
            Console.WriteLine("error");
        }

        return RedirectToAction("ListaCliente");
    }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}