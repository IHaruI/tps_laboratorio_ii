using System;
using System.Text;

namespace Biblioteca
{
    public abstract class Persona
    {
        /// <summary>
        /// Atributos.
        /// </summary>
        private string nombre;
        private string apellido;
        private decimal salario;
        private DateTime fecha;
        private string especialidad;

        /// <summary>
        /// Constructor de Persona.
        /// </summary>
        /// <param name="nombre"> (string) Recibe un nombre </param>
        /// <param name="apellido"> (string) Recibe un apellido </param>
        /// <param name="salario"> (decima) Recibe un salario </param>
        /// <param name="fecha"> (DateTime) Recibe un fecha </param>
        /// <param name="especialidad"> (string) Recibe un especialidad </param>
        public Persona(string nombre, string apellido, decimal salario, DateTime fecha, string especialidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.salario = salario;
            this.fecha = fecha;
            this.especialidad = especialidad;
        }

        /// <summary>
        /// Propiedades de los atributos.
        /// </summary>
        public string Nombre 
        { 
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public string Apellido 
        { 
            get { return this.apellido; }
            set { this.apellido = value; }
        }
        public decimal Salario
        { 
            get { return this.salario; }
            set { this.salario = value; }
        }
        public DateTime Fecha 
        { 
            get { return this.fecha; }
            set { this.fecha = value; }
        }
        public string Especialidad 
        { 
            get { return this.especialidad; }
            set { this.especialidad = value; }
        }
    }
}
