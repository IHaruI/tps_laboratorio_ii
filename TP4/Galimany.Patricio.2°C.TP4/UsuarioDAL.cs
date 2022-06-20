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
        // Atributo
        public static string ? nombreUsuario;

        /// <summary>
        /// Crea las cuentas de los usuarios.
        /// </summary>
        /// <param name="pUsuario"> (string) Nombre del usuario </param>
        /// <param name="pContraseña"> (string) Contraseña del usuario </param>
        /// <param name="usuario"> (string) Tipo de usuario </param>
        /// <returns> Un 1 si todo salio bien, 0 si no </returns>
        public static int crearCuentas(string pUsuario, string pContraseña, string usuario)
        {
            int resultado = 0;

            if (usuario == "Alumno")
            {
                SqlConnection Conn = Comun.obtenerConexion();

                SqlCommand Comando = new SqlCommand(string.Format("Insert Into Usuarios (Nombre, Contraseña) values ('{0}', PwdEncrypt('{1}') )", pUsuario, pContraseña), Conn);

                resultado = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            else if (usuario == "Profesor")
            {
                SqlConnection Conn = Comun.obtenerConexion();

                SqlCommand Comando = new SqlCommand(string.Format("Insert Into UsuariosProfesor (Nombre, Contraseña) values ('{0}', PwdEncrypt('{1}') )", pUsuario, pContraseña), Conn);

                resultado = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            return resultado;
        }

        /// <summary>
        /// Carga la compra que se ha realizado               "AUN NO TERMINADO"
        /// </summary>
        /// <returns> Un 1 si todo salio bien, 0 si no </returns>
        public static int cargarCompra()
        {
            int retorno = 1;

            using (SqlConnection connection = Comun.obtenerConexion())
            {
                SqlCommand command = new SqlCommand(string.Format("Update Tienda Set Comprador='{0}' Where Id='{1}'", nombreUsuario, retorno), connection);

                retorno = command.ExecuteNonQuery();
                command.Clone();
                return retorno;
            }
        }

        /// <summary>
        /// Verifica que el usuario exista.
        /// </summary>
        /// <param name="pUsuario"> (string) Usuario pasado por parametro </param>
        /// <param name="pContraseña"> (string) Contraseña pasado por parametro </param>
        /// <param name="usuario"> (string) Tipo de usuario pasado por parametro </param>
        /// <returns> Un 1 si todo salio bien, 0 si no </returns>
        public static int auntentificar(string pUsuario, string pContraseña, string usuario)
        {
            int resultado = 0;
            nombreUsuario = pUsuario;

            if (usuario == "Alumno")
            {
                SqlConnection connection = Comun.obtenerConexion();

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
                SqlConnection connection = Comun.obtenerConexion();

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
                SqlConnection connection = Comun.obtenerConexion();

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

