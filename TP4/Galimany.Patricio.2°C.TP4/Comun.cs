using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Biblioteca;

namespace Galimany.Patricio._2_C.TP4
{
    public class Comun
    {
        /// <summary>
        /// Conexion a Sql Server
        /// </summary>
        /// <returns> La conexion </returns>
        public static SqlConnection obtenerConexion()
        {
            string connectionString = @"Server=.;Database=EscuelaBD; Trusted_Connection=True;";
            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();

            return conexion;
        }
    }
}
