using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models.Repositorios;
using System.Data.SQLite;
using CadeteriaWeb.Models.Entidades;
using Microsoft.Data.Sqlite;



namespace CadeteriaWeb.Models.Repositorios
{
    public class RepositorioCadete : IRepositorioCadete
    {
        private readonly string _connectionString;

        public RepositorioCadete(string connectionString) 
        {
            _connectionString = connectionString;

        }
        public List<Cadete> getAllCadetes()
        {
            List<Cadete> listacadete = new List<Cadete>();
            using(SQLiteConnection conexion = new SQLiteConnection(_connectionString))
            {
                conexion.Open();
                string consulta= "SELECT * FROM Cadete;";
                using(SQLiteCommand command = new SQLiteCommand(consulta,conexion))
                {
                    var reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        Cadete c = new Cadete()
                        {
                            IdCadete = Convert.ToInt32(reader["idcadete"]),
                            Nombre = reader["nombrecadete"].ToString(),
                            Direccion = reader["direccioncadete"].ToString(),
                            Telefono = reader["telefonocadete"].ToString(),
                            Alta = Convert.ToBoolean(reader["altacadete"]),


                        };
                        listacadete.Add(c);
                    }
                    reader.Close();
                }
                conexion.Close();
                return listacadete;

            }



        }
    }
}
