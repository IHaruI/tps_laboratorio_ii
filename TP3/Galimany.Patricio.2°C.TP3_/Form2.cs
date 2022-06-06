using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Biblioteca;

namespace Galimany.Patricio._2_C.TP3_
{
    public partial class Form2 : Form
    {
        BindingList<Empleado> empleado;
        public string archivo = "";

        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            dgvEmpleado.DataSource = null;
            dgvEmpleado.DataSource = empleado.ToList();
        }
        /// <summary>
        /// Propiedad de Empleado.
        /// </summary>
        public BindingList<Empleado> Empleado
        {
            set { this.empleado = value; }
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            // Elimina el registro seleccionado del DataGridView. Si no hay empleados cargados lanza un mensaje.
            if (empleado.Count > 0)
            {
                empleado.RemoveAt(dgvEmpleado.CurrentRow.Index);
                dgvEmpleado.DataSource = null;
                dgvEmpleado.DataSource = empleado.ToList();
                MessageBox.Show("¡Se elimino el registro!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("¡La lista esta vacia!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            cargarArchivo();
        }

        /// <summary>
        /// Carga archivo .txt, si este no se logra abrir se lanza un excepcion.
        /// </summary>
        public void cargarArchivo()
        {
            try
            {
                this.openFileDialog1.ShowDialog();

                if (!string.IsNullOrEmpty(this.openFileDialog1.FileName))
                {
                    archivo = this.openFileDialog1.FileName;
                    lecturaArchivo(dgvEmpleado, ',', archivo);
                }
            }
            catch (FileNotFoundException ex)
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Lee el archivo y lo agrega a la lista para luego mostrarlo al DataGridView.
        /// </summary>
        /// <param name="tabla"> (DataGirdView) Recibe la tabla </param>
        /// <param name="caracter"> (char) Recibe el delimitado </param>
        /// <param name="ruta"> (string) recibe la ruta del archivo </param>
        public void lecturaArchivo(DataGridView tabla, char caracter, string ruta)
        {
            StreamReader objReader = new StreamReader(ruta);
            string sLine = "";
            int fila = 0;
            tabla.AllowUserToAddRows = false;

            do
            {
                sLine = objReader.ReadLine();

                if ((sLine != null))
                {
                    if (fila == 0)
                    {
                        string[] arreglo = sLine.Split(caracter);

                        Empleado e = new Empleado(arreglo[0], arreglo[1], decimal.Parse(arreglo[2]), DateTime.Parse(arreglo[3]), arreglo[4]);

                        empleado.Add(e);

                        dgvEmpleado.DataSource = null;
                        dgvEmpleado.DataSource = empleado.ToList();
                    }
                }
            }while (!(sLine == null));

            objReader.Close();
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            ExportarXML();
        }

        /// <summary>
        /// Exporta un archivo XML.
        /// </summary>
        private void ExportarXML()
        {
            var ds = new DataSet();
            var dt = new DataTable();

            try
            {
                // Se agrega las columnas de la grilla a el DateTable.
                foreach (var columno in dgvEmpleado.Columns.Cast<DataGridViewColumn>())
                {
                    dt.Columns.Add();
                }

                // Se declara un tipo Object y se le pasara la cantidad de columnas de la grilla.
                // Se llenara en la variable la informacion de la grilla.
                var valorCelda = new object[dgvEmpleado.Columns.Count];

                // Recorrerá las filas de la grilla
                foreach (var row in dgvEmpleado.Rows.Cast<DataGridViewRow>())
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

        private void btnImportarXML_Click(object sender, EventArgs e)
        {
            llamarXML();
        }

        /// <summary>
        /// Importa un archivo XML.
        /// </summary>
        private void llamarXML()
        {
            string nombre = "Archivo.XML";

            // Se listara la informacion del archivo.XML.
            try
            {
                if (File.Exists(nombre))
                {
                    DataTable dt; 
                    DataSet ds = new DataSet();

                    ds.ReadXml(nombre);
                    dt = ds.Tables[0];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Empleado e = new Empleado(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), decimal.Parse((string)dt.Rows[i][2]), DateTime.Parse((string)dt.Rows[i][3]), dt.Rows[i][4].ToString());

                        empleado.Add(e);

                        dgvEmpleado.DataSource = null;
                        dgvEmpleado.DataSource = empleado.ToList();
                    }
                }
                MessageBox.Show("Se ha Importado el archivo.XML correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(IndexOutOfRangeException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
