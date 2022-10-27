using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaWeb.Models
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private List<Pedidos>listasPedido;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedidos> ListasPedido { get => listasPedido; set => listasPedido = value; }

        public Cadete(){}

          public Cadete(int i, string n , string d , string tel ){
            Id=i;
            Nombre = n;
            Direccion = d;
            Telefono = tel;
            ListasPedido = new List<Pedidos>();
          }

    }
    }
