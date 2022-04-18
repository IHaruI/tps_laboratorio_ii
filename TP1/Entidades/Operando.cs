using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Inicializa el Operando en 0.
        /// </summary>
        public Operando() : this(0)
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="numero"> Parametro que da valor al numero. </param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Inicializa el numero.
        /// </summary>
        /// <param name="setNumero"> Numero pasado en formato String. </param>
        public Operando(string setNumero)
        {
            this.SetNumero = setNumero;
        }

        /// <summary>
        /// Verifica que le valor pasado por parametro sea numerico.
        /// </summary>
        /// <param name="strNumero"> Parametro a validar. </param>
        /// <returns> Retorna el valor del parametro en double, si no 0 en caso que no valide. </returns>
        private double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double retorno))
            {
                return retorno;
            }

            return 0;
        }

        /// <summary>
        /// Setea el atributo numero, en caso que no valide 0.
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Verifica que el parametro sea binario.
        /// </summary>
        /// <param name="binario"> Parametro a validar. </param>
        /// <returns> Retorna True si es binario, si no False si no es asi. </returns>
        private static bool EsBinario(string binario)
        {
            bool retorno = true;

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] < '0' || binario[i] > '1')
                {
                    retorno = false;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Convierte el parametro a decimal.
        /// </summary>
        /// <param name="binario"> Parametro a convertir. </param>
        /// <returns> Retorna un decimal (String), o "Valor Invalido" si no se puedo convertir. </returns>
        public static string BinarioDecimal(string binario)
        {
            string retorno = "Valor Invalido";

            if (EsBinario(binario))
            {
                retorno = Convert.ToInt32(binario, 2).ToString();
            }
            return retorno;
        }

        /// <summary>
        /// Convierte el parametro a binario.
        /// </summary>
        /// <param name="numero"> Parametro a convertir. </param>
        /// <returns> Retorna el numero en binario (String) </returns>
        public static string DecimaBinario(double numero)
        {
            string binario = "";
            int num = (int) numero;

            do
            {
                if ((num % 2) == 0)
                {
                    //binario += resto;
                    binario = binario.Insert(0, "0");
                }
                else
                {
                    //binario += "1";
                    binario = binario.Insert(0, "1");
                }
                num = num / 2;
            } while (num > 0);

            return binario;
        }

        /// <summary>
        /// Convierte el parametro a binario.
        /// </summary>
        /// <param name="numero"> Parametro a convertir. </param>
        /// <returns> Retorna el numero en binario (String), o "Valor Invalido" si el numero no es un String. </returns>
        public static string DecimaBinario(string numero)
        {
            string retorno = "Valor Invalido";
            double aux;

            if (double.TryParse(numero, out aux))
            {
                retorno = Operando.DecimaBinario(aux);
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador "+".
        /// </summary>
        /// <param name="n1"> Primer objeto Operando </param>
        /// <param name="n2"> Segundo objeto Operando </param>
        /// <returns> Retorna la operacion entre el atributo numero. </returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador "-".
        /// </summary>
        /// <param name="n1"> Primer objeto Operando </param>
        /// <param name="n2"> Segundo objeto Operando </param>
        /// <returns> Retorna la operacion entre el atributo numero. </returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador "*".
        /// </summary>
        /// <param name="n1"> Primer objeto Operando </param>
        /// <param name="n2"> Segundo objeto Operando </param>
        /// <returns> Retorna la operacion entre el atributo numero. </returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador "/".
        /// </summary>
        /// <param name="n1"> Primer objeto Operando </param>
        /// <param name="n2"> Segundo objeto Operando </param>
        /// <returns> Retorna la operacion entre el atributo numero. </returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
    }
}
