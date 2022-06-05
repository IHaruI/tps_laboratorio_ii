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
            dgvCliente.DataSource = null;
            dgvCliente.DataSource = empleado.ToList();
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
                empleado.RemoveAt(dgvCliente.CurrentRow.Index);
                dgvCliente.DataSource = null;
                dgvCliente.DataSource = empleado.ToList();
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
                    lecturaArchivo(dgvCliente, ',', archivo);
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

                        dgvCliente.DataSource = null;
                        dgvCliente.DataSource = empleado.ToList();
                    }
                }
            }while (!(sLine == null));

            objReader.Close();
        }
    }
}
