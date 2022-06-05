using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;

namespace Galimany.Patricio._2_C.TP3_
{
    public partial class Form1 : Form
    {
        BindingList<Empleado> MiEmpleados = new BindingList<Empleado>();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cierrar el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Limpia los TextBoxs.
        /// </summary>
        private void LimpiarControles()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtSalario.Clear();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string resultado;

            // Verifica que no este vacio el TextBox de nombre.
            if (txtNombre.Text == "")
            {
                epvError.SetError(txtNombre, "Debe ingresar un nombre");
                txtNombre.Focus();
                return;
            }

            // Verifica que no se haya ingresado numeros o un caracter que no sea letras.
            else if ((resultado = Empleado.VerificacionCadena(txtNombre.Text)) != "")
            {
                MessageBox.Show(resultado, "¡Precaucion!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                epvError.SetError(txtNombre, "Ingrese un nombre valido");
                txtNombre.Focus();
                return;
            }
            epvError.SetError(txtNombre, "");
            
            // Verifica que no este vacio el TextBox de apellido.
            if (txtApellido.Text == "")
            {
                epvError.SetError(txtApellido, "Debe ingresar un apellido");
                txtApellido.Focus();
                return;
            }

            // Verifica que no se haya ingresado numeros o un caracter que no sea letras.
            else if ((resultado = Empleado.VerificacionCadena(txtApellido.Text)) != "")
            {
                MessageBox.Show(resultado, "¡Precaucion!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                epvError.SetError(txtApellido, "Ingrese un apellido valido");
                txtNombre.Focus();
                return;
            }
            epvError.SetError(txtApellido, "");

            // Verifica que no este vacio el TextBox de salario.
            if (txtSalario.Text == "")
            {
                epvError.SetError(txtSalario, "Debe ingresar un salario");
                txtSalario.Focus();
                return;
            }
            epvError.SetError(txtSalario, "");

            // Verifica que no se haya ingresado letras o un caracter que no sea numeros.
            if ((resultado = Empleado.VerificacionSalario(txtSalario.Text)) != "")
            {
                MessageBox.Show(resultado, "¡Precaución!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                epvError.SetError(txtSalario, "Ingrese un salario valido");
                txtSalario.Focus();
                return;
            }
            epvError.SetError(txtSalario, "");

            // Verifica que se haya seleccionado una consulta del ComboBox.
            if (cmbEspecialidad.SelectedItem == null)
            {
                epvError.SetError(cmbEspecialidad, "Debe elegir un tipo de consulta");
                cmbEspecialidad.Focus();
                return;
            }
            epvError.Clear();

            // Verifica si hay contenido en la lista, si no la hay agrega el contenido ya previo escrito en el form.
            if (MiEmpleados.Count == 0)
            {
                MiEmpleados.Add(InstanciaEmpleado());
                LimpiarControles();
                txtNombre.Focus();
                MessageBox.Show("¡Se ha agregado con exito!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            // Si hay contenido, verifica si el nombre y apellido ingresado del form estan en la lista.
            // Si hay repetidos lanza un error, si no lo agrega a la lista.
            else
            {
                int aux = 0;

                foreach (Empleado item in this.MiEmpleados)
                {
                    if (item == txtNombre.Text && txtApellido.Text == item)
                    {
                        MessageBox.Show("Error, Ya existe dicho registro", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        aux = 1;
                    }
                }
                if (aux == 0)
                {
                    MiEmpleados.Add(InstanciaEmpleado());
                    LimpiarControles();
                    txtNombre.Focus();
                    MessageBox.Show("¡Se ha agregado con exito!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        /// <summary>
        /// Instancia un objeto (Empleado).
        /// </summary>
        /// <returns> La instancia del objeto </returns>
        private Empleado InstanciaEmpleado()
        {
            int indice = cmbEspecialidad.SelectedIndex;

            Empleado miEmpleado = new Empleado(txtNombre.Text, txtApellido.Text, Decimal.Parse(txtSalario.Text), dtpFecha.Value, cmbEspecialidad.Items[indice].ToString());

            return miEmpleado;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            Form2 miForm2 = new Form2();
            miForm2.Empleado = MiEmpleados;
            DialogResult resultado = miForm2.ShowDialog();
        }
    }
}
