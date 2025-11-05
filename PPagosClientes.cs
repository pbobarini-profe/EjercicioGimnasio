using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Negocio;
using Modelos;
using EjercicioGimnasio;

namespace Presentacion
{
    public partial class PPagosClientes : Form
    {
        private NPagosClientes negocio = new NPagosClientes();
        private int idPagoSeleccionado = 0;
        private bool modoEdicion = false;

        public PPagosClientes()
        {
            InitializeComponent();
            btnInforme.Enabled = true;
        }

        private void FormPagosClientes_Load(object sender, EventArgs e)
        {
            
            CargarCombos();
            CargarPagos();
            LimpiarCampos();
        }

        

        private void CargarCombos()
        {
            try
            {
                cboCliente.SelectedIndexChanged -= cboCliente_SelectedIndexChanged;
                
                var clientes = negocio.ObtenerClientes();
                cboCliente.DataSource = clientes;
                cboCliente.DisplayMember = "nombre";
                cboCliente.ValueMember = "id";
                cboCliente.SelectedIndex = -1;


                var periodos = negocio.ObtenerPeriodos()
                .Select(p => new { p.id, descripcion = $"{p.descripcion.ToString().Insert(4, "/")}" })
                .ToList();

                cboPeriodo.DataSource = periodos;
                cboPeriodo.DisplayMember = "descripcion";
                cboPeriodo.ValueMember = "id";
                cboPeriodo.SelectedIndex = -1;




                cboActividad.DataSource = null;

                cboActividad.SelectedIndex = -1;
                cboCliente.SelectedIndexChanged += cboCliente_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPagos()
        {
            try
            {
                var pagos = negocio.GetAll();
                dgvPagos.Rows.Clear();

                foreach (var pago in pagos)
                {
                    int index = dgvPagos.Rows.Add();
                    dgvPagos.Rows[index].Cells["id"].Value = pago.id;
                    dgvPagos.Rows[index].Cells["fechaPago"].Value = pago.fechaPago;
                    dgvPagos.Rows[index].Cells["cliente"].Value =
                        $"{pago.cliente.apellido}, {pago.cliente.nombre}";
                    dgvPagos.Rows[index].Cells["actividad"].Value =
                        pago.planCliente.actividad.descripcion;
                    dgvPagos.Rows[index].Cells["periodo"].Value =
                        pago.periodo.descripcion.ToString().Insert(4, "/");
                    dgvPagos.Rows[index].Cells["monto"].Value =
                        pago.planCliente.actividad.monto;
                    dgvPagos.Rows[index].Cells["descripcion"].Value =
                        pago.descripcion;
                }

                lblTotal.Text = $"Total de pagos: {pagos.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pagos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex != -1)
            {
                try
                {
                    int idCliente = Convert.ToInt32(cboCliente.SelectedValue);
                    var actividades = negocio.ObtenerActividadesCliente(idCliente);

                    if (actividades.Count > 0)
                    {
                        
                        var listaParaCombo = actividades.Select(ac => new
                        {
                            id = ac.id, 
                            ActividadMostrada = ac.actividad.descripcion, 
                            MontoActividad = ac.actividad.monto        
                        }).ToList();

                        cboActividad.DataSource = listaParaCombo;
                        cboActividad.DisplayMember = "ActividadMostrada"; 
                        cboActividad.ValueMember = "id";
                        

                        cboActividad.SelectedIndex = -1;
                    }
                    else
                    {
                        cboActividad.DataSource = null;
                        MessageBox.Show("El cliente no tiene actividades vigentes.",
                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar actividades: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActividad.SelectedIndex != -1 && cboActividad.SelectedValue != null)
            {
                
                dynamic actividadSeleccionada = cboActividad.SelectedItem;
                txtMonto.Text = actividadSeleccionada.MontoActividad.ToString("N2");
            }
            else
            {
                txtMonto.Text = "0.00";
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarCampos(true);
            modoEdicion = false;
            idPagoSeleccionado = 0;
            dtpFechaPago.Value = DateTime.Now;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                PagosClientes pago = new PagosClientes
                {
                    id = idPagoSeleccionado,
                    fechaPago = dtpFechaPago.Value,
                    cliente = new Clientes { id = Convert.ToInt32(cboCliente.SelectedValue) },
                    planCliente = new ActividadesClientes { id = Convert.ToInt32(cboActividad.SelectedValue) },
                    periodo = new Periodos { id = Convert.ToInt32(cboPeriodo.SelectedValue) },
                    descripcion = txtDescripcion.Text.Trim()
                };

                string mensaje;
                bool resultado;

                if (modoEdicion)
                {
                    resultado = negocio.Update(pago, out mensaje);
                }
                else
                {
                    resultado = negocio.Insert(pago, out mensaje);
                }

                if (resultado)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPagos();
                    LimpiarCampos();
                    HabilitarCampos(false);
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPagos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un pago para editar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                idPagoSeleccionado = Convert.ToInt32(dgvPagos.SelectedRows[0].Cells["id"].Value);
                var pago = negocio.GetById(idPagoSeleccionado);

                if (pago != null)
                {
                    modoEdicion = true;
                    HabilitarCampos(true);

                    dtpFechaPago.Value = pago.fechaPago;
                    cboCliente.SelectedValue = pago.cliente.id;

                    
                    System.Threading.Thread.Sleep(100);
                    Application.DoEvents();

                    cboActividad.SelectedValue = pago.planCliente.id;
                    cboPeriodo.SelectedValue = pago.periodo.id;
                    txtDescripcion.Text = pago.descripcion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos para editar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPagos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un pago para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Está seguro de eliminar este pago?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dgvPagos.SelectedRows[0].Cells["id"].Value);
                    string mensaje;

                    if (negocio.Delete(id, out mensaje))
                    {
                        MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPagos();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarCampos(false);
            modoEdicion = false;
            idPagoSeleccionado = 0;
        }

        

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            if (cboCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idCliente = Convert.ToInt32(cboCliente.SelectedValue);
                var pagosCliente = negocio.GetByCliente(idCliente);

                dgvPagos.Rows.Clear();

                foreach (var pago in pagosCliente)
                {
                    int index = dgvPagos.Rows.Add();
                    dgvPagos.Rows[index].Cells["id"].Value = pago.id;
                    dgvPagos.Rows[index].Cells["fechaPago"].Value = pago.fechaPago;
                    dgvPagos.Rows[index].Cells["cliente"].Value =
                        $"{pago.cliente.apellido}, {pago.cliente.nombre}";
                    dgvPagos.Rows[index].Cells["actividad"].Value =
                        pago.planCliente.actividad.descripcion;
                    dgvPagos.Rows[index].Cells["periodo"].Value =
                        pago.periodo.descripcion;
                    dgvPagos.Rows[index].Cells["monto"].Value =
                        pago.planCliente.actividad.monto;
                    dgvPagos.Rows[index].Cells["descripcion"].Value =
                        pago.descripcion;
                }

                decimal total = negocio.CalcularTotalPorCliente(idCliente);
                lblTotal.Text = $"Total pagado por el cliente: {total:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (cboCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCliente.Focus();
                return false;
            }

            if (cboActividad.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una actividad.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboActividad.Focus();
                return false;
            }

            if (cboPeriodo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un periodo.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPeriodo.Focus();
                return false;
            }

            if (dtpFechaPago.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de pago no puede ser futura.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFechaPago.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            cboCliente.SelectedIndex = -1;
            cboActividad.DataSource = null;
            cboPeriodo.SelectedIndex = -1;
            dtpFechaPago.Value = DateTime.Now;
            txtDescripcion.Clear();
            txtMonto.Text = "0.00";
            idPagoSeleccionado = 0;
            modoEdicion = false;
        }
        
        private void HabilitarCampos(bool habilitar)
        {
            cboCliente.Enabled = habilitar;
            cboActividad.Enabled = habilitar;
            cboPeriodo.Enabled = habilitar;
            dtpFechaPago.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
            btnInforme.Enabled = habilitar;

            btnNuevo.Enabled = !habilitar;
            
            btnEliminar.Enabled = !habilitar;
        }

        private void dgvPagos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditar_Click(sender, e);
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            CargarPagos();
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            if (dgvPagos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un pago de la lista para generar el informe.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HabilitarCampos(true);
                return;
            }
            int idPago = Convert.ToInt32(dgvPagos.SelectedRows[0].Cells["id"].Value);
            PagosClientes pagoSeleccionado = negocio.GetById(idPago);

            
            PPagoClienteReporte formReporte = new PPagoClienteReporte(pagoSeleccionado);
            formReporte.Show();
        }
    }

    
}