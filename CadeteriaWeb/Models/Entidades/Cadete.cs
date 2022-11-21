using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CadeteriaWeb.Models
{
    public class Cadete
    {
        private int id; 

        private string nombre;

        private string direccion;

        private string telefono;
       

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
      
         public string Telefono { get => telefono; set => telefono = value; }
         
         public int Id { get => id; set => id = value; }

        public Cadete(){}

          public Cadete(int i , string n , string d , string tel )
          {
            Id= i;
            Nombre = n;
            Direccion = d;
            Telefono = tel;
           
          }

            
    }
}