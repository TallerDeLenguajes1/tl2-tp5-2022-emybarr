using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaWeb.Models.Entidades
{
    public class Cadeteria
    {
        private string nombre;
        private List<Cadete> listaCadete;
        //private List<Cliente> listaCliente;
        //private List<Pedido> listaPedido;

        public string Nombre { get => nombre; set => nombre = value; }
        public List<Cadete> ListaCadete { get => listaCadete; set => listaCadete = value; }
        //public List<Cliente> ListaCliente { get => listaCliente; set => listaCliente = value; }
      //  public List<Pedido> ListaPedido { get => listaPedido; set => listaPedido = value; }




        public Cadeteria(){
            this.Nombre ="";
            this.ListaCadete = new();
           // this.ListaCliente = new();
           // this.ListaPedido = new();
        }
    }
}