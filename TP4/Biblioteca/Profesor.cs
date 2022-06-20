using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Profesor : Persona, ISalario
    {
        // Atributos
        private string dato;
        private string salario;

        // Constructores
        public Profesor()
        {

        }
        public Profesor(string datos)
        {
            this.dato = datos;
        }
        public Profesor(Int64 id, string nombre, string apellido, string direccion, string fechaDeNacimiento, string salario) : base(id, nombre, apellido, direccion, fechaDeNacimiento)
        {
            this.salario = salario;
        }

        // Getter y Setter
        public string Salario { get => this.salario; set => this.salario = value; }
        public string Datos()
        {
            return dato;
        }

        /// <summary>
        /// Valida que se haya ingresado solo numeros en la TextBox.
        /// </summary>
        /// <param name="salario"> (string) Recibe la cadena del TextBox </param>
        /// <returns> Un mensaje con la excepcion capturada si se ingreso una letra o si hay un OverFlow. Si esta todo OK retorna una cadena vacia </returns>
        public static string verificacionSalario(string salario)
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
    }
}
