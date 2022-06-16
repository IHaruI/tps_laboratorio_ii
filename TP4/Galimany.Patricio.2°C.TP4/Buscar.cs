using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Environment;

namespace Galimany.Patricio._2_C.TP4
{
    public partial class Buscar : Form
    {
        public Buscar()
        {
            InitializeComponent();
        }

        public Alumno alumnoSeleccionado;
        public string archivo = "";
        public Alumno AlumnoSeleccionado
        {
            get { return this.alumnoSeleccionado; }
            set { this.alumnoSeleccionado = value; }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvLista.DataSource = AlumnoDAL.BuscarAlumnos(txtNombre.Text, txtApellido.Text);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvLista.SelectedRows.Count == 1)
            {
                Int64 id = Convert.ToInt64(dgvLista.CurrentRow.Cells[0].Value);
                AlumnoSeleccionado = AlumnoDAL.ObtenerAlumno(id);

                this.Close();
            }
            else
            {
                MessageBox.Show("Aun no ha seleccionado ningun alumno");
            }
        }

        private void btnExportarXML_Click(object sender, EventArgs e)
        {
            ExportarXML();
        }
        private void ExportarXML()
        {
            var ds = new DataSet();
            var dt = new DataTable();

            try
            {
                // Se agrega las columnas de la grilla a el DateTable.
                foreach (var columno in dgvLista.Columns.Cast<DataGridViewColumn>())
                {
                    dt.Columns.Add();
                }

                // Se declara un tipo Object y se le pasara la cantidad de columnas de la grilla.
                // Se llenara en la variable la informacion de la grilla.
                var valorCelda = new object[dgvLista.Columns.Count];

                // Recorrerá las filas de la grilla
                foreach (var row in dgvLista.Rows.Cast<DataGridViewRow>())
                {
                    // Recorrerá cada celda de la fila y lo guardara en la variable valorCelda.
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        valorCelda[i] = row.Cells[i].Value;
                    }
                    // Se guarda la informacion de la variable al DateTable.
                    dt.Rows.Add(valorCelda);
                }
                // Se llenara la DateSet con la informacion del DateTable.
                ds.Tables.Add(dt);

                // Se creara el archivo .XML con la informacion del DataSet.
                string archivo = "Archivo.XML";
                FileStream stream = new FileStream(archivo, FileMode.Create);
                XmlTextWriter xmlWriter = new XmlTextWriter(stream, System.Text.Encoding.Unicode);
                ds.WriteXml(xmlWriter);
                xmlWriter.Close();
                MessageBox.Show("Se ha Exportado el archivo.XML correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnArchivoTXT_Click(object sender, EventArgs e)
        {
            cargarArchivo();
        }
        /// <summary>
        /// Carga archivo .txt, si este no se logra abrir se lanza un excepcion.
        /// </summary>
        public void cargarArchivo()
        {
            TextWriter sw = new StreamWriter("Archivo.txt");

            int rowcount = dgvLista.Rows.Count;

            for (int i = 0; i < rowcount; i++)
            {
                sw.WriteLine(dgvLista.Rows[i].Cells[0].Value.ToString() + "\t"
                             + dgvLista.Rows[i].Cells[1].Value.ToString() + "\t"
                              + dgvLista.Rows[i].Cells[2].Value.ToString() + "\t"
                               + dgvLista.Rows[i].Cells[3].Value.ToString() + "\t");
            }
            sw.Close();
            MessageBox.Show("Datos Exportados correctamente");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
