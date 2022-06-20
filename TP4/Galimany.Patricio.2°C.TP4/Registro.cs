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
    public delegate int Eliminar(Int64 id);
    
    public partial class Registro : Form
    {
        public Registro(string usuario)
        {
            InitializeComponent();

            accesos = privilegios(usuario);
        }
        
        // Atributos
        private string accesos;
        private Alumno alumnoActual;
        private Profesor profesorActual;

        // Getters y Setters
        public Alumno AlumnoActual
        {
            get { return this.alumnoActual; }
            set { this.alumnoActual = value; }
        }

        public Profesor ProfesorActual 
        {
            get { return this.profesorActual; } 
            set { this.profesorActual = value; }
        }

        /// <summary>
        /// Privilegios de tipo de usuario
        /// </summary>
        /// <param name="usuarios"> (string) Tipo de usuario </param>
        /// <returns> El usuario </returns>
        private string privilegios(string usuarios)
        {
            string retorno = string.Empty;

            if (usuarios == "Alumno")
            {
                btnGuardarProfesor.Enabled = false;
                btnGuardarAlumno.Enabled = false;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtDireccion.Enabled = false;
                txtFecha.Enabled = false;
                txtSalario.Enabled = false;
                retorno = usuarios;
            }
            else if (usuarios == "Profesor")
            {
                btnGuardarProfesor.Enabled = false;
                txtSalario.Enabled = false;

                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                retorno = usuarios;
            }
            else if (usuarios == "Director")
            {
                btnGuardarAlumno.Enabled = false;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                lblCreacion.Text = "Crear usuario precionando la imagen";
                retorno = usuarios;
            }
            return retorno;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (verificacion() == 1)
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

                    // Aplicacion de Genericos
                    AlumnoDAL<Alumno> alumnoDAL = new AlumnoDAL<Alumno>(4);

                    alumnoDAL.agregar(new Alumno(alumno.Nombre));
                    alumnoDAL.agregar(new Alumno(alumno.Apellido));
                    alumnoDAL.agregar(new Alumno(alumno.Direccion));
                    alumnoDAL.agregar(new Alumno(alumno.FechaDeNacimiento));

                    Alumno nombreA = alumnoDAL.getElemento(0);
                    Alumno apellidoA = alumnoDAL.getElemento(1);
                    Alumno direccionA = alumnoDAL.getElemento(2);
                    Alumno fechaA = alumnoDAL.getElemento(3);

                    if (AlumnoDAL<Alumno>.agregarAlumno(nombreA.Datos(), apellidoA.Datos(), direccionA.Datos(), fechaA.Datos()) > 0)
                    {
                        MessageBox.Show("Datos guardados correctamente", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        epvError.SetError(txtFecha, "Verifique el mes, dia y año");
                        txtFecha.Focus();
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar buscar = new Buscar(accesos);
            buscar.ShowDialog();

            if (buscar.AlumnoSeleccionado != null)
            {
                AlumnoActual = buscar.AlumnoSeleccionado;

                txtNombre.Text = buscar.AlumnoSeleccionado.Nombre;
                txtApellido.Text = buscar.AlumnoSeleccionado.Apellido;
                txtDireccion.Text = buscar.AlumnoSeleccionado.Direccion;
                txtFecha.Text = buscar.AlumnoSeleccionado.FechaDeNacimiento;

                btnGuardarAlumno.Enabled = false;

                if (accesos == "Profesor")
                {
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
                else if (accesos == "Director")
                {
                    btnGuardarProfesor.Enabled = false;
                    btnModificar.Enabled= true;
                    btnEliminar.Enabled = true;
                    txtSalario.Clear();
                    txtSalario.Enabled = false;
                }
            }
            else if (buscar.ProfesorSeleccionado != null)
            {
                ProfesorActual = buscar.ProfesorSeleccionado;

                txtNombre.Text = buscar.ProfesorSeleccionado.Nombre;
                txtApellido.Text = buscar.ProfesorSeleccionado.Apellido;
                txtDireccion.Text = buscar.ProfesorSeleccionado.Direccion;
                txtFecha.Text = buscar.ProfesorSeleccionado.FechaDeNacimiento;
                txtSalario.Text = buscar.ProfesorSeleccionado.Salario;

                btnGuardarProfesor.Enabled = false;
                btnGuardarAlumno.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                txtSalario.Enabled = true;

            }
        }       
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (accesos == "Profesor" || txtSalario.Enabled == false)
            {
                modificacionDeAlumno();
            }
            else if (accesos == "Director" && txtSalario.Enabled == true)
            {
                modificacionDeProfesor();
            }
        }

        /// <summary>
        /// Limpia los Textboxs.
        /// </summary>
        void limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtFecha.Clear();
        }
        private void Registro_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Elimina un Alumno.
        /// </summary>
        private void eliminarAlumno()
        {
            if (MessageBox.Show("¿Estas seguro que desea eliminar el alumno?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Aplicacion de delegado.
                Eliminar eliminar = new Eliminar(AlumnoDAL<Alumno>.eliminarAlumno);

                if (eliminar(AlumnoActual.Id) > 0)
                {
                    MessageBox.Show("Alumno eliminado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    limpiar();

                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = false;
                    btnGuardarAlumno.Enabled = true;
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

        /// <summary>
        /// Elimina un Profesor.
        /// </summary>
        private void eliminarProfesor()
        {
            if (MessageBox.Show("¿Estas seguro que desea eliminar al profesor?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Aplicacion de delegado.
                Eliminar eliminar = new Eliminar(AlumnoDAL<Profesor>.eliminarProfesor);

                if (eliminar(ProfesorActual.Id) > 0)
                {
                    MessageBox.Show("Profesor eliminado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    limpiar();

                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = false;
                    btnGuardarAlumno.Enabled = true;
                    txtSalario.Clear();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el profesor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Se ha cancelado la eliminacion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (accesos == "Profesor" || txtSalario.Enabled == false)
            {
                eliminarAlumno();
            }
            else if (accesos == "Director" || txtSalario.Enabled == true)
            {
                eliminarProfesor();

            }
        }
        private void ptbImagen_Click(object sender, EventArgs e)
        {
            if (lblCreacion.Text != "")
            {
                Usuario usuario = new Usuario();
                usuario.ShowDialog();
            }
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

        /// <summary>
        /// Verifica que se haya escrito en los TextBoxs.
        /// </summary>
        /// <returns> Un 1 si todo salio bien, un 0 si no </returns>
        private int verificacion()
        {
            string resultado;
            int aux = 0;

            // Verifica que no este vacio el TextBox de nombre.
            if (txtNombre.Text == "")
            {
                epvError.SetError(txtNombre, "Debe ingresar un nombre");
                txtNombre.Focus();
                return aux;
            }

            // Verifica que no se haya ingresado numeros o un caracter que no sea letras.
            else if ((resultado = Alumno.verificacionCadena(txtNombre.Text)) != "")
            {
                MessageBox.Show(resultado, "¡Precaucion!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                epvError.SetError(txtNombre, "Ingrese un nombre valido");
                txtNombre.Focus();
                return aux;
            }
            epvError.SetError(txtNombre, "");

            // Verifica que no este vacio el TextBox de apellido.
            if (txtApellido.Text == "")
            {
                epvError.SetError(txtApellido, "Debe ingresar un apellido");
                txtApellido.Focus();
                return aux;
            }

            // Verifica que no se haya ingresado numeros o un caracter que no sea letras.
            else if ((resultado = Alumno.verificacionCadena(txtApellido.Text)) != "")
            {
                MessageBox.Show(resultado, "¡Precaucion!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                epvError.SetError(txtApellido, "Ingrese un apellido valido");
                txtNombre.Focus();
                return aux;
            }
            epvError.SetError(txtApellido, "");

            // Verifica que no este vacio el TextBox de direccion.
            if (txtDireccion.Text == "")
            {
                epvError.SetError(txtDireccion, "Debe ingresar una direccion");
                txtDireccion.Focus();
                return aux;
            }

            if (txtSalario.Text == "" && txtSalario.Enabled == true)
            {
                epvError.SetError(txtSalario, "Debe ingresar un salario");
                txtSalario.Focus();
                return aux;
            }

            else if ((resultado = Profesor.verificacionSalario(txtSalario.Text)) != "" && txtSalario.Enabled == true)
            {
                MessageBox.Show(resultado, "¡Precaucion!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                epvError.SetError(txtSalario, "Ingrese un salario valido");
                txtSalario.Focus();
                return aux;
            }
            epvError.SetError(txtSalario, "");

            return aux = 1; 
        }

        private void btnGuardarProfesor_Click(object sender, EventArgs e)
        {
            if (verificacion() == 1)
            {
                string fecha = txtFecha.Text.Trim();

                if (txtNombre.Text == "" || txtApellido.Text == "" || txtDireccion.Text == "" || fecha.Length < 5 || txtSalario.Text == "")
                {
                    MessageBox.Show("Error, debe llenar todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Profesor profesor = new Profesor();

                    profesor.Nombre = txtNombre.Text;
                    profesor.Apellido = txtApellido.Text;
                    profesor.Direccion = txtDireccion.Text;
                    profesor.FechaDeNacimiento = txtFecha.Text;
                    profesor.Salario = txtSalario.Text;

                    AlumnoDAL<Profesor> profesorDAL = new AlumnoDAL<Profesor>(5);

                    profesorDAL.agregar(new Profesor(profesor.Nombre));
                    profesorDAL.agregar(new Profesor(profesor.Apellido));
                    profesorDAL.agregar(new Profesor(profesor.Direccion));
                    profesorDAL.agregar(new Profesor(profesor.FechaDeNacimiento));
                    profesorDAL.agregar(new Profesor(profesor.Salario));

                    Profesor nombreP = profesorDAL.getElemento(0);
                    Profesor apellidoP = profesorDAL.getElemento(1);
                    Profesor direccionP = profesorDAL.getElemento(2);
                    Profesor fechaP = profesorDAL.getElemento(3);
                    Profesor salarioP = profesorDAL.getElemento(4);

                    if (AlumnoDAL<Profesor>.agregarProfesor(nombreP.Datos(), apellidoP.Datos(), direccionP.Datos(), fechaP.Datos(), salarioP.Datos()) > 0)
                    {
                        MessageBox.Show("Datos guardados correctamente", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        epvError.SetError(txtFecha, "Verifique el mes, dia y año");
                        txtFecha.Focus();
                    }
                }
            }
        }

        /// <summary>
        /// Modifica un Alumno.
        /// </summary>
        private void modificacionDeAlumno()
        {
            Alumno alumno = new Alumno();

            alumno.Nombre = txtNombre.Text;
            alumno.Apellido = txtApellido.Text;
            alumno.Direccion = txtDireccion.Text;
            alumno.FechaDeNacimiento = txtFecha.Text;
            alumno.Id = alumnoActual.Id;

            if (AlumnoDAL<Alumno>.modificarAlumno(alumno) > 0)
            {
                MessageBox.Show("Alumno modificado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiar();

                if (accesos == "Director")
                {
                    btnGuardarProfesor.Enabled = true;
                    btnGuardarAlumno.Enabled = false;
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
                else
                {
                    btnGuardarAlumno.Enabled = true;
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Error al modificar el alumno", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Modifica un Profesor.
        /// </summary>
        private void modificacionDeProfesor()
        {
            Profesor profesor = new Profesor();

            profesor.Nombre = txtNombre.Text;
            profesor.Apellido = txtApellido.Text;
            profesor.Direccion = txtDireccion.Text;
            profesor.FechaDeNacimiento = txtFecha.Text;
            profesor.Salario = txtSalario.Text;
            profesor.Id = profesorActual.Id;;

            if (AlumnoDAL<Profesor>.modificarProfesor(profesor) > 0)
            {
                MessageBox.Show("Profesor modificado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiar();
                btnGuardarProfesor.Enabled = true;
                btnGuardarAlumno.Enabled = false;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
                txtSalario.Clear();
            }
            else
            {
                MessageBox.Show("Error al modificar el profesor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // AUN NO TERMINADO.
        private void btnTienda_Click(object sender, EventArgs e)
        {
            Tienda tienda = new Tienda();
            tienda.ShowDialog();
        }
    }
}
