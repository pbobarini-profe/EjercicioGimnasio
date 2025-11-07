using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; 
using Modelos;               

namespace Datos
{
    public class DActividadesClientes
    {
        private string conexion = @"Data Source=.\SQLEXPRESS;Initial Catalog=Gimnasio;Integrated Security=True";

        public List<ActividadesClientes> Get()
        {
            List<ActividadesClientes> lista = new List<ActividadesClientes>(); 

            using (SqlConnection cn = new SqlConnection(conexion)) 
            {
                cn.Open(); // Inicia la conexión
                string sql = "SELECT * FROM ActividadesClientes"; 
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();  

                while (dr.Read()) 
                {
                    lista.Add(new ActividadesClientes
                    {
                        Id = Convert.ToInt32(dr["id"]), // ID del registro
                        Cliente = new Clientes { id = Convert.ToInt32(dr["idCliente"]) },
                        Actividad = new Actividades { id = Convert.ToInt32(dr["idActividad"]) }, 
                        FechaInicio = Convert.ToDateTime(dr["fechaInicio"]), 
                        Vigente = Convert.ToInt32(dr["vigente"]) 
                    });
                }
            }
            return lista; 
        }

        public void Create(ActividadesClientes ac)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open(); 
                string sql = "INSERT INTO ActividadesClientes (idCliente, idActividad, fechaInicio, vigente) VALUES (@idCliente, @idActividad, @fechaInicio, @vigente)";
                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@idCliente", ac.Cliente.id);
                cmd.Parameters.AddWithValue("@idActividad", ac.Actividad.id);
                cmd.Parameters.AddWithValue("@fechaInicio", ac.FechaInicio);
                cmd.Parameters.AddWithValue("@vigente", ac.Vigente);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(ActividadesClientes ac)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open(); 
                string sql = "UPDATE ActividadesClientes SET idCliente=@idCliente, idActividad=@idActividad, fechaInicio=@fechaInicio, vigente=@vigente WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@idCliente", ac.Cliente.id);
                cmd.Parameters.AddWithValue("@idActividad", ac.Actividad.id);
                cmd.Parameters.AddWithValue("@fechaInicio", ac.FechaInicio);
                cmd.Parameters.AddWithValue("@vigente", ac.Vigente);
                cmd.Parameters.AddWithValue("@id", ac.Id); 

                cmd.ExecuteNonQuery(); 
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open(); 
                SqlCommand cmd = new SqlCommand("DELETE FROM ActividadesClientes WHERE id=@id", cn);
                cmd.Parameters.AddWithValue("@id", id); 
                cmd.ExecuteNonQuery(); 
            }
        }
    }
}
