
using System;
using System.Collections.Generic; 
using System.Data; 
using System.Data.SqlClient; 
using Modelos; 

namespace Datos
{
   
    public class DClientes
    {
        private string conexion = @"Data Source=.\SQLEXPRESS;Initial Catalog=Gimnasio;Integrated Security=True";
        public List<Clientes> Get()
        {
            List<Clientes> lista = new List<Clientes>();

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Clientes", cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Clientes
                    {
                       
                        id = Convert.ToInt32(dr["id"]),
                        dni = dr["dni"].ToString(),
                        nombre = dr["nombre"].ToString(),
                        apellido = dr["apellido"].ToString(),
                        telefono = dr["telefono"].ToString(),
                        genero = Convert.ToInt32(dr["genero"]),
                        fechaNacimiento = Convert.ToDateTime(dr["fechaNacimiento"])
                    });
                }
            } 

            return lista;
        }

        
        public void Create(Clientes c)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Clientes (dni, nombre, apellido, telefono, genero, fechaNacimiento) VALUES (@dni, @nombre, @apellido, @telefono, @genero, @fechaNacimiento)", cn);

                
                cmd.Parameters.AddWithValue("@dni", c.dni);
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                cmd.Parameters.AddWithValue("@apellido", c.apellido);
                cmd.Parameters.AddWithValue("@telefono", c.telefono);
                cmd.Parameters.AddWithValue("@genero", c.genero);
                cmd.Parameters.AddWithValue("@fechaNacimiento", c.fechaNacimiento);

                
                cmd.ExecuteNonQuery();
            }
        }

        
        public void Update(Clientes c)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open();
                
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Clientes SET dni=@dni, nombre=@nombre, apellido=@apellido, telefono=@telefono, genero=@genero, fechaNacimiento=@fechaNacimiento WHERE id=@id", cn);

                
                cmd.Parameters.AddWithValue("@dni", c.dni);
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                cmd.Parameters.AddWithValue("@apellido", c.apellido);
                cmd.Parameters.AddWithValue("@telefono", c.telefono);
                cmd.Parameters.AddWithValue("@genero", c.genero);
                cmd.Parameters.AddWithValue("@fechaNacimiento", c.fechaNacimiento);
                cmd.Parameters.AddWithValue("@id", c.id); 

                cmd.ExecuteNonQuery();
            }
        }

       
        public void Delete(int id)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Clientes WHERE id=@id", cn);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}