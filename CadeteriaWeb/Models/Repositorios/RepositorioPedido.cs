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
    public class RepositorioPedido : IRepositorioPedido
    {
        private  string connectionString;

        public RepositorioPedido()
        {
            connectionString = "Data Source=DB/Cadeteria.db";

        }

        public List<Pedido> getAllPedidos()
        {
            const string consulta = "SELECT * FROM Pedidos;";
            List<Pedido>lista = new List<Pedido>();
            using var conexion = new SQLiteConnection(connectionString);
            var peticion = new SQLiteCommand(consulta,conexion);
            conexion.Open();

            using var reader = peticion.ExecuteReader();
            while(reader.Read())
            {
                var Pedido = new Pedido 
                {
                    Id = reader.GetInt32(0),
                    Observacion = reader.GetString(1),
                    Cliented = reader.GetInt32(2),
                    Cadeted = reader.GetInt32(3),
                    State = (Estado)Enum.Parse(typeof(Estado),reader["pedidoEstado"].ToString())

                };
                lista.Add(Pedido);
            }
            conexion.Close();
            return lista;

            } 


            public void EliminarPedido(int id) 
        {
              const string consulta = "UPDATE Pedidos SET pedidoAlta = 0  WHERE pedidoID = @id ;";
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

        public void InsertarPedido(Pedido nuevo)
            {
                 string consulta = "INSERT INTO Pedidos(pedidoObs,pedidoEstado,clienteID,pedidoAlta) VALUES (@pedidoObs,@pedidoEstado,@clienteID,1);";
                try 
                {
                    using var conexion = new SQLiteConnection(connectionString);

                    if(nuevo.Cadeted != null) 
                    {
                        consulta = "INSERT INTO Pedidos(pedidoObs,pedidoEstado,clienteID,cadeteID,pedidoAlta) VALUES (@pedidoObs,@pedidoEstado,@clienteID,@cadeteID,1);";
                    }
                    conexion.Open();
                    var peticion = new SQLiteCommand(consulta,conexion);
                    peticion.Parameters.AddWithValue("@pedidoObs",nuevo.Observacion);
                    peticion.Parameters.AddWithValue("@clienteID", nuevo.Cliented);
                    if(nuevo.Cadeted != null) peticion.Parameters.AddWithValue("@cadeteID", nuevo.Cadeted);
                    peticion.Parameters.AddWithValue("@pedidoEstado",nuevo.State);
                   
                    peticion.ExecuteReader();
                    conexion.Close();

                }catch(Exception) 
                {
                      Console.WriteLine("error");

                }
            }
        
    }
}