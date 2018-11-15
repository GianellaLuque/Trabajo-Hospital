using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Medico:Persona
    {
        public string CMP { get; set; }
        public enumEspecialidades Especialidad { get; set; }

        public Medico(string Dni, string nombre, string apellido, string cmp, enumEspecialidades espec)
        :base(Dni, nombre, apellido){
            CMP = cmp;
            Especialidad = espec;
        }
    }
}

