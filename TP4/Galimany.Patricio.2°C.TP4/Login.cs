using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;

namespace Galimany.Patricio._2_C.TP4
{
    public partial class Login : Form
    {
        // Atributos
        Thread hilo;
        delegate void Tiempo(int valor);
        private int conteo = 0;
        private string usuario;

        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            hilo = new Thread(new ThreadStart(progreso));
            hilo.Start();
            lblCargando.Text = "Cargando . . .";

            this.usuario = "Alumno";
            tmrTiempo.Start();
        }

        /// <summary>
        /// Cargar del ProgressBar.
        /// </summary>
        private void progreso()
        {
            for (int i = 0; i < 101; i++)
            {
                Tiempo tp = new Tiempo(actualizar);
                this.Invoke(tp, new object[] { i });
                Thread.Sleep(70);
            }
        }
        private void actualizar(int valor)
        {
            pgbCarga.Value = valor;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                hilo = new Thread(new ThreadStart(progreso));
                hilo.Start();
                lblCargando.Text = "Cargando . . .";

                this.usuario = "Alumno";
                tmrTiempo.Start();
            }
        }
        private void btnProfesor_Click(object sender, EventArgs e)
        {
            hilo = new Thread(new ThreadStart(progreso));
            hilo.Start();
            lblCargando.Text = "Cargando . . .";

            this.usuario = "Profesor";
            tmrTiempo.Start();
        }

        /// <summary>
        /// Verifica si el usuario existe y si es asi, abre la ventana de registro.
        /// </summary>
        /// <param name="usuario"> (string) Tipo de usuario </param>
        private void indentificar(string usuario)
        {
            if (UsuarioDAL.auntentificar(txtUsuario.Text, txtContraseña.Text, usuario) > 0)
            {
                this.Hide();

                Registro registro = new Registro(usuario);

                registro.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error en los datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblCargando.Text = "";
            }
        }

        private void btnDirector_Click(object sender, EventArgs e)
        {
            hilo = new Thread(new ThreadStart(progreso));
            hilo.Start();
            lblCargando.Text = "Cargando . . .";

            this.usuario = "Director";
            tmrTiempo.Start();
        }

        private void tmrTiempo_Tick(object sender, EventArgs e)
        {
            conteo++;

            if (pgbCarga.Value == 100)
            {
                tmrTiempo.Enabled = false;
                pgbCarga.Value = 0;
                indentificar(usuario);
            }
        }
    }
}
