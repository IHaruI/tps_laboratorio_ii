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

namespace Galimany.Patricio._2_C.TP4
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Identificar("Alumno");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (UsuarioDAL.Auntentificar(txtUsuario.Text, txtContraseña.Text, "Alumno") > 0)
                {
                    this.Hide();

                    Registro registro = new Registro("Alumno");

                    registro.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Error en los datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnProfesor_Click(object sender, EventArgs e)
        {
            Identificar("Profesor");
        }
        private void Identificar(string usuario)
        {
            if (UsuarioDAL.Auntentificar(txtUsuario.Text, txtContraseña.Text, usuario) > 0)
            {
                this.Hide();

                Registro registro = new Registro(usuario);

                registro.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error en los datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDirector_Click(object sender, EventArgs e)
        {
            Identificar("Director");
        }
    }
}
