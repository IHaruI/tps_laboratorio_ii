namespace Galimany.Patricio._2_C.TP3_
{
    partial class Form2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.CNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Csalario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cfecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cconsulta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInformacion = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnSacar = new System.Windows.Forms.Button();
            this.dgvEmpleado = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnArchivo = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImportarXML = new System.Windows.Forms.Button();
            this.btnExportarXML = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleado)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInfo
            // 
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CNombre,
            this.Capellido,
            this.Csalario,
            this.Cfecha,
            this.Cconsulta});
            this.dgvInfo.Location = new System.Drawing.Point(128, 113);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.RowTemplate.Height = 25;
            this.dgvInfo.Size = new System.Drawing.Size(545, 150);
            this.dgvInfo.TabIndex = 0;
            // 
            // CNombre
            // 
            this.CNombre.HeaderText = "Nombre";
            this.CNombre.Name = "CNombre";
            // 
            // Capellido
            // 
            this.Capellido.HeaderText = "Apellido";
            this.Capellido.Name = "Capellido";
            // 
            // Csalario
            // 
            this.Csalario.HeaderText = "Salario";
            this.Csalario.Name = "Csalario";
            // 
            // Cfecha
            // 
            this.Cfecha.HeaderText = "Fecha";
            this.Cfecha.Name = "Cfecha";
            // 
            // Cconsulta
            // 
            this.Cconsulta.HeaderText = "Especialidad";
            this.Cconsulta.Name = "Cconsulta";
            // 
            // btnInformacion
            // 
            this.btnInformacion.Location = new System.Drawing.Point(0, 0);
            this.btnInformacion.Name = "btnInformacion";
            this.btnInformacion.Size = new System.Drawing.Size(75, 23);
            this.btnInformacion.TabIndex = 0;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(221, 342);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(83, 23);
            this.btnBorrar.TabIndex = 0;
            this.btnBorrar.Text = "Eliminar";
            // 
            // btnSacar
            // 
            this.btnSacar.FlatAppearance.BorderSize = 0;
            this.btnSacar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnSacar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSacar.ForeColor = System.Drawing.Color.White;
            this.btnSacar.Location = new System.Drawing.Point(0, 190);
            this.btnSacar.Name = "btnSacar";
            this.btnSacar.Size = new System.Drawing.Size(138, 23);
            this.btnSacar.TabIndex = 1;
            this.btnSacar.Text = "Borrar";
            this.btnSacar.UseVisualStyleBackColor = true;
            this.btnSacar.Click += new System.EventHandler(this.btnSacar_Click);
            // 
            // dgvEmpleado
            // 
            this.dgvEmpleado.AllowUserToAddRows = false;
            this.dgvEmpleado.AllowUserToDeleteRows = false;
            this.dgvEmpleado.AllowUserToResizeColumns = false;
            this.dgvEmpleado.AllowUserToResizeRows = false;
            this.dgvEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmpleado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmpleado.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.dgvEmpleado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEmpleado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmpleado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEmpleado.EnableHeadersVisualStyles = false;
            this.dgvEmpleado.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.dgvEmpleado.Location = new System.Drawing.Point(144, 101);
            this.dgvEmpleado.Name = "dgvEmpleado";
            this.dgvEmpleado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvEmpleado.RowHeadersVisible = false;
            this.dgvEmpleado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.dgvEmpleado.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEmpleado.RowTemplate.Height = 25;
            this.dgvEmpleado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmpleado.Size = new System.Drawing.Size(545, 150);
            this.dgvEmpleado.TabIndex = 2;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(0, 17);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(138, 23);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(269, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lista de Registrados";
            // 
            // btnArchivo
            // 
            this.btnArchivo.FlatAppearance.BorderSize = 0;
            this.btnArchivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchivo.ForeColor = System.Drawing.Color.White;
            this.btnArchivo.Location = new System.Drawing.Point(0, 150);
            this.btnArchivo.Name = "btnArchivo";
            this.btnArchivo.Size = new System.Drawing.Size(138, 23);
            this.btnArchivo.TabIndex = 5;
            this.btnArchivo.Text = "Cargar Archivo TXT";
            this.btnArchivo.UseVisualStyleBackColor = true;
            this.btnArchivo.Click += new System.EventHandler(this.btnArchivo_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(695, 30);
            this.panel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.btnImportarXML);
            this.panel1.Controls.Add(this.btnExportarXML);
            this.panel1.Controls.Add(this.btnVolver);
            this.panel1.Controls.Add(this.btnSacar);
            this.panel1.Controls.Add(this.btnArchivo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 227);
            this.panel1.TabIndex = 8;
            // 
            // btnImportarXML
            // 
            this.btnImportarXML.FlatAppearance.BorderSize = 0;
            this.btnImportarXML.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnImportarXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportarXML.Location = new System.Drawing.Point(0, 61);
            this.btnImportarXML.Name = "btnImportarXML";
            this.btnImportarXML.Size = new System.Drawing.Size(138, 23);
            this.btnImportarXML.TabIndex = 7;
            this.btnImportarXML.Text = "Importar a XML";
            this.btnImportarXML.UseVisualStyleBackColor = true;
            this.btnImportarXML.Click += new System.EventHandler(this.btnImportarXML_Click);
            // 
            // btnExportarXML
            // 
            this.btnExportarXML.FlatAppearance.BorderSize = 0;
            this.btnExportarXML.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnExportarXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarXML.Location = new System.Drawing.Point(0, 106);
            this.btnExportarXML.Name = "btnExportarXML";
            this.btnExportarXML.Size = new System.Drawing.Size(138, 23);
            this.btnExportarXML.TabIndex = 6;
            this.btnExportarXML.Text = "Exportar a XML";
            this.btnExportarXML.UseVisualStyleBackColor = true;
            this.btnExportarXML.Click += new System.EventHandler(this.btnXML_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(695, 257);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvEmpleado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleado)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Csalario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cfecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cconsulta;
        private System.Windows.Forms.Button btnInformacion;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnSacar;
        private System.Windows.Forms.DataGridView dgvEmpleado;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnArchivo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExportarXML;
        private System.Windows.Forms.Button btnImportarXML;
    }
}