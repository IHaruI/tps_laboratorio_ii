using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Profesor : Persona, ISalario
    {
        private string dato;
        private string salario;
        public Profesor()
        {

        }
        public Profesor(string datos)
        {
            this.dato = datos;
        }
        public Profesor(Int64 id, string nombre, string apellido, string direccion, string fechaDeNacimiento, string salario) : base(id, nombre, apellido, direccion, fechaDeNacimiento)
        {
            this.salario = salario;
        }
        public string Salario { get => this.salario; set => this.salario = value; }
        public string Datos()
        {
            return dato;
        }
    }
}
