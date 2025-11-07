using Modelos;      
using Negocio;      
using System;
using System.Collections.Generic;
using System.Windows.Forms; 

namespace Presentacion
{
    
    
    public partial class PClientes : Form
    {
        List<Clientes> listaDeClientes = new List<Clientes>(); 
        Clientes clienteSeleccionado = new Clientes();        
        NClientes negocioClientes = new NClientes();          

        public PClientes()
        {
            InitializeComponent(); 
        }

        private void PClientes_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                CargarListaClientes();   
                CargarComboGenero();    
            }
        }

       
        private void CargarListaClientes()
        {
            try
            {
                listaDeClientes = negocioClientes.Get(); 
                dgvClientes.DataSource = null;           
                dgvClientes.DataSource = listaDeClientes; 
                dgvClientes.Columns["id"].Visible = false; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lista: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarComboGenero()
        {
            
            var opcionesGenero = new List<Tuple<int, string>>
            {
                new Tuple<int, string>(1, "Hombre"),
                new Tuple<int, string>(2, "Mujer")
            };
            cmbGenero.DataSource = opcionesGenero;  
            cmbGenero.DisplayMember = "Item2";     
            cmbGenero.ValueMember = "Item1";        
        }

        private void LimpiarFormulario()
        {
            txtDni.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            cmbGenero.SelectedIndex = 0;
            dtpFechaNacimiento.Value = DateTime.Now;
            clienteSeleccionado = new Clientes(); 
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                clienteSeleccionado = (Clientes)dgvClientes.CurrentRow.DataBoundItem;

                if (clienteSeleccionado != null)
                {
                    txtDni.Text = clienteSeleccionado.dni;
                    txtNombre.Text = clienteSeleccionado.nombre;
                    txtApellido.Text = clienteSeleccionado.apellido;
                    txtTelefono.Text = clienteSeleccionado.telefono;
                    cmbGenero.SelectedValue = clienteSeleccionado.genero;
                    dtpFechaNacimiento.Value = clienteSeleccionado.fechaNacimiento;
                }
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Clientes nuevoCliente = new Clientes
                {
                    dni = txtDni.Text,
                    nombre = txtNombre.Text,
                    apellido = txtApellido.Text,
                    telefono = txtTelefono.Text,
                    genero = (int)cmbGenero.SelectedValue,
                    fechaNacimiento = dtpFechaNacimiento.Value
                };

                negocioClientes.Create(nuevoCliente); 
                MessageBox.Show("Cliente guardado con éxito.", "Éxito");
                CargarListaClientes();  
                LimpiarFormulario();    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- BOTÓN MODIFICAR ---
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado == null || clienteSeleccionado.id <= 0)
            {
                MessageBox.Show("Debe seleccionar un cliente de la lista.", "Advertencia");
                return;
            }

            try
            {
                clienteSeleccionado.dni = txtDni.Text;
                clienteSeleccionado.nombre = txtNombre.Text;
                clienteSeleccionado.apellido = txtApellido.Text;
                clienteSeleccionado.telefono = txtTelefono.Text;
                clienteSeleccionado.genero = (int)cmbGenero.SelectedValue;
                clienteSeleccionado.fechaNacimiento = dtpFechaNacimiento.Value;

                negocioClientes.Update(clienteSeleccionado); 
                MessageBox.Show("Cliente modificado con éxito.", "Éxito");
                CargarListaClientes();  
                LimpiarFormulario();    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado == null || clienteSeleccionado.id <= 0)
            {
                MessageBox.Show("Debe seleccionar un cliente de la lista.", "Advertencia");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                $"¿Seguro que desea eliminar a {clienteSeleccionado.nombre}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    negocioClientes.Delete(clienteSeleccionado.id); 
                    MessageBox.Show("Cliente eliminado.", "Éxito");
                    CargarListaClientes(); 
                    LimpiarFormulario();   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
