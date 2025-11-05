using Microsoft.Reporting.WinForms;
using Modelos;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EjercicioGimnasio
{
    public partial class PPagoClienteReporte : Form
    {
        private PagosClientes pagoClienteSeleccionado;

        public PPagoClienteReporte(PagosClientes p)
        {
            InitializeComponent();
            pagoClienteSeleccionado = p;
        }

        private void PPagoClienteReporte_Load(object sender, EventArgs e)
        {
            
                NPagosClientes nPagosClientes = new NPagosClientes();
                PagosClientes detalle = nPagosClientes.GetById(pagoClienteSeleccionado.id);

               
                List<DtoInformePagos> lista = new List<DtoInformePagos>
                {
                    new DtoInformePagos
                    {
                        idReporte = detalle.id,
                        IdPago = detalle.id,
                        FechaPago = detalle.fechaPago,
                        NombreCliente = detalle.cliente.nombre + " " + detalle.cliente.apellido,
                        PlanCliente = detalle.planCliente.actividad.descripcion,
                        Descripcion = detalle.descripcion,
                        Periodo = detalle.periodo.descripcion.ToString().Insert(4, "/"),
                        Monto = detalle.planCliente.actividad.monto
                    }
                };

                
                reportViewer1.LocalReport.DataSources.Clear();
              

                reportViewer1.LocalReport.DataSources.Add(
                    new ReportDataSource("DataSet1", lista));

                
                reportViewer1.RefreshReport();
            }
           
        }

       
    }

