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
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registro("Alumno");
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistroProfesor_Click(object sender, EventArgs e)
        {
            Registro("Profesor");
        }
        private void Registro(string usuario)
        {
            if (txtContraseña.Text == txtConfirmar.Text)
            {
                if (UsuarioDAL.CrearCuentas(txtUsuario.Text, txtContraseña.Text, usuario) > 0)
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
