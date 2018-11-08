using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Paciente:Persona
    {
        public DateTime fNacimiento { get; set; }
        public enumTipo Tipo { get; set; }
        public Paciente(string Dni, string nombre, string apellido, DateTime nacimiento, enumTipo tipos)
        :base(Dni, nombre, apellido){
            this.fNacimiento = nacimiento;
            this.Tipo = enumTipo.Asegurado;
        }
    }
}
