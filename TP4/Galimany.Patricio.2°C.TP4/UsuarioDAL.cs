using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Biblioteca;

namespace Galimany.Patricio._2_C.TP4
{
    public class UsuarioDAL
    {
        public static string nombreUsuario;
        public static int CrearCuentas(string pUsuario, string pContraseña, string usuario)
        {
            int resultado = 0;

            if (usuario == "Alumno")
            {
                SqlConnection Conn = Comun.ObtenerConexion();

                SqlCommand Comando = new SqlCommand(string.Format("Insert Into Usuarios (Nombre, Contraseña) values ('{0}', PwdEncrypt('{1}') )", pUsuario, pContraseña), Conn);

                resultado = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            else if (usuario == "Profesor")
            {
                SqlConnection Conn = Comun.ObtenerConexion();

                SqlCommand Comando = new SqlCommand(string.Format("Insert Into UsuariosProfesor (Nombre, Contraseña) values ('{0}', PwdEncrypt('{1}') )", pUsuario, pContraseña), Conn);

                resultado = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            return resultado;
        }
        public static int CargarCompra()
        {
            int retorno = 1;

            using (SqlConnection connection = Comun.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(string.Format("Update Tienda Set Comprador='{0}' Where Id='{1}'", nombreUsuario, retorno), connection);

                retorno = command.ExecuteNonQuery();
                command.Clone();
                return retorno;
            }
        }
        public static int Auntentificar(string pUsuario, string pContraseña, string usuario)
        {
            int resultado = 0;
            nombreUsuario = pUsuario;

            if (usuario == "Alumno")
            {
                SqlConnection connection = Comun.ObtenerConexion();

                SqlCommand command = new SqlCommand(string.Format("SELECT * FROM Usuarios WHERE Nombre = '{0}' AND PwdCompare('{1}',Contraseña) = 1 ", pUsuario, pContraseña), connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    resultado = 50;
                }
                connection.Close();
            }
            else if(usuario == "Profesor")
            {
                SqlConnection connection = Comun.ObtenerConexion();

                SqlCommand command = new SqlCommand(string.Format("SELECT * FROM UsuariosProfesor WHERE Nombre = '{0}' AND PwdCompare('{1}',Contraseña) = 1 ", pUsuario, pContraseña), connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    resultado = 50;
                }
                connection.Close();
            }
            else if (usuario == "Director")
            {
                SqlConnection connection = Comun.ObtenerConexion();

                SqlCommand command = new SqlCommand(string.Format("SELECT * FROM UsuarioDirector WHERE Nombre = '{0}' AND PwdCompare('{1}',Contraseña) = 1 ", pUsuario, pContraseña), connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    resultado = 50;
                }
                connection.Close();
            }
            return resultado;

        }
    }
}

