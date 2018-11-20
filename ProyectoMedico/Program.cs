using System;
using Entities;
using BusinessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoMedico
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }
        static async Task MainAsync()
        {
            // instanciamos objetos de uso
            //PacienteBL Pacientes = new PacienteBL();
            HistoriaClinica historia = new HistoriaClinica();
            //Paciente paciente = new Paciente();
            //await Metodos.InsertarPaciente(paciente);
            //List<Paciente> pacientes = await Metodos.GetPacientes();
            //await Metodos.InsertarHistoriaClinica(historia);
            List<HistoriaClinica> historias = await Metodos.GetHistoriasClinicas();
            //List<Medico> medicos = await Metodos.GetMedicos();
            foreach (var item in historias)
            {
                //Console.WriteLine($"{item.Dni}\t{item.Nombre}\t{item.Apellido}\t{item.fNacimiento}\t{item.HistClinica}");
                Console.WriteLine(item);
            }

            //foreach (var item in medicos)
            //{
            //    //Console.WriteLine($"{item.Dni}\t{item.Nombre}\t{item.Apellido}\t{item.fNacimiento}\t{item.HistClinica}");
            //    Console.WriteLine(item);
            //}
        }

        // METODOS
    }
}
