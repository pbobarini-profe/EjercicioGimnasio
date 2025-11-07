using EjercicioGimnasio;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 1. ESTE ES EL NAMESPACE CORRECTO
namespace Presentacion
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        // --- Evento para abrir el formulario de Clientes ---
        private void btnGestionClientes_Click(object sender, EventArgs e)
        {
            PClientes formClientes = new PClientes();

            // ShowDialog() es mejor que Show() porque
            // bloquea el menú hasta que cierres la ventana de clientes.
            formClientes.ShowDialog();
        }

        // --- Evento para abrir el formulario de ActividadesClientes ---
        private void btnGestionActividades_Click(object sender, EventArgs e)
        {
            PActividadesClientes formActividades = new PActividadesClientes();
            formActividades.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnGestionActividades_Click_1(object sender, EventArgs e)
        {

        }
    }
}