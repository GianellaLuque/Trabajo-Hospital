using System;
using Entities;
using BusinessLayer;

namespace ProyectoMedico
{
    class Program
    {
        static void Main(string[] args)
        {
            PacienteBL pacienteBL = new PacienteBL();
            var Paciente = pacienteBL.GetPacientes();
            foreach (var item in Paciente)
            {
                Console.WriteLine($"{item.Dni},{item.Nombre},{item.Apellido}");
            }
        }
    }
}
