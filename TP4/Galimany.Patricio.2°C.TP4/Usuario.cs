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
    // Delegado
    public delegate bool Crear(int resultado);

    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            registro("Alumno");
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistroProfesor_Click(object sender, EventArgs e)
        {
            registro("Profesor");
        }

        /// <summary>
        /// registra un tipo de usuario.
        /// </summary>
        /// <param name="usuario"> (string) Tipo de usuario </param>
        private void registro(string usuario)
        {
            if (txtContraseña.Text == txtConfirmar.Text)
            {
                // Aplicacion de exprecion lambda.
                Crear crear = new Crear(resultado => resultado > 0);

                if (crear(UsuarioDAL.crearCuentas(txtUsuario.Text, txtContraseña.Text, usuario)))
                {
                    MessageBox.Show("Se ha creado la cuenta correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al crear la cuenta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
