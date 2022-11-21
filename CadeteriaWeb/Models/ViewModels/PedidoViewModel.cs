using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models;
using System.ComponentModel.DataAnnotations;


namespace CadeteriaWeb.Models.ViewModels
{
    public class PedidoViewModel
    {
        public int idcadete {get;set;}

            [Required(ErrorMessage = "INGRESE EL NOMBRE DEL CLIENTE.")]
            [StringLength(100)]
            public string Observacion {get;set;}

            [Required(ErrorMessage = "INGRESE EL NOMBRE DEL CLIENTE.")]
            [StringLength(100)]
            public string Nombrec{get;set;}

            [Required(ErrorMessage = "INGRESE LA DIRECCION DEL CLIENTE.")]
            [StringLength(200)]
            public string Direccionc{get;set;}

            [Required(ErrorMessage = "INGRESE EL TELEFONO CLIENTE.")]
            [StringLength(15)]
            public string Telefonoc{get;set;}


    }
}