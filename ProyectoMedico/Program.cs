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
            string menu = @"SISTEMA HOSPITALARIO:
1.  Generar paciente.
2.  Administrar pacientes.
3.  Administrar personal medico.
4.  Otros.
";
            Console.WriteLine(menu);
        }
    }
}
