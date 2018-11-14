using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Cita
    {
        //ATRIBUTOS
        public string Dni { get; }
        public string Nombre { get;}
        public string Apellido { get; }
        public enumCodEspecialidades CodEspecialidad { get; }
        public string CodDoctor { get; }
        public enumTipoCita TipoCita { get; }
        public enumEstadoCita EstadoCita { get;}

        //CONTRUCTOR
        public Cita(string dni, string nombre, string apellido, enumCodEspecialidades codEsp, string codDoc, enumTipoCita tcita, enumEstadoCita eCita)
        {
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            CodEspecialidad = codEsp;
            CodDoctor = codDoc;
            TipoCita = tcita;
            EstadoCita = eCita;
        }

    }
}
