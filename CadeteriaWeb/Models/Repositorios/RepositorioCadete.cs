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
        private  string connectionString;

        public RepositorioCadete()
        {
            connectionString = "Data Source=DB/Cadeteria.db";

        }

        public List<Cadete> getAllCadetes()
        {
            const string consulta = "SELECT * FROM Cadetes;";
            List<Cadete>lista = new List<Cadete>();
            using var conexion = new SQLiteConnection(connectionString);
            var peticion = new SQLiteCommand(consulta,conexion);
            conexion.Open();

            using var reader = peticion.ExecuteReader();
            while(reader.Read())
            {
                var cadete = new Cadete 
                {
                    IdCadete = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Telefono = reader.GetString(2),
                    Direccion = reader.GetString(3),
                    Alta = reader.GetBoolean(4)

                };
                lista.Add(cadete);
            }
            conexion.Close();
            return lista;

            } 

            
      

            public void EliminarCadete(int id)
            {
                const string consulta = "DELETE FROM Cadetes WHERE cadeteID = @id ;";
                try 
                {
                    using var conexion = new SQLiteConnection(connectionString);
                    conexion.Open();
                    var peticion = new SQLiteCommand(consulta,conexion);
                    peticion.Parameters.AddWithValue("@id",id);
                    peticion.ExecuteReader();
                    conexion.Close();
                }
                catch(Exception)
                {
                       Console.WriteLine("error");
                }

            }


           public void InsertarCadete(Cadete nuevo)
            {
                const string consulta = "INSERT INTO Cadetes(cadeteNombre,cadeteDireccion,cadeteTelefono,cadeteAlta) VALUES (@nombre,@direccion,@telefono,1);";
                try 
                {
                    using var conexion = new SQLiteConnection(connectionString);
                    conexion.Open();
                    var peticion = new SQLiteCommand(consulta,conexion);
                    peticion.Parameters.AddWithValue("@nombre",nuevo.Nombre);
                    peticion.Parameters.AddWithValue("@telefono", nuevo.Telefono);
        
                    peticion.Parameters.AddWithValue("@direccion",nuevo.Direccion);
                   
                    peticion.ExecuteReader();
                    conexion.Close();

                }catch(Exception) 
                {
                      Console.WriteLine("error");

                }
            }

        public  Cadete BuscarId(int id){
            
        const string consulta = "SELECT * FROM  Cadetes WHERE cadeteID = @id; ";

        try
        {
            using var conexion = new SQLiteConnection(connectionString);
            var peticion = new SQLiteCommand(consulta,conexion);
            conexion.Open();
            peticion.Parameters.AddWithValue("@id", id);
            
 
            var salida = new Cadete();
            using var reader = peticion.ExecuteReader();
            while (reader.Read())
                salida = new Cadete
                {
                    IdCadete = reader.GetInt32(0),
                     Nombre = reader.GetString(1),
                     Telefono = reader.GetString(2),
                      Direccion = reader.GetString(3),
                    Alta = reader.GetBoolean(4)
                };
            conexion.Close();
            return salida;
        }
        catch (Exception e)
        {
             Console.WriteLine("error");
        }

        return null;
    }

    public void ModificarCadete(Cadete edit){

        const string consulta =  "UPDATE Cadetes SET cadeteNombre = @nombre,cadeteDireccion = @direccion ,cadeteTelefono = @telefono  WHERE cadeteID = @id ;";

             try
        {
                    using var conexion = new SQLiteConnection(connectionString);
                    conexion.Open();
                    var peticion = new SQLiteCommand(consulta,conexion);
                   
            
                    peticion.Parameters.AddWithValue("@id",edit.IdCadete);
                    peticion.Parameters.AddWithValue("@nombre",edit.Nombre);
                    peticion.Parameters.AddWithValue("@direccion",edit.Direccion);
                    peticion.Parameters.AddWithValue("@telefono", edit.Telefono);
        
                   
                    peticion.ExecuteNonQuery();
                    conexion.Close();
                    conexion.Dispose();
                    
                    
            
                
            
            
        }catch (Exception )
        {
             Console.WriteLine("no se guarda");
        }



    }


}
 }
