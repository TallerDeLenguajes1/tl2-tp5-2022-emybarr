using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models.Entidades;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;


namespace CadeteriaWeb.Models.Repositorios
{
    public interface IRepositorioCadete
    {
    
    List<Cadete> getAllCadetes();
    void EliminarCadete(int id);
    void InsertarCadete(Cadete nuevo);
     Cadete BuscarId(int id);
    void ModificarCadete(Cadete edit);
    
        
      
    }
}