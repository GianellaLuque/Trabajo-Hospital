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
        //public enumCodEspecialidades CodEspecialidad { get; set; }
        public string CodEspecialidad { get; set; }
        public string CodDoctor { get; set; }
        //public enumTipoCita TipoCita { get; set; }
        public string TipoCita { get; set; }
        //public enumEstadoCita EstadoCita { get; set; }
        public string EstadoCita { get; set; }
        //CONTRUCTOR
        public Cita(string dni, string nombre, string apellido, string codEsp, string codDoc, string tcita, string eCita)
        {
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            CodEspecialidad = codEsp;
            CodDoctor = codDoc;
            TipoCita = tcita;
            EstadoCita = eCita;
        }

        public Cita()
        {

        }

        public override string ToString()
        {
            return string.Format("DNI = {0} ,NOMBRE = {1}, APELLIDO = {2}, COD.ESPECIALIDAD = {3}, COD.DOCTOR = {4}, TIPO CITA = {5}, ESTADO CITA = {6}", Dni, Nombre, Apellido, CodEspecialidad, CodDoctor, TipoCita, EstadoCita);
        }
    }

}
