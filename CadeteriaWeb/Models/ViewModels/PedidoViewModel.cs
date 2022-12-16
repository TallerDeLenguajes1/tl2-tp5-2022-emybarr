using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models.Entidades;
using System.ComponentModel.DataAnnotations;

namespace CadeteriaWeb.Models.ViewModels
{
    public class PedidoViewModel
    {
           [Required]
           public int Id {get;set;}

            [Required]
           public string Observacion {get;set;}

           [Required]
           public Estado Estado {get;set;}

           [Required]
           public int Cliented {get;set;}

            [Required]
            public int Cadeted {get;set;}

            public PedidoViewModel(){}

            
            public PedidoViewModel(int id, string obs, int c, int ca, Estado e )
            {
                Id= id;
                Observacion = obs;
                Estado = e;
                Cliented = c;
                Cadeted = ca;



            } 
      
    }

    public class PedidoListaViewModel 
    {
        public readonly List<CadeteViewModel> Cadetes;
        public readonly List<ClienteViewModel> Clientes;

        public PedidoListaViewModel(List<CadeteViewModel> cadetes,List<ClienteViewModel> clientes)
         {
            Cadetes = cadetes;
            Clientes = clientes;

        }

    }
}