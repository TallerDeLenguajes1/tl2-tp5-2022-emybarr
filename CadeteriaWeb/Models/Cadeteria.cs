using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaWeb.Models
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> cadete ;
        private List<Pedidos> pedido;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedidos> Pedido { get => pedido; set => pedido = value; }
        public List<Cadete> Cadete { get => cadete; set => cadete = value; }
        

        public Cadeteria(){}

        public Cadeteria(string n , string te){
            Nombre=n;
            Telefono =te;
            Pedido= new List<Pedidos>();
            Cadete = new List<Cadete>();
        }
    }
}