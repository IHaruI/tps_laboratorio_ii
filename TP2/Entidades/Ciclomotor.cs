using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Ciclomotor : Vehiculo
    {
        /// <summary>
        /// Constructor del Ciclomotor
        /// </summary>
        /// <param name="marca"> Marca (EMarca) del Ciclomotor por parametro </param>
        /// <param name="chasis"> Chasis (string) del Ciclomotor por parametro </param>
        /// <param name="color"> Color (ConsoleColor) del Ciclomotor por parametro </param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {
        }
        
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Sobreescribe Mostrar()
        /// </summary>
        /// <returns> Retorna (string) los datos del Ciclomotor </returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
