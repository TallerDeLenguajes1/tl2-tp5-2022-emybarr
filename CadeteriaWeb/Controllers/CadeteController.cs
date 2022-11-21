using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CadeteriaWeb.Models;
using AutoMapper;
using CadeteriaWeb.Models.ViewModels;
using Microsoft.Extensions.Configuration ;




namespace CadeteriaWeb.Controllers
{
    [Route("[controller]")]
    public class CadeteController : Controller
    {
        private readonly ILogger<CadeteController> _logger;
        private readonly IMapper _mapper;
    
      private static int _id ;
       

        public CadeteController(ILogger<CadeteController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
                  
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
            string archivo = "Cadetes.csv";
            var cadete = Leer(archivo);
            var cadeteVM = _mapper.Map<List<CadeteViewModel>>(cadete);
            _id= cadete.Count();
        
            return View(cadeteVM);
        }

        [Route("/Cadete/CargarCadete")]
        [HttpGet]
        public IActionResult CargarCadete()
        {
            return View("CargarCadete");
        }

        [HttpPost ("{CargarCadete}")]
        public IActionResult CargarCadete(CadeteViewModel nuevocadete) 
        {
            string ar = "Cadetes.csv";
          
            var c = _mapper.Map<Cadete>(nuevocadete);
            
            c.Id= _id++;
            c.Nombre = nuevocadete.Nombre;
            c.Direccion = nuevocadete.Direccion;
            c.Telefono = nuevocadete.Telefono;
        
            Guardar(c,ar);
            return RedirectToAction("ListaCadete");
        }

        [HttpGet]

        public IActionResult Eliminar(int id) 
        {
             string ar = "Cadetes.csv";
             Borrar(id,ar);

              return RedirectToAction("ListaCadete");

        }

        [Route("/Cadete/ModificarCadete/{id}")]
        [HttpGet]
        
         public IActionResult ModificarCadete(int id)
             {
             
                string archivo = "Cadetes.csv";
                var cadete = Leer(archivo);
                var cadeteModificar = cadete.Find( x => x.Id == id);
                var cadeteV = _mapper.Map<CadeteViewModel>(cadeteModificar);
                return View(cadeteV);

             }

              [HttpPost ]

             public RedirectToActionResult ModificarCadete( CadeteViewModel editcadete)
            {
                string archiv = "Cadetes.csv";
                Cadete updateCadete = _mapper.Map<Cadete>(editcadete);
                Escribir(updateCadete,archiv);

              return RedirectToAction("ListaCadete");

        }

    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    


      static List<Cadete> Leer(string archivo)
           {
            
            List<Cadete> lista = new List<Cadete>();
            string path =  System.IO.Path.GetFullPath(archivo) ;
            string [] l = System.IO.File.ReadAllLines(path);

            foreach(var linea in l)
            {
                string [] dato = linea.Split(',');
                Cadete cadete = new Cadete();
                cadete.Id= Convert.ToInt32(dato[0]);
                cadete.Nombre = dato[1];
                cadete.Direccion = dato[2];
                cadete.Telefono = dato[3];

                lista.Add(cadete);

            }
            return lista;

           }

           static void Guardar(Cadete cadete, string archivo)
        {
            string path =  System.IO.Path.GetFullPath(archivo) ;
            List<string> datos = new List<string>();
            datos.Add( cadete.Id+ "," + cadete.Nombre +"," + cadete.Direccion + "," + cadete.Telefono );
            System.IO.File.AppendAllLines(path,datos);

    }

    static void Escribir(Cadete cadete, string archivo) 
    {
        string path =  System.IO.Path.GetFullPath(archivo) ;
        List<Cadete> lista = new List<Cadete>();
        List<string> l = new List<string>();
        lista= Leer(archivo);
        System.IO.File.Delete(archivo);
        foreach( var c in lista)
        {
            if(cadete.Id == c.Id)
            {
                l.Add(cadete.Id + "," + cadete.Nombre + "," + cadete.Direccion + "," + cadete.Telefono);
            }else {
                  l.Add(c.Id + "," + c.Nombre + "," + c.Direccion + "," + c.Telefono);
            }
        }
            System.IO.File.AppendAllLines(path,l);

    }


    static void Borrar(int i, string archivo) 
    {
        string path =  System.IO.Path.GetFullPath(archivo) ;
        List<Cadete> lista = new List<Cadete>();
        lista= Leer(archivo);
        System.IO.File.Delete(path);
        System.IO.StreamWriter sw = new System.IO.StreamWriter(path);
        foreach (var cad in lista)
        {
            if(cad.Id!=i)
            {
                sw.WriteLine(cad.Id + "," + cad.Nombre + "," + cad.Direccion + "," + cad.Telefono);
            }
        }
        sw.Close();
    }
    }

}