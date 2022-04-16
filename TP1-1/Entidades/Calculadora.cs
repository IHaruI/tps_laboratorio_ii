using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida el operador ingresado.
        /// </summary>
        /// <param name="operador"> Parametro a validar </param>
        /// <returns> Retorna el operador pasado por parametro si es true, si no False. </returns>
        private static char ValidarOperador(char operador)
        {
            char retorno = '+';

            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                retorno = operador;
            }

            return retorno;
        }

        /// <summary>
        /// Valida y realiza la operacion pasado por parametro.
        /// </summary>
        /// <param name="num1"> Primer numero </param>
        /// <param name="num2"> Segundo numero </param>
        /// <param name="operador"> Operador asignado </param>
        /// <returns> Retorna la operacion realizada, si no retorna 0. </returns>
        public static double Operar(Operando num1, Operando num2, string operador)
        {
            double retorno = 0;

            switch (operador)
            {
                case "+":
                    retorno = num1 + num2;
                    break;

                case "-":
                    retorno = num1 - num2;
                    break;

                case "/":
                    retorno = num1 / num2;
                    break;

                case "*":
                    retorno = num1 * num2;
                    break;
            }

            return retorno;
        }
    }
}
