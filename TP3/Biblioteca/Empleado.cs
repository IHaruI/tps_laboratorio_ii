using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace Biblioteca
{
    public class Empleado : Persona
    {
        /// <summary>
        /// Constructor de Empleados que manda sus datos a la base.
        /// </summary>
        /// <param name="nombre"> (string) Recibe un nombre </param>
        /// <param name="apellido"> (string) Recibe un apellido </param>
        /// <param name="salario"> (decimal) Recibe un salario </param>
        /// <param name="fecha"> (DateTime) Recibe un fecha </param>
        /// <param name="especialidad"> (string) Recibe un especialidad </param>
        public Empleado(string nombre, string apellido, decimal salario, DateTime fecha, string especialidad) : base(nombre, apellido, salario, fecha, especialidad)
        {

        }

        /// <summary>
        /// Valida que se haya ingresado solo letras en la TextBox.
        /// </summary>
        /// <param name="cadena"> (string) Recibe la cadena del TextBox </param>
        /// <returns> Un mensaje con la excepcion capturada si se ingreso un caracter no deseado. Si esta todo OK retorna una cadena vacia </returns>
        public static string VerificacionCadena(string cadena)
        {
            string resultado = string.Empty;

            try
            {
                for (int i = 0; i < cadena.Length; i++)
                {
                    if (cadena[i] >= 33 && cadena[i] <= 64 || cadena[i] >= 91 && cadena[i] <= 96 || cadena[i] >= 123 && cadena[i] <= 255)
                    {
                        throw new FormatException();
                    }
                }
            }
            catch (FormatException ex)
            {
                resultado = "Error al validar: " + ex.Message;
            }
            return resultado;
        }

        /// <summary>
        /// Valida que se haya ingresado solo numeros en la TextBox.
        /// </summary>
        /// <param name="salario"> (string) Recibe la cadena del TextBox </param>
        /// <returns> Un mensaje con la excepcion capturada si se ingreso una letra o si hay un OverFlow. Si esta todo OK retorna una cadena vacia </returns>
        public static string VerificacionSalario(string salario)
        {
            string resultado = string.Empty;

            try
            {
                decimal aux;
                decimal numero = decimal.MaxValue;

                if ((aux = decimal.Parse(salario)) <= numero)
                {

                }
            }
            catch (FormatException ex)
            {
                resultado = "Error al validar salario: " + ex.Message;
            }
            catch (OverflowException ex)
            {
                resultado = "Error al validar el salario: " + ex.Message;
            }
            return resultado;
        }

        /// <summary>
        /// Verifica si el nombre esta repetido en la lista.
        /// </summary>
        /// <param name="n1"> (Empleado) Recibe un Empleado </param>
        /// <param name="n2"> (string) Recibe el nombre que se ingreso un la TextBox </param>
        /// <returns> True si esta el nombre repetido, False si no lo esta </returns>
        public static bool operator ==(Empleado n1, string n2)
        {
            return n1.Nombre == n2;
        }

        /// <summary>
        /// Verifica si el nombre esta repetido en la lista.
        /// </summary>
        /// <param name="n1"> (Empleado) Recibe un Empleado </param>
        /// <param name="n2"> (string) Recibe el nombre que se ingreso un la TextBox </param>
        /// <returns> True si esta el nombre no repetido, False si lo esta </returns>
        public static bool operator !=(Empleado n1, string n2)
        {
            return !(n1.Nombre == n2);
        }

        /// <summary>
        /// Verifica si el apellido esta repetido en la lista.
        /// </summary>
        /// <param name="a1"> (string) Recibe el apellido que se ingreso un la TextBox </param>
        /// <param name="a2"> (Empleado) Recibe un Empleado </param>
        /// <returns> True si esta el apellido repetido, False si no lo esta </returns>
        public static bool operator ==(string a1, Empleado a2)
        {
            return a1 == a2.Apellido;
        }

        /// <summary>
        /// Verifica si el apellido esta repetido en la lista.
        /// </summary>
        /// <param name="a1"> (string) Recibe el apellido que se ingreso un la TextBox </param>
        /// <param name="a2"> (Empleado) Recibe un Empleado </param>
        /// <returns> True si esta el apellido repetido, False si no lo esta </returns>
        public static bool operator !=(string a1, Empleado a2)
        {
            return !(a1 == a2.Apellido);
        }
    }
}
