using Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Datos
{
    public class DPagosClientes
    {
        
        private string connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        public bool Insert(PagosClientes pago)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO PagosClientes (fechaPago, clienteId, planClienteId, descripcion, periodoId) 
                                   VALUES (@fechaPago, @clienteId, @planClienteId, @descripcion, @periodoId)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fechaPago", pago.fechaPago);
                    cmd.Parameters.AddWithValue("@clienteId", pago.cliente.id);
                    cmd.Parameters.AddWithValue("@planClienteId", pago.planCliente.id);
                    cmd.Parameters.AddWithValue("@descripcion", pago.descripcion);
                    cmd.Parameters.AddWithValue("@periodoId", pago.periodo.id);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar pago: " + ex.Message);
            }
        }

        public bool Update(PagosClientes pago)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE PagosClientes 
                                   SET fechaPago = @fechaPago, 
                                       clienteId = @clienteId, 
                                       planClienteId = @planClienteId, 
                                       descripcion = @descripcion, 
                                       periodoId = @periodoId 
                                   WHERE id = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", pago.id);
                    cmd.Parameters.AddWithValue("@fechaPago", pago.fechaPago);
                    cmd.Parameters.AddWithValue("@clienteId", pago.cliente.id);
                    cmd.Parameters.AddWithValue("@planClienteId", pago.planCliente.id);
                    cmd.Parameters.AddWithValue("@descripcion", pago.descripcion);
                    cmd.Parameters.AddWithValue("@periodoId", pago.periodo.id);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar pago: " + ex.Message);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM PagosClientes WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar pago: " + ex.Message);
            }
        }

        public List<PagosClientes> GetAll()
        {
            List<PagosClientes> lista = new List<PagosClientes>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT p.id, p.fechaPago, p.descripcion,
                                    c.id as clienteId, c.nombre as clienteNombre, c.apellido as clienteApellido, c.dni as clienteDni,
                                    ac.id as planId, ac.fechaInicio as planFechaInicio,
                                    a.id as actividadId, a.descripcion as actividadDesc, a.monto,
                                    per.id as periodoId, per.descripcion as periodoDesc
                                    FROM PagosClientes p
                                    INNER JOIN Clientes c ON p.clienteId = c.id
                                    INNER JOIN ActividadesClientes ac ON p.planClienteId = ac.id
                                    INNER JOIN Actividades a ON ac.actividadId = a.id
                                    INNER JOIN Periodos per ON p.periodoId = per.id
                                    ORDER BY p.fechaPago DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PagosClientes pago = new PagosClientes
                        {
                            id = Convert.ToInt32(reader["id"]),
                            fechaPago = Convert.ToDateTime(reader["fechaPago"]),
                            descripcion = reader["descripcion"].ToString(),
                            cliente = new Clientes
                            {
                                id = Convert.ToInt32(reader["clienteId"]),
                                nombre = reader["clienteNombre"].ToString(),
                                apellido = reader["clienteApellido"].ToString(),
                                dni = reader["clienteDni"].ToString()
                            },
                            planCliente = new ActividadesClientes
                            {
                                id = Convert.ToInt32(reader["planId"]),
                                fechaInicio = Convert.ToDateTime(reader["planFechaInicio"]),
                                actividad = new Actividades
                                {
                                    id = Convert.ToInt32(reader["actividadId"]),
                                    descripcion = reader["actividadDesc"].ToString(),
                                    monto = Convert.ToDecimal(reader["monto"])
                                }
                            },
                            periodo = new Periodos
                            {
                                id = Convert.ToInt32(reader["periodoId"]),
                                descripcion = Convert.ToInt32(reader["periodoDesc"])
                            }
                        };
                        lista.Add(pago);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener pagos: " + ex.Message);
            }

            return lista;
        }

        public PagosClientes GetById(int id)
        {
            PagosClientes pago = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT p.id, p.fechaPago, p.descripcion,
                                    c.id as clienteId, c.nombre as clienteNombre, c.apellido as clienteApellido, c.dni as clienteDni,
                                    ac.id as planId, ac.fechaInicio as planFechaInicio,
                                    a.id as actividadId, a.descripcion as actividadDesc, a.monto,
                                    per.id as periodoId, per.descripcion as periodoDesc
                                    FROM PagosClientes p
                                    INNER JOIN Clientes c ON p.clienteId = c.id
                                    INNER JOIN ActividadesClientes ac ON p.planClienteId = ac.id
                                    INNER JOIN Actividades a ON ac.actividadId = a.id
                                    INNER JOIN Periodos per ON p.periodoId = per.id
                                    WHERE p.id = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        pago = new PagosClientes
                        {
                            id = Convert.ToInt32(reader["id"]),
                            fechaPago = Convert.ToDateTime(reader["fechaPago"]),
                            descripcion = reader["descripcion"].ToString(),
                            cliente = new Clientes
                            {
                                id = Convert.ToInt32(reader["clienteId"]),
                                nombre = reader["clienteNombre"].ToString(),
                                apellido = reader["clienteApellido"].ToString(),
                                dni = reader["clienteDni"].ToString()
                            },
                            planCliente = new ActividadesClientes
                            {
                                id = Convert.ToInt32(reader["planId"]),
                                fechaInicio = Convert.ToDateTime(reader["planFechaInicio"]),
                                actividad = new Actividades
                                {
                                    id = Convert.ToInt32(reader["actividadId"]),
                                    descripcion = reader["actividadDesc"].ToString(),
                                    monto = Convert.ToDecimal(reader["monto"])
                                }
                            },
                            periodo = new Periodos
                            {
                                id = Convert.ToInt32(reader["periodoId"]),
                                descripcion = Convert.ToInt32(reader["periodoDesc"])
                            }
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener pago: " + ex.Message);
            }

            return pago;
        }

        public List<PagosClientes> GetByCliente(int clienteId)
        {
            List<PagosClientes> lista = new List<PagosClientes>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT p.id, p.fechaPago, p.descripcion,
                                    c.id as clienteId, c.nombre as clienteNombre, c.apellido as clienteApellido, c.dni as clienteDni,
                                    ac.id as planId, ac.fechaInicio as planFechaInicio,
                                    a.id as actividadId, a.descripcion as actividadDesc, a.monto,
                                    per.id as periodoId, per.descripcion as periodoDesc
                                    FROM PagosClientes p
                                    INNER JOIN Clientes c ON p.clienteId = c.id
                                    INNER JOIN ActividadesClientes ac ON p.planClienteId = ac.id
                                    INNER JOIN Actividades a ON ac.actividadId = a.id
                                    INNER JOIN Periodos per ON p.periodoId = per.id
                                    WHERE p.clienteId = @clienteId
                                    ORDER BY p.fechaPago DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@clienteId", clienteId);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PagosClientes pago = new PagosClientes
                        {
                            id = Convert.ToInt32(reader["id"]),
                            fechaPago = Convert.ToDateTime(reader["fechaPago"]),
                            descripcion = reader["descripcion"].ToString(),
                            cliente = new Clientes
                            {
                                id = Convert.ToInt32(reader["clienteId"]),
                                nombre = reader["clienteNombre"].ToString(),
                                apellido = reader["clienteApellido"].ToString(),
                                dni = reader["clienteDni"].ToString()
                            },
                            planCliente = new ActividadesClientes
                            {
                                id = Convert.ToInt32(reader["planId"]),
                                fechaInicio = Convert.ToDateTime(reader["planFechaInicio"]),
                                actividad = new Actividades
                                {
                                    id = Convert.ToInt32(reader["actividadId"]),
                                    descripcion = reader["actividadDesc"].ToString(),
                                    monto = Convert.ToDecimal(reader["monto"])
                                }
                            },
                            periodo = new Periodos
                            {
                                id = Convert.ToInt32(reader["periodoId"]),
                                descripcion = Convert.ToInt32(reader["periodoDesc"])
                            }
                        };
                        lista.Add(pago);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener pagos del cliente: " + ex.Message);
            }

            return lista;
        }

        public List<Clientes> ObtenerClientes()
        {
            List<Clientes> lista = new List<Clientes>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT id, dni, nombre, apellido FROM Clientes ORDER BY apellido, nombre";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new Clientes
                        {
                            id = Convert.ToInt32(reader["id"]),
                            dni = reader["dni"].ToString(),
                            nombre = reader["nombre"].ToString(),
                            apellido = reader["apellido"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener clientes: " + ex.Message);
            }

            return lista;
        }

        public List<ActividadesClientes> ObtenerActividadesCliente(int clienteId)
        {
            List<ActividadesClientes> lista = new List<ActividadesClientes>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT ac.id, ac.fechaInicio, ac.vigente,
                                    a.id as actividadId, a.descripcion as actividadDesc, a.monto
                                    FROM ActividadesClientes ac
                                    INNER JOIN Actividades a ON ac.actividadId = a.id
                                    WHERE ac.clienteId = @clienteId AND ac.vigente = 1
                                    ORDER BY ac.fechaInicio DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@clienteId", clienteId);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new ActividadesClientes
                        {
                            id = Convert.ToInt32(reader["id"]),
                            fechaInicio = Convert.ToDateTime(reader["fechaInicio"]),
                            vigente = Convert.ToInt32(reader["vigente"]),
                            actividad = new Actividades
                            {
                                id = Convert.ToInt32(reader["actividadId"]),
                                descripcion = reader["actividadDesc"].ToString(),
                                monto = Convert.ToDecimal(reader["monto"])
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener actividades del cliente: " + ex.Message);
            }

            return lista;
        }

        public List<Periodos> ObtenerPeriodos()
        {
            List<Periodos> lista = new List<Periodos>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT id, descripcion FROM Periodos ORDER BY id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new Periodos
                        {
                            id = Convert.ToInt32(reader["id"]),
                            descripcion = Convert.ToInt32(reader["descripcion"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener periodos: " + ex.Message);
            }

            return lista;
        }
    }
}