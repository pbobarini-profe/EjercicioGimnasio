using System;
using System.Collections.Generic;
using Datos;
using Modelos;

namespace Negocio
{
    public class NPagosClientes
    {
        private DPagosClientes datosPagos = new DPagosClientes();

        
        private string ValidarPago(PagosClientes pago)
        {
            if (pago.cliente == null || pago.cliente.id <= 0)
                return "Debe seleccionar un cliente válido.";

            if (pago.planCliente == null || pago.planCliente.id <= 0)
                return "Debe seleccionar un plan/actividad válido.";

            if (pago.periodo == null || pago.periodo.id <= 0)
                return "Debe seleccionar un periodo válido.";

            if (pago.fechaPago == DateTime.MinValue)
                return "Debe ingresar una fecha de pago válida.";

            if (pago.fechaPago > DateTime.Now)
                return "La fecha de pago no puede ser futura.";

            return string.Empty;
        }

        
        public bool Insert(PagosClientes pago, out string mensaje)
        {
            mensaje = ValidarPago(pago);

            if (!string.IsNullOrEmpty(mensaje))
                return false;

            try
            {
                bool resultado = datosPagos.Insert(pago);
                if (resultado)
                    mensaje = "Pago registrado exitosamente.";
                else
                    mensaje = "No se pudo registrar el pago.";

                return resultado;
            }
            catch (Exception ex)
            {
                mensaje = "Error al registrar pago: " + ex.Message;
                return false;
            }
        }

        
        public bool Update(PagosClientes pago, out string mensaje)
        {
            if (pago.id <= 0)
            {
                mensaje = "ID de pago inválido.";
                return false;
            }

            mensaje = ValidarPago(pago);

            if (!string.IsNullOrEmpty(mensaje))
                return false;

            try
            {
                bool resultado = datosPagos.Update(pago);
                if (resultado)
                    mensaje = "Pago actualizado exitosamente.";
                else
                    mensaje = "No se pudo actualizar el pago.";

                return resultado;
            }
            catch (Exception ex)
            {
                mensaje = "Error al actualizar pago: " + ex.Message;
                return false;
            }
        }

        // Eliminar pago
        public bool Delete(int id, out string mensaje)
        {
            if (id <= 0)
            {
                mensaje = "ID de pago inválido.";
                return false;
            }

            try
            {
                bool resultado = datosPagos.Delete(id);
                if (resultado)
                    mensaje = "Pago eliminado exitosamente.";
                else
                    mensaje = "No se pudo eliminar el pago.";

                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public List<PagosClientes> GetAll()
        {
            try
            {
                return datosPagos.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener pagos: " + ex.Message);
            }
        }

        
        public PagosClientes GetById(int id)
        {
            if (id <= 0)
                return null;

            try
            {
                return datosPagos.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener pago: " + ex.Message);
            }
        }

        
        public List<PagosClientes> GetByCliente(int idCliente)
        {
            if (idCliente <= 0)
                return new List<PagosClientes>();

            try
            {
                return datosPagos.GetByCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener pagos del cliente: " + ex.Message);
            }
        }

        
        public decimal CalcularTotalPorCliente(int idCliente)
        {
            try
            {
                var pagos = datosPagos.GetByCliente(idCliente);
                decimal total = 0;

                foreach (var pago in pagos)
                {
                    if (pago.planCliente != null && pago.planCliente.actividad != null)
                    {
                        total += pago.planCliente.actividad.monto;
                    }
                }

                return total;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular total: " + ex.Message);
            }
        }

        
        public List<Clientes> ObtenerClientes()
        {
            try
            {
                return datosPagos.ObtenerClientes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener clientes: " + ex.Message);
            }
        }

        
        public List<ActividadesClientes> ObtenerActividadesCliente(int idCliente)
        {
            try
            {
                return datosPagos.ObtenerActividadesCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener actividades: " + ex.Message);
            }
        }

        public List<Periodos> ObtenerPeriodos()
        {
            try
            {
                return datosPagos.ObtenerPeriodos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener periodos: " + ex.Message);
            }
        }



    }
}