using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Paciente:Persona
    {
        public DateTime fNacimiento { get; set; }
        public enumTipoPaciente Tipo { get; set; }
        public HistoriaClinica HistoriaClinica;
        public Paciente(string Dni, string nombre, string apellido, DateTime nacimiento, enumTipoPaciente tipos)
        :base(Dni, nombre, apellido){
            this.fNacimiento = nacimiento;
            this.Tipo = enumTipoPaciente.Asegurado;
            HistoriaClinica = new HistoriaClinica();
        }
        public void addHistoriaClinica()
        {

        }
    }
}
