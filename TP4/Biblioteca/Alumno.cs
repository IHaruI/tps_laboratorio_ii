using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Alumno : Persona
    {
        private string dato;
        public Alumno()
        {

        }
        public Alumno(string datos)
        {
            this.dato = datos;
        }
        public Alumno(Int64 id, string nombre, string apellido, string direccion, string fechaDeNacimiento) : base (id, nombre, apellido, direccion, fechaDeNacimiento)
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
        public string Datos()
        {
            return dato;
        }
    }
}
