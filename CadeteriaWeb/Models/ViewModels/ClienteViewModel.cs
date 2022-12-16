using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models.Entidades;
using System.ComponentModel.DataAnnotations;


namespace CadeteriaWeb.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int IdCliente{get;set;}

            [Required(ErrorMessage = "INGRESE EL NOMBRE.")]
            [StringLength(100)]
            public string Nombre{get;set;}

            [Required(ErrorMessage = "INGRESE LA DIRECCION.")]
            [StringLength(200)]
            public string Direccion{get;set;}

            [Required(ErrorMessage = "INGRESE EL TELEFONO.")]
            [StringLength(15)]
            public string Telefono{get;set;}

            public bool Alta {get;set;}

            public ClienteViewModel(){}

            public ClienteViewModel(int i , string n , string d , string tel)
            {
                  IdCliente=i;
                  Nombre= n;
                  Direccion= d;
                  Telefono= tel;
             
            }
    }


     public class ClienteListaViewModel
            {
                public int IdCliente {get;set;}

                public string Nombre{get;set;}
                public string Direccion{get;set;}
                public string Telefono {get;set;}

            }

            public class CargarClienteViewModel 
            {
            public int IdCadete{get;set;}

            [Required(ErrorMessage = "INGRESE EL NOMBRE.")]
            [StringLength(100)]
            public string Nombre{get;set;}

            [Required(ErrorMessage = "INGRESE LA DIRECCION.")]
            [StringLength(200)]
            public string Direccion{get;set;}

            [Required(ErrorMessage = "INGRESE EL TELEFONO.")]
            [StringLength(15)]
            public string Telefono{get;set;}

            }

            public class ModificarClienteViewModel 
            {
                 public int IdCliente{get;set;}

            [Required(ErrorMessage = "INGRESE EL NOMBRE.")]
            [StringLength(100)]
            public string Nombre{get;set;}

            [Required(ErrorMessage = "INGRESE LA DIRECCION.")]
            [StringLength(200)]
            public string Direccion{get;set;}

            [Required(ErrorMessage = "INGRESE EL TELEFONO.")]
            [StringLength(15)]
            public string Telefono{get;set;}

            }
}