using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Director : Persona
    {
        public Director()
        {

        }
        public Director(Int64 id, string nombre, string apellido, string direccion, string fechaDeNacimiento) : base(id, nombre, apellido, direccion, fechaDeNacimiento)
        {

        }
    }
}
