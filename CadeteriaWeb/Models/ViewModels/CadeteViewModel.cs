using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models;
using System.ComponentModel.DataAnnotations;


namespace CadeteriaWeb.Models.ViewModels
{
    public class CadeteViewModel
    {

            public int Id{get;set;}

            [Required(ErrorMessage = "INGRESE EL NOMBRE.")]
            [StringLength(100)]
            public string Nombre{get;set;}

            [Required(ErrorMessage = "INGRESE LA DIRECCION.")]
            [StringLength(200)]
            public string Direccion{get;set;}

            [Required(ErrorMessage = "INGRESE EL TELEFONO.")]
            [StringLength(15)]
            public string Telefono{get;set;}

            public CadeteViewModel(){}


            public CadeteViewModel(int id, string n, string d, string te){
                Id= id;
                Nombre = n;
                Direccion = d;
                Telefono = te;
            }

    }

      
      }



