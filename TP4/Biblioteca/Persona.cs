using System;

namespace Biblioteca
{
    public abstract class Persona
    {
        private Int64 id;
        private string nombre;
        private string apellido;
        private string direccion;
        private string fechaDeNacimiento;

        public Persona()
        {

        }
        public Persona(Int64 id, string nombre, string apellido, string direccion, string fechaDeNacimiento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.fechaDeNacimiento = fechaDeNacimiento;
        }
        public Int64 Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
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
        public string Direccion
        {
            get { return this.direccion; }
            set { this.direccion = value; }
        }
        public string FechaDeNacimiento
        {
            get { return this.fechaDeNacimiento; }
            set { this.fechaDeNacimiento = value; }
        }
    }
}
