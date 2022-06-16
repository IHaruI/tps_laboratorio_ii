using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galimany.Patricio._2_C.TP4
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        public Alumno alumnoActual;
        public Alumno AlumnoActual
        {
            get { return this.alumnoActual; }
            set { this.alumnoActual = value; }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string fecha = txtFecha.Text.Trim();

            if (txtNombre.Text == "" || txtApellido.Text == "" || txtDireccion.Text == "" || fecha.Length < 5)
            {
                MessageBox.Show("Error, debe llenar todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Alumno alumno = new Alumno();
            
                alumno.Nombre = txtNombre.Text;
                alumno.Apellido = txtApellido.Text;
                alumno.Direccion = txtDireccion.Text;
                alumno.FechaDeNacimiento = txtFecha.Text;

                int resultado = AlumnoDAL.Agregar(alumno);

                if (resultado > 0)
                {
                    MessageBox.Show("Datos guardados correctamente", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Error al guardar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar buscar = new Buscar();
            buscar.ShowDialog();

            if (buscar.AlumnoSeleccionado != null)
            {
                AlumnoActual = buscar.AlumnoSeleccionado;

                txtNombre.Text = buscar.AlumnoSeleccionado.Nombre;
                txtApellido.Text = buscar.AlumnoSeleccionado.Apellido;
                txtDireccion.Text = buscar.AlumnoSeleccionado.Direccion;
                txtFecha.Text = buscar.AlumnoSeleccionado.FechaDeNacimiento;

                btnGuardar.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();

            alumno.Nombre = txtNombre.Text;
            alumno.Apellido = txtApellido.Text;
            alumno.Direccion = txtDireccion.Text;
            alumno.FechaDeNacimiento = txtFecha.Text;
            alumno.Id = alumnoActual.Id;

            int resultado = AlumnoDAL.Modificar(alumno);

            if (resultado > 0)
            {
                MessageBox.Show("Alumno modificado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiar();

                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnGuardar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error al modificar el alumno", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        void limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtFecha.Clear();
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro que desea eliminar el alumno?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int resultado = AlumnoDAL.Eliminar(AlumnoActual.Id);

                if (resultado > 0)
                {
                    MessageBox.Show("Alumno eliminado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    limpiar();
                    
                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = false;
                    btnGuardar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Error al eliminar el alumno", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Se ha cancelado la eliminacion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ptbImagen_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Show();
        }

        private void Registro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
