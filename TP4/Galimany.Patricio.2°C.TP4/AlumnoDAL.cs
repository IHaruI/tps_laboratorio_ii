using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Biblioteca;

namespace Galimany.Patricio._2_C.TP4
{
    public class AlumnoDAL<T>
    {
        private T[] datosElementos;
        private int i = 0;
        public AlumnoDAL(int z)
        {
            datosElementos = new T[z];
        }
        public void agregar(T obj)
        {
            datosElementos[i] = obj;
            i++;
        }
        public T getElemento(int i)
        {
            return datosElementos[i];
        }

        public static int AgregarAlumno(string nombre, string apellido, string direccion, string fecha)
        {
            int retorno = 0;
            
            try
            {
                using (SqlConnection connection = Comun.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO Alumnos (Nombre, Apellido, Direccion, FechaDeNacimiento) VALUES ('{0}','{1}','{2}','{3}')", nombre, apellido, direccion, fecha), connection);

                    retorno = cmd.ExecuteNonQuery();
                }
                return retorno;
            }
            catch (SqlException ex)
            {
                return retorno;
            }
        }
        public static int AgregarProfesor(string nombre, string apellido, string direccion, string fecha, string salario)
        {
            int retorno = 0;

            try
            {
                using (SqlConnection connection = Comun.ObtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO Profesor (Nombre, Apellido, Direccion, FechaDeNacimiento, Salario) VALUES ('{0}','{1}','{2}','{3}',{4})", nombre, apellido, direccion, fecha, salario), connection);

                    retorno = cmd.ExecuteNonQuery();
                }
                return retorno;
            }
            catch (SqlException ex)
            {
                return retorno;
            }
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
        public static List<Profesor> BuscarProfesor(string nombre, string apellido)
        {
            List<Profesor> lista = new List<Profesor>();

            using (SqlConnection connection = Comun.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(string.Format("SELECT Id, Nombre, Apellido, Direccion, FechaDeNacimiento, Salario FROM Profesor WHERE Nombre LIKE '%{0}%' AND Apellido LIKE '%{1}%'", nombre, apellido), connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Profesor profesor = new Profesor();

                    profesor.Id = reader.GetInt64(0);
                    profesor.Nombre = reader.GetString(1);
                    profesor.Apellido = reader.GetString(2);
                    profesor.Direccion = reader.GetString(3);
                    profesor.FechaDeNacimiento = Convert.ToString(reader.GetDateTime(4));
                    profesor.Salario = reader.GetString(5);

                    lista.Add(profesor);
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
        public static Profesor ObtenerProfesor(Int64 id)
        {
            using (SqlConnection connection = Comun.ObtenerConexion())
            {
                Profesor profesor = new Profesor();

                SqlCommand command = new SqlCommand(string.Format("SELECT Id, Nombre, Apellido, Direccion, FechaDeNacimiento, Salario FROM Profesor WHERE Id={0}", id), connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    profesor.Id = reader.GetInt64(0);
                    profesor.Nombre = reader.GetString(1);
                    profesor.Apellido = reader.GetString(2);
                    profesor.Direccion = reader.GetString(3);
                    profesor.FechaDeNacimiento = Convert.ToString(reader.GetDateTime(4));
                    profesor.Salario = reader.GetString(5);
                }
                connection.Close();
                return profesor;
            }
        }
        public static int ModificarAlumno(Alumno alumno)
        {
            int retorno = 0;

            try
            {
                using(SqlConnection connection = Comun.ObtenerConexion())
                {
                    SqlCommand command = new SqlCommand(string.Format("UPDATE Alumnos SET Nombre='{0}', Apellido='{1}', Direccion='{2}', FechaDeNacimiento='{3}' WHERE Id={4}",
                        alumno.Nombre, alumno.Apellido, alumno.Direccion, alumno.FechaDeNacimiento, alumno.Id), connection);

                    retorno = command.ExecuteNonQuery();
                    command.Clone();
                    return retorno;
                }
            }
            catch (SqlException ex)
            {
                return retorno;
            }
        }
        public static int ModificarProfesor(Profesor profesor)
        {
            int retorno = 0;

            try
            {
                using (SqlConnection connection = Comun.ObtenerConexion())
                {
                    SqlCommand command = new SqlCommand(string.Format("UPDATE Profesor SET Nombre='{0}', Apellido='{1}', Direccion='{2}', FechaDeNacimiento='{3}', Salario='{4}' WHERE Id={5}",
                        profesor.Nombre, profesor.Apellido, profesor.Direccion, profesor.FechaDeNacimiento, profesor.Salario, profesor.Id), connection);

                    retorno = command.ExecuteNonQuery();
                    command.Clone();
                    return retorno;
                }
            }
            catch (SqlException ex)
            {
                return retorno;
            }
        }
        public static int EliminarAlumno(Int64 id)
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
        public static int EliminarProfesor(Int64 id)
        {
            int retorno = 0;

            using (SqlConnection connection = Comun.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(String.Format("DELETE FROM Profesor WHERE Id={0}", id), connection);

                retorno = command.ExecuteNonQuery();
                command.Clone();
            }
            return retorno;
        }
    }
}
