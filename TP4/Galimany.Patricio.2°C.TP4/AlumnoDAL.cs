using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Galimany.Patricio._2_C.TP4
{
    public class AlumnoDAL
    {
        public static int Agregar(Alumno alumno)
        {
            int retorno = 0;

            using (SqlConnection connection = Comun.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO Alumnos (Nombre, Apellido, Direccion, FechaDeNacimiento) VALUES ('{0}','{1}','{2}','{3}')", alumno.Nombre, alumno.Apellido, alumno.Direccion, alumno.FechaDeNacimiento), connection);

                retorno = cmd.ExecuteNonQuery();
            }
            return retorno;
        }
        public static List<Alumno> BuscarAlumnos(string nombre, string apellido)
        {
            List<Alumno> lista = new List<Alumno>();

            using (SqlConnection connection = Comun.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(string.Format("SELECT Id, Nombre, Apellido, Direccion, FechaDeNacimiento FROM Alumnos WHERE Nombre LIKE '%{0}%' AND Apellido LIKE '%{1}%'", nombre, apellido), connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Alumno alumno = new Alumno();

                    alumno.Id = reader.GetInt64(0);
                    alumno.Nombre = reader.GetString(1);
                    alumno.Apellido = reader.GetString(2);
                    alumno.Direccion = reader.GetString(3);
                    alumno.FechaDeNacimiento = Convert.ToString(reader.GetDateTime(4));

                    lista.Add(alumno);
                }
                connection.Close();
                return lista;
            }
        }
        public static Alumno ObtenerAlumno(Int64 id)
        {
            using (SqlConnection connection = Comun.ObtenerConexion())
            {
                Alumno alumno = new Alumno();

                SqlCommand command = new SqlCommand(string.Format("SELECT Id, Nombre, Apellido, Direccion, FechaDeNacimiento FROM Alumnos WHERE Id={0}",id), connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    alumno.Id = reader.GetInt64(0);
                    alumno.Nombre = reader.GetString(1);
                    alumno.Apellido = reader.GetString(2);
                    alumno.Direccion = reader.GetString(3);
                    alumno.FechaDeNacimiento = Convert.ToString(reader.GetDateTime(4));
                }
                connection.Close();
                return alumno;
            }
        }
        public static int Modificar(Alumno alumno)
        {
            int retorno = 0;

            using(SqlConnection connection = Comun.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(string.Format("UPDATE Alumnos SET Nombre='{0}', Apellido='{1}', Direccion='{2}', FechaDeNacimiento='{3}' WHERE Id={4}",
                    alumno.Nombre, alumno.Apellido, alumno.Direccion, alumno.FechaDeNacimiento, alumno.Id), connection);

                retorno = command.ExecuteNonQuery();
                command.Clone();
            }
            return retorno;
        }
        public static int Eliminar(Int64 id)
        {
            int retorno = 0;

            using (SqlConnection connection = Comun.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(String.Format("DELETE FROM Alumnos WHERE Id={0}", id), connection);

                retorno = command.ExecuteNonQuery();
                command.Clone();
            }
            return retorno;
        }
    }
}
