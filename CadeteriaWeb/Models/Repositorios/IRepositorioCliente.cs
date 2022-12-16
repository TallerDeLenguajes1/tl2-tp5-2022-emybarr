using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models.Entidades;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;


namespace CadeteriaWeb.Models.Repositorios
{
    public interface IRepositorioCliente
    {
            
    List<Cliente> getAllClientes();
    void EliminarCliente(int id);

    void InsertarCliente(Cliente nuevo);

    void ModificarCliente(Cliente edit);
    Cliente BuscarId(int id);

       

    }
}