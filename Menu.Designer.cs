
namespace Presentacion
{
    partial class Menu
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
            this.btnGestionClientes = new System.Windows.Forms.Button();
            this.btnGestionActividades = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGestionClientes
            // 
            this.btnGestionClientes.Location = new System.Drawing.Point(136, 83);
            this.btnGestionClientes.Name = "btnGestionClientes";
            this.btnGestionClientes.Size = new System.Drawing.Size(138, 23);
            this.btnGestionClientes.TabIndex = 0;
            this.btnGestionClientes.Text = "Clientes";
            this.btnGestionClientes.UseVisualStyleBackColor = true;
            this.btnGestionClientes.Click += new System.EventHandler(this.btnGestionClientes_Click);
            // 
            // btnGestionActividades
            // 
            this.btnGestionActividades.Location = new System.Drawing.Point(328, 83);
            this.btnGestionActividades.Name = "btnGestionActividades";
            this.btnGestionActividades.Size = new System.Drawing.Size(178, 23);
            this.btnGestionActividades.TabIndex = 1;
            this.btnGestionActividades.Text = "ActividadClientes";
            this.btnGestionActividades.UseVisualStyleBackColor = true;
            this.btnGestionActividades.Click += new System.EventHandler(this.btnGestionActividades_Click_1);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 279);
            this.Controls.Add(this.btnGestionActividades);
            this.Controls.Add(this.btnGestionClientes);
            this.Name = "Menu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGestionClientes;
        private System.Windows.Forms.Button btnGestionActividades;
    }
}

