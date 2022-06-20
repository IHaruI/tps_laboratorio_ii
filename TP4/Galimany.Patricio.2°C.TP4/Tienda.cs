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
    public partial class Tienda : Form
    {
        public Tienda()                       // AUN NO TERMINADO.
        {
            InitializeComponent();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (UsuarioDAL.cargarCompra() > 0)
            {
                MessageBox.Show("Se ha hecho su compra correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
