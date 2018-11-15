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
        

        //public bool VerificarHistoriaClinica()
        //{
        //    //Console.WriteLine($"Verificando historia clinica de: {nombre} {paciente.Apellido}");
        //    //Console.WriteLine("Verificando si tiene historia clinica");
        //    if (getHistoria() != null)
        //    {
        //        //Console.Clear();

        //        return true;
        //    }
        //    else
        //    {

        //        return false;
        //    }

        //}

        //public void GenerarHistoriaClinica()
        //{
        //    Console.WriteLine("Se genera historia con los siguientes datos:");
        //    var Codespecialidad = enumCodEspecialidades.dsfsdfds;
        //    DateTime fechaAdmision = DateTime.Now;
        //    int peso = new Random().Next(80);
        //    string talla = (new Random().NextDouble() * 10).ToString();
        //    Console.WriteLine($"Especialidad:\t{Codespecialidad}");
        //    Console.WriteLine($"Fecha de admision:\t{fechaAdmision}");
        //    Console.WriteLine($"Peso:\t{peso}");
        //    Console.WriteLine($"Talla:\t{talla}");
        //    Console.WriteLine($"Dni:\t{Dni}");
        //    HistoriaClinica historia = new HistoriaClinica(Codespecialidad, fechaAdmision, peso, talla, paciente.Dni);
        //    AsignarHistoria(historia);
        //}


    }
}
