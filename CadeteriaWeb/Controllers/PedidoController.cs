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
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly IRepositorioPedido _repoPedido;
        private readonly IRepositorioCadete _repoCadete;

        private readonly IRepositorioCliente _repoCliente;
        private readonly IMapper _mapper;


        public PedidoController(ILogger<PedidoController> logger,IRepositorioPedido repoPedido,  IRepositorioCadete repoCadete ,IRepositorioCliente repoCliente, IMapper mapper ) 
        {
            _logger = logger;
            _repoPedido = repoPedido;
            _repoCadete = repoCadete;
            _repoCliente = repoCliente;
            _mapper = mapper;

        }

        
         [Route("/Pedido/Index")]

        [HttpGet]

        public IActionResult Index()
        {
            var pedidos = _repoPedido.getAllPedidos();
            var pedidoVM = _mapper.Map<List<PedidoViewModel>>(pedidos);
            return View(pedidoVM);
        }

         [Route("/Pedido/CargarPedido")]
        [HttpGet]
        public IActionResult CargarPedido() 
        {
            var cadete = _repoCadete.getAllCadetes();
            var cliente = _repoCliente.getAllClientes();
            var cadeteVM = _mapper.Map<List<CadeteViewModel>>(cadete);
            var clienteVM = _mapper.Map<List<ClienteViewModel>>(cliente);
            var pedidoLVM = new PedidoListaViewModel(cadeteVM,clienteVM);
              return View(pedidoLVM);

        }

        [HttpPost ("/Pedido/CargarPedido")]

        public IActionResult CargarPedido(PedidoViewModel pVM) 
        {
              var pedido = _mapper.Map<Pedido>(pVM);
                _repoPedido.InsertarPedido(pedido);
            

            return RedirectToAction("Index");

        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}