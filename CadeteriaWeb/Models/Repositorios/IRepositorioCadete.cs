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
    
        List<Cadete>getAllCadetes();
        
       // void InsertarCadete(Cadete nuevo);
        //void ActualizarCadete(Cadete modificarCadete);

        //void deleteCadete(int id);

        //Cadete elegirCadete(int id);
    }
}