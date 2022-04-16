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

        public Operando() : this(0)
        {

        }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string setNumero)
        {
            this.SetNumero = setNumero;
        }

        private double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double retorno))
            {
                return retorno;
            }

            return 0;
        }

        private string SetNumero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

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

        public static string BinarioDecimal(string binario)
        {
            string retorno = "Valor Invalido";

            if (EsBinario(binario))
            {
                retorno = Convert.ToInt32(binario, 2).ToString();
            }

            return retorno;
        }

        public static string DecimaBinario(double numero)
        {
            string binario = "";
            int d = (int)numero;
            int resto;
            do
            {
                resto = d % 2;
                if (resto == 0)
                {
                    //binario += resto;
                    binario = binario.Insert(0, "0");
                }
                else
                {
                    //binario += "1";
                    binario = binario.Insert(0, "1");
                }
                d = d / 2;
            } while (d > 0);
            return binario;
        }

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

        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
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
