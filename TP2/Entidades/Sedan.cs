using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Sedan : Vehiculo
    {
        public enum ETipo { CuatroPuertas, CincoPuertas }
        private ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas || Constructor de Sedan
        /// </summary>
        /// <param name="marca"> Marca (EMarca) del Sedan </param>
        /// <param name="chasis"> Chasis (string) del Sedan </param>
        /// <param name="color"> Color (ConsoleColor) del Sedan </param>
        /// <param name="tipo"> Tipo (ETipo) de puertas del Sedan</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Constructor de Sedan
        /// </summary>
        /// <param name="marca"> Marca (EMarca) del Sedan </param>
        /// <param name="chasis"> Chasis (string) del Sedan </param>
        /// <param name="color"> Color (ConsoleColor) del Sedan </param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, ETipo.CuatroPuertas)
        {
        }

        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Sobreescribe Mostrar()
        /// </summary>
        /// <returns> Retorna (string) los datos del Sedan</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
