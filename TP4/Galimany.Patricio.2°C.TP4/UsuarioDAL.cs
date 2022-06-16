using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Galimany.Patricio._2_C.TP4
{
    public class UsuarioDAL
    {
        public static int CrearCuentas(string pUsuario, string pContraseña)
        {
            int resultado = 0;
            SqlConnection Conn = Comun.ObtenerConexion();

            SqlCommand Comando = new SqlCommand(string.Format("Insert Into Usuarios (Nombre, Contraseña) values ('{0}', PwdEncrypt('{1}') )", pUsuario, pContraseña), Conn);

            resultado = Comando.ExecuteNonQuery();
            Conn.Close();

            return resultado;
        }
        public static int Auntentificar(string usuario, string contraseña)
        {
            int resultado = 0;

            SqlConnection connection = Comun.ObtenerConexion();

            SqlCommand command = new SqlCommand(string.Format("SELECT * FROM Usuarios WHERE Nombre = '{0}' AND PwdCompare('{1}',Contraseña) = 1 ", usuario, contraseña), connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                resultado = 50;
            }
            connection.Close();
            return resultado;
        }
    }
}

