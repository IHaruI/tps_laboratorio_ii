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
using Biblioteca;

namespace Galimany.Patricio._2_C.TP4
{
    public partial class Buscar : Form
    {
        public Buscar(string accesos)
        {
            InitializeComponent();
            privilegios(accesos);
        }

        // Atributos
        private Alumno alumnoSeleccionado;
        private Profesor profesorSeleccionado;
        
        // Getters y Setters
        public Alumno AlumnoSeleccionado
        {
            get { return this.alumnoSeleccionado; }
            set { this.alumnoSeleccionado = value; }
        }
        public Profesor ProfesorSeleccionado 
        {
            get { return this.profesorSeleccionado; }
            set { this.profesorSeleccionado = value; }
        }

        /// <summary>
        /// Privilegios que temdram los usuarios.
        /// </summary>
        /// <param name="accesos"> (string) Tipo de usuario </param>
        private void privilegios(string accesos)
        {
            if (accesos == "Alumno")
            {
                btnArchivoTXT.Enabled = false;
                btnExportarXML.Enabled = false;
            }
            else if (accesos == "Profesor")
            {
                btnArchivoTXT.Enabled = false;
                btnExportarXML.Enabled = false;
            }
            else if (accesos == "Director")
            {
                btnArchivoTXT.Enabled = true;
                btnExportarXML.Enabled = true;
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" || txtApellido.Text != "")
            {
                dgvLista.DataSource = null;
                dgvLista.DataSource = AlumnoDAL<Alumno>.buscarAlumnos(txtNombre.Text, txtApellido.Text);
                lblPersona.Text = "Alumnos:";
            }
            else
            {
                MessageBox.Show("Coloque un nombre y apellido para buscar", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvLista.SelectedRows.Count == 1 && lblPersona.Text == "Alumnos:")
            {
                Int64 id = Convert.ToInt64(dgvLista.CurrentRow.Cells[0].Value);
                AlumnoSeleccionado = AlumnoDAL<Alumno>.obtenerAlumno(id);

                this.Close();
            }
            else if (lblPersona.Text == "Profesores:" && btnExportarXML.Enabled == true && dgvLista.SelectedRows.Count == 1)
            {
                Int64 id = Convert.ToInt64(dgvLista.CurrentRow.Cells[1].Value);
                ProfesorSeleccionado = AlumnoDAL<Profesor>.obtenerProfesor(id);

                this.Close();
            }
            else
            {
                MessageBox.Show("Aun no ha seleccionado ningun alumno", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportarXML_Click(object sender, EventArgs e)
        {
            exportarXML();
        }

        /// <summary>
        /// Guarda los datos del DataGridView en un archivo.XML
        /// </summary>
        private void exportarXML()
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
                MessageBox.Show("Se ha Exportado el archivo.XML correctamente", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void cargarArchivo()
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
            MessageBox.Show("Datos Exportados correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" || txtApellido.Text != "")
            {
                dgvLista.DataSource = null;
                dgvLista.DataSource = AlumnoDAL<Profesor>.buscarProfesor(txtNombre.Text, txtApellido.Text);
                lblPersona.Text = "Profesores:";
            }
            else
            {
                MessageBox.Show("Coloque un nombre y apellido para buscar", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
