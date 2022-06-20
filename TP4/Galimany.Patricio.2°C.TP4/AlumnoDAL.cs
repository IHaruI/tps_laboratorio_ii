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
        // Atributos
        private T[] datosElementos;
        private int i = 0;

        // Constructor
        public AlumnoDAL(int z)
        {
            datosElementos = new T[z];
        }

        /// <summary>
        /// Asigna un objeto en el indice.
        /// </summary>
        /// <param name="obj"></param>
        public void agregar(T obj)
        {
            datosElementos[i] = obj;
            i++;
        }

        /// <summary>
        /// Devuleve un elemente en el indice especificado.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T getElemento(int i)
        {
            return datosElementos[i];
        }

        /// <summary>
        /// Agrega un Alumno a las base de datos.
        /// </summary>
        /// <param name="nombre"> (string) Nombre pasado por parametro </param>
        /// <param name="apellido"> (string) Apellido pasado por parametro </param>
        /// <param name="direccion"> (string) Direccion pasado por parametro </param>
        /// <param name="fecha"> (string) Fecha pasado por parametro </param>
        /// <returns> Un 1 si todo salio correctamente, 0 si no </returns>
        public static int agregarAlumno(string nombre, string apellido, string direccion, string fecha)
        {
            int retorno = 0;
            
            try
            {
                using (SqlConnection connection = Comun.obtenerConexion())
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

        /// <summary>
        /// Agrega un Profesor a las base de datos.
        /// </summary>
        /// <param name="nombre"> (string) Nombre pasado por parametro </param>
        /// <param name="apellido"> (string) Apellido pasado por parametro </param>
        /// <param name="direccion"> (string) Direccion pasado por parametro </param>
        /// <param name="fecha"> (string) Fecha pasado por parametro </param>
        /// <param name="salario"> (string) Salario pasado por parametro </param>
        /// <returns> Un 1 si todo salio correctamente, 0 si no </returns>
        public static int agregarProfesor(string nombre, string apellido, string direccion, string fecha, string salario)
        {
            int retorno = 0;

            try
            {
                using (SqlConnection connection = Comun.obtenerConexion())
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

        /// <summary>
        /// Busca a los Alumnos registrados en la base de datos.
        /// </summary>
        /// <param name="nombre"> (string) Nombre a buscar </param>
        /// <param name="apellido"> (string) Apellido a buscar </param>
        /// <returns> Una lista de los alumnos encontrados </returns>
        public static List<Alumno> buscarAlumnos(string nombre, string apellido)
        {
            List<Alumno> lista = new List<Alumno>();

            using (SqlConnection connection = Comun.obtenerConexion())
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

        /// <summary>
        /// Busca a los Profesores registrados en la base de datos.
        /// </summary>
        /// <param name="nombre"> (string) Nombre a buscar </param>
        /// <param name="apellido"> (string) apellido a buscar </param>
        /// <returns> Una lista de los profesores encontrados </returns>
        public static List<Profesor> buscarProfesor(string nombre, string apellido)
        {
            List<Profesor> lista = new List<Profesor>();

            using (SqlConnection connection = Comun.obtenerConexion())
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

        /// <summary>
        /// Obtiene los datos del Alumno mediante du Id.
        /// </summary>
        /// <param name="id"> (Int64) Id a buscar </param>
        /// <returns> Un alumno </returns>
        public static Alumno obtenerAlumno(Int64 id)
        {
            using (SqlConnection connection = Comun.obtenerConexion())
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

        /// <summary>
        /// Obtiene los datos del Profesor mediante du Id.
        /// </summary>
        /// <param name="id"> (Int64) Id a buscar </param>
        /// <returns> Un profesor </returns>
        public static Profesor obtenerProfesor(Int64 id)
        {
            using (SqlConnection connection = Comun.obtenerConexion())
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

        /// <summary>
        /// Modifica un Alumno.
        /// </summary>
        /// <param name="alumno"> (Alumno) alumno pasado por parametro </param>
        /// <returns> Un 1 si todo salio bien, o un 0 si no </returns>
        public static int modificarAlumno(Alumno alumno)
        {
            int retorno = 0;

            try
            {
                using(SqlConnection connection = Comun.obtenerConexion())
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

        /// <summary>
        /// Modifica un Profesor.
        /// </summary>
        /// <param name="profesor"> (Profesor) profesor pasado por parametro </param>
        /// <returns> Un 1 si todo salio bien, o un 0 si no </returns>
        public static int modificarProfesor(Profesor profesor)
        {
            int retorno = 0;

            try
            {
                using (SqlConnection connection = Comun.obtenerConexion())
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

        /// <summary>
        /// Elimina un Alumno mediante su Id.
        /// </summary>
        /// <param name="id"> (Int64) Id a buscar </param>
        /// <returns> Un 1 si todo salio bien, o un 0 si no </returns>
        public static int eliminarAlumno(Int64 id)
        {
            int retorno = 0;

            using (SqlConnection connection = Comun.obtenerConexion())
            {
                SqlCommand command = new SqlCommand(String.Format("DELETE FROM Alumnos WHERE Id={0}", id), connection);

                retorno = command.ExecuteNonQuery();
                command.Clone();
            }
            return retorno;
        }

        /// <summary>
        /// Elimina un Profesor mediante su Id.
        /// </summary>
        /// <param name="id"> (Int64) Id a buscar </param>
        /// <returns> Un 1 si todo salio bien, o un 0 si no </returns>
        public static int eliminarProfesor(Int64 id)
        {
            int retorno = 0;

            using (SqlConnection connection = Comun.obtenerConexion())
            {
                SqlCommand command = new SqlCommand(String.Format("DELETE FROM Profesor WHERE Id={0}", id), connection);

                retorno = command.ExecuteNonQuery();
                command.Clone();
            }
            return retorno;
        }
    }
}
