
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; 
using Modelos; 
using System.Configuration; 

namespace Datos
{
    
    public class DActividadesClientes
    {
        
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexionBD"].ConnectionString;


        
        public void Create(ActividadesClientes inscripcion)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                
                string consulta = "INSERT INTO ActividadesClientes (clienteId, actividadId, fechaInicio, vigente) " +
                                  "VALUES (@ClienteId, @ActividadId, @FechaInicio, @Vigente)";

                
                SqlCommand comando = new SqlCommand(consulta, conexion);

                
                comando.Parameters.AddWithValue("@ClienteId", inscripcion.Cliente);

                comando.Parameters.AddWithValue("@ActividadId", inscripcion.Actividad);

                comando.Parameters.AddWithValue("@FechaInicio", inscripcion.FechaInicio);
                comando.Parameters.AddWithValue("@Vigente", inscripcion.Vigente);

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    
                    throw new Exception("Error al inscribir cliente: " + ex.Message);
                }
            } 
        }


        
        public List<ActividadesClientes> ListarPorCliente(int clienteId)
        {
            List<ActividadesClientes> lista = new List<ActividadesClientes>();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                
                string consulta = "SELECT id, clienteId, actividadId, fechaInicio, vigente " +
                                  "FROM ActividadesClientes WHERE clienteId = @ClienteId";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@ClienteId", clienteId);

                try
                {
                    conexion.Open();
                    
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        ActividadesClientes item = new ActividadesClientes();

                        item.Id = Convert.ToInt32(reader["id"]);

                        item.Cliente = new Clientes();
                        item.Cliente.id = Convert.ToInt32(reader["idCliente"]);

                        item.Actividad = new Actividades();
                        item.Actividad.id = Convert.ToInt32(reader["idActividad"]);

                        item.FechaInicio = Convert.ToDateTime(reader["fechaInicio"]);

                        item.Vigente = Convert.ToInt32(reader["vigente"]);

                        lista.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar inscripciones: " + ex.Message);
                }
            }
            return lista;
        }
    }
}