using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Cita
    {
        //ATRIBUTOS
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CodEspecialidad { get; set; }
        public string CodDoctir { get; set; }
        public enumTipoCita TipoCita { get; set; }
        public enumEstadoCita EstadoCita { get; set; }

        //CONTRUCTOR
        public Cita(string dni, string nombre, string apellido, string codEsp, string codDoc, enumTipoCita tcita, enumEstadoCita eCita)
        {
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;

        }

    }
}
