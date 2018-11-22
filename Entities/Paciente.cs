using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Paciente:Persona
    {
        public string fNacimiento { get; set; }
        public string Tipo { get; set; }
        //public string HistClinica;

        // CONSTRUCTOR
        public Paciente()
        {
            //this.Tipo = enumTipoPaciente.Asegurado;
            //HistClinica = new HistoriaClinica();
        }
        public Paciente(string Dni, string nombre, string apellido, string nacimiento, string tipos)
        :base(Dni, nombre, apellido){
            this.fNacimiento = nacimiento;
            //this.Tipo = enumTipoPaciente.Asegurado;
            Tipo = tipos;
            //HistClinica = new HistoriaClinica();
        }

        // METODOS
        public override string ToString()
        {
            return string.Format("DNI = {0}, NOMBRE = {1}, APELLIDO = {2}, FNACIMIENTO = {3}, TIPO SEGURO = {4}", Dni, Nombre, Apellido, fNacimiento, Tipo);
        }
    }
}
