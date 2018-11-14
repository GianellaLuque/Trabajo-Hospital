using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Paciente:Persona
    {
        public DateTime fNacimiento { get; set; }
        public enumTipoPaciente Tipo { get; set; }

        public HistoriaClinica HistClinica;


        // CONSTRUCTOR
        public Paciente() { }
        public Paciente(string Dni, string nombre, string apellido, DateTime nacimiento, enumTipoPaciente tipos)
        :base(Dni, nombre, apellido){
            this.fNacimiento = nacimiento;
            this.Tipo = enumTipoPaciente.Asegurado;
            HistClinica = null;
        }
        public HistoriaClinica getHistoria()
        {
            //HistClinica = new List<HistoriaClinica>();
            //HistClinica = null;
            return HistClinica;
        }

        public void AsignarHistoria(HistoriaClinica nuevaHistoria)
        {
            HistClinica = new HistoriaClinica();
            HistClinica = nuevaHistoria;  
        }


    }
}
