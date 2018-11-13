using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Persona
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Persona(string Dni, string nombre, string apellido)
        {
            this.Dni = Dni;
            Nombre = nombre;
            Apellido = apellido;
        }
    }
}
