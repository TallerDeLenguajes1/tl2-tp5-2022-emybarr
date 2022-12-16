using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models.Entidades;


namespace CadeteriaWeb.Models.Repositorios
{
    public interface IRepositorioPedido
    {
            List<Pedido> getAllPedidos();
             void EliminarPedido(int id);

             void InsertarPedido(Pedido nuevo);
    }
}