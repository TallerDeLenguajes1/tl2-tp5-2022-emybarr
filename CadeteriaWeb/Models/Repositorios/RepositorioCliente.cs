using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models.Entidades;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;



namespace CadeteriaWeb.Models.Repositorios
{
     
    public class RepositorioCliente : IRepositorioCliente
    {
         private string connectionString;

         public RepositorioCliente()
        {
            connectionString = "Data Source=DB/Cadeteria.db";
        }

         public  List<Cliente> getAllClientes()
        {
            const string consulta = "SELECT * FROM Clientes;";
            List<Cliente>lista = new List<Cliente>();
            using var conexion = new SQLiteConnection(connectionString);
            var peticion = new SQLiteCommand(consulta,conexion);
            conexion.Open();

            try
            {
            using var reader = peticion.ExecuteReader();
            while(reader.Read())
            {
                var cliente = new Cliente
                {
                    IdCliente = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Direccion = reader.GetString(2),
                    Telefono = reader.GetString(3),
                    Alta  = reader.GetBoolean(4)
                  
                };
                lista.Add(cliente);
            }

            } catch(Exception)
            {
                Console.WriteLine("error");
            }

            conexion.Close();
            return lista;
            }


            public void EliminarCliente(int id)
            {
                  
                const string consulta = "DELETE FROM Clientes WHERE clienteID = @id ;";
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


            public void InsertarCliente(Cliente nuevo)
            {
                const string consulta = "INSERT INTO Clientes(clienteNombre,clienteDireccion,clienteTelefono,clienteAlta) VALUES (@nombre,@direccion,@telefono,1);";
                try 
                {
                    using var conexion = new SQLiteConnection(connectionString);
                    conexion.Open();
                    var peticion = new SQLiteCommand(consulta,conexion);
                    peticion.Parameters.AddWithValue("@nombre",nuevo.Nombre);
                    peticion.Parameters.AddWithValue("@direccion",nuevo.Direccion);
                    peticion.Parameters.AddWithValue("@telefono", nuevo.Telefono);
                   
                    peticion.ExecuteReader();
                    conexion.Close();

                }catch(Exception) 
                {
                      Console.WriteLine("error");

                }
            }

            

             public void ModificarCliente(Cliente edit) 
             {
                const string consulta = "UPDATE Clientes SET clienteNombre = @nombre, clienteDireccion = @direccion , clienteTelefono = @telefono  WHERE clienteId= @id;";
                try 
                {
                    using var conexion = new SQLiteConnection(connectionString);
                    conexion.Open();
                    var peticion = new SQLiteCommand(consulta,conexion);
                    peticion.Parameters.AddWithValue("@id",edit.IdCliente);
                    peticion.Parameters.AddWithValue("@nombre",edit.Nombre);
                    peticion.Parameters.AddWithValue("@direccion",edit.Direccion);
                    peticion.Parameters.AddWithValue("@telefono", edit.Telefono);
                   
    
                    peticion.ExecuteNonQuery();
                    conexion.Close();
                    conexion.Dispose();

                }catch(Exception) 
                {
                      Console.WriteLine("error");

                }
            }


        public  Cliente BuscarId(int id){
            
        const string consulta = "SELECT * FROM  Clientes WHERE clienteAlta AND clienteId = @id; ";

        try
        {
            using var conexion = new SQLiteConnection(connectionString);
            var peticion = new SQLiteCommand(consulta,conexion);
            conexion.Open();
            peticion.Parameters.AddWithValue("@id", id);
            
 
            var salida = new Cliente();
            using var reader = peticion.ExecuteReader();
            while (reader.Read())
                salida = new Cliente
                {
                    IdCliente = reader.GetInt32(0),
                     Nombre = reader.GetString(1),
                     Telefono = reader.GetString(2),
                      Direccion = reader.GetString(3),
                      Alta  = reader.GetBoolean(4)
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



             }

}
