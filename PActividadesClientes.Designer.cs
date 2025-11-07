namespace Datos
{
    partial class PActividadesClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gimnasioDataSet1 = new EjercicioGimnasio.GimnasioDataSet1();
            this.actividadesClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.actividadesClientesTableAdapter = new EjercicioGimnasio.GimnasioDataSet1TableAdapters.ActividadesClientesTableAdapter();
            this.gimnasioDataSet2 = new EjercicioGimnasio.GimnasioDataSet2();
            this.actividadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.actividadesTableAdapter = new EjercicioGimnasio.GimnasioDataSet2TableAdapters.ActividadesTableAdapter();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.gimnasioDataSet3 = new EjercicioGimnasio.GimnasioDataSet3();
            this.actividadesClientesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.actividadesClientesTableAdapter1 = new EjercicioGimnasio.GimnasioDataSet3TableAdapters.ActividadesClientesTableAdapter();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actividadIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaInicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vigenteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gimnasioDataSet4 = new EjercicioGimnasio.GimnasioDataSet4();
            this.actividadesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.actividadesTableAdapter1 = new EjercicioGimnasio.GimnasioDataSet4TableAdapters.ActividadesTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoActividadIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gimnasioDataSet5 = new EjercicioGimnasio.GimnasioDataSet5();
            this.clientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientesTableAdapter = new EjercicioGimnasio.GimnasioDataSet5TableAdapters.ClientesTableAdapter();
            this.fillToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.gimnasioDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actividadesClientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gimnasioDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actividadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gimnasioDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actividadesClientesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gimnasioDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actividadesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gimnasioDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).BeginInit();
            this.fillToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gimnasioDataSet1
            // 
            this.gimnasioDataSet1.DataSetName = "GimnasioDataSet1";
            this.gimnasioDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // actividadesClientesBindingSource
            // 
            this.actividadesClientesBindingSource.DataMember = "ActividadesClientes";
            this.actividadesClientesBindingSource.DataSource = this.gimnasioDataSet1;
            // 
            // actividadesClientesTableAdapter
            // 
            this.actividadesClientesTableAdapter.ClearBeforeFill = true;
            // 
            // gimnasioDataSet2
            // 
            this.gimnasioDataSet2.DataSetName = "GimnasioDataSet2";
            this.gimnasioDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // actividadesBindingSource
            // 
            this.actividadesBindingSource.DataMember = "Actividades";
            this.actividadesBindingSource.DataSource = this.gimnasioDataSet2;
            // 
            // actividadesTableAdapter
            // 
            this.actividadesTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.actividadIdDataGridViewTextBoxColumn,
            this.clienteIdDataGridViewTextBoxColumn,
            this.fechaInicioDataGridViewTextBoxColumn,
            this.vigenteDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.actividadesClientesBindingSource1;
            this.dataGridView2.Location = new System.Drawing.Point(21, 256);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(572, 150);
            this.dataGridView2.TabIndex = 1;
            // 
            // gimnasioDataSet3
            // 
            this.gimnasioDataSet3.DataSetName = "GimnasioDataSet3";
            this.gimnasioDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // actividadesClientesBindingSource1
            // 
            this.actividadesClientesBindingSource1.DataMember = "ActividadesClientes";
            this.actividadesClientesBindingSource1.DataSource = this.gimnasioDataSet3;
            // 
            // actividadesClientesTableAdapter1
            // 
            this.actividadesClientesTableAdapter1.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // actividadIdDataGridViewTextBoxColumn
            // 
            this.actividadIdDataGridViewTextBoxColumn.DataPropertyName = "actividadId";
            this.actividadIdDataGridViewTextBoxColumn.HeaderText = "actividadId";
            this.actividadIdDataGridViewTextBoxColumn.Name = "actividadIdDataGridViewTextBoxColumn";
            // 
            // clienteIdDataGridViewTextBoxColumn
            // 
            this.clienteIdDataGridViewTextBoxColumn.DataPropertyName = "clienteId";
            this.clienteIdDataGridViewTextBoxColumn.HeaderText = "clienteId";
            this.clienteIdDataGridViewTextBoxColumn.Name = "clienteIdDataGridViewTextBoxColumn";
            // 
            // fechaInicioDataGridViewTextBoxColumn
            // 
            this.fechaInicioDataGridViewTextBoxColumn.DataPropertyName = "fechaInicio";
            this.fechaInicioDataGridViewTextBoxColumn.HeaderText = "fechaInicio";
            this.fechaInicioDataGridViewTextBoxColumn.Name = "fechaInicioDataGridViewTextBoxColumn";
            // 
            // vigenteDataGridViewTextBoxColumn
            // 
            this.vigenteDataGridViewTextBoxColumn.DataPropertyName = "vigente";
            this.vigenteDataGridViewTextBoxColumn.HeaderText = "vigente";
            this.vigenteDataGridViewTextBoxColumn.Name = "vigenteDataGridViewTextBoxColumn";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.tipoActividadIdDataGridViewTextBoxColumn,
            this.montoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.actividadesBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(611, 256);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(451, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // gimnasioDataSet4
            // 
            this.gimnasioDataSet4.DataSetName = "GimnasioDataSet4";
            this.gimnasioDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // actividadesBindingSource1
            // 
            this.actividadesBindingSource1.DataMember = "Actividades";
            this.actividadesBindingSource1.DataSource = this.gimnasioDataSet4;
            // 
            // actividadesTableAdapter1
            // 
            this.actividadesTableAdapter1.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            // 
            // tipoActividadIdDataGridViewTextBoxColumn
            // 
            this.tipoActividadIdDataGridViewTextBoxColumn.DataPropertyName = "tipoActividadId";
            this.tipoActividadIdDataGridViewTextBoxColumn.HeaderText = "tipoActividadId";
            this.tipoActividadIdDataGridViewTextBoxColumn.Name = "tipoActividadIdDataGridViewTextBoxColumn";
            // 
            // montoDataGridViewTextBoxColumn
            // 
            this.montoDataGridViewTextBoxColumn.DataPropertyName = "monto";
            this.montoDataGridViewTextBoxColumn.HeaderText = "monto";
            this.montoDataGridViewTextBoxColumn.Name = "montoDataGridViewTextBoxColumn";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(186, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(50, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Actividad";
            // 
            // gimnasioDataSet5
            // 
            this.gimnasioDataSet5.DataSetName = "GimnasioDataSet5";
            this.gimnasioDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clientesBindingSource
            // 
            this.clientesBindingSource.DataMember = "Clientes";
            this.clientesBindingSource.DataSource = this.gimnasioDataSet5;
            // 
            // clientesTableAdapter
            // 
            this.clientesTableAdapter.ClearBeforeFill = true;
            // 
            // fillToolStrip
            // 
            this.fillToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillToolStripButton});
            this.fillToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillToolStrip.Name = "fillToolStrip";
            this.fillToolStrip.Size = new System.Drawing.Size(1096, 25);
            this.fillToolStrip.TabIndex = 6;
            this.fillToolStrip.Text = "fillToolStrip";
            // 
            // fillToolStripButton
            // 
            this.fillToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillToolStripButton.Name = "fillToolStripButton";
            this.fillToolStripButton.Size = new System.Drawing.Size(26, 22);
            this.fillToolStripButton.Text = "Fill";
            this.fillToolStripButton.Click += new System.EventHandler(this.fillToolStripButton_Click);
            // 
            // PActividadesClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 467);
            this.Controls.Add(this.fillToolStrip);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridView2);
            this.Name = "PActividadesClientes";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.PActividadesClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gimnasioDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actividadesClientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gimnasioDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actividadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gimnasioDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actividadesClientesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gimnasioDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actividadesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gimnasioDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
            this.fillToolStrip.ResumeLayout(false);
            this.fillToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GimnasioDataSet1 gimnasioDataSet1;
        private System.Windows.Forms.BindingSource actividadesClientesBindingSource;
        private GimnasioDataSet1TableAdapters.ActividadesClientesTableAdapter actividadesClientesTableAdapter;
        private GimnasioDataSet2 gimnasioDataSet2;
        private System.Windows.Forms.BindingSource actividadesBindingSource;
        private GimnasioDataSet2TableAdapters.ActividadesTableAdapter actividadesTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView2;
        private GimnasioDataSet3 gimnasioDataSet3;
        private System.Windows.Forms.BindingSource actividadesClientesBindingSource1;
        private GimnasioDataSet3TableAdapters.ActividadesClientesTableAdapter actividadesClientesTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn actividadIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaInicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vigenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private GimnasioDataSet4 gimnasioDataSet4;
        private System.Windows.Forms.BindingSource actividadesBindingSource1;
        private GimnasioDataSet4TableAdapters.ActividadesTableAdapter actividadesTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoActividadIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private GimnasioDataSet5 gimnasioDataSet5;
        private System.Windows.Forms.BindingSource clientesBindingSource;
        private GimnasioDataSet5TableAdapters.ClientesTableAdapter clientesTableAdapter;
        private System.Windows.Forms.ToolStrip fillToolStrip;
        private System.Windows.Forms.ToolStripButton fillToolStripButton;
    }
}