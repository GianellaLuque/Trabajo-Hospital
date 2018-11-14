using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public static class Metodos
    {
        public static bool VerificarHistoriaClinica(Paciente paciente)
        {
            Console.WriteLine($"Verificando historia clinica de: {paciente.Nombre} {paciente.Apellido}");
            //Console.WriteLine("Verificando si tiene historia clinica");
            if (paciente.getHistoria() != null)
            {
                //Console.Clear();
                Console.WriteLine("Tiene historia");
                return true;
            }
            else
            {
                Console.WriteLine("No tiene historia");
                return false;
            }
           
        }

        public static void GenerarHistoriaClinica(Paciente paciente)
        {
            //Paciente p = new Paciente();
            string dni = paciente.Dni;
            Console.WriteLine("Se genera historia con los siguientes datos:");
            var Codespecialidad = enumCodEspecialidades.dsfsdfds;
            //var codEspecialidad = enumCodEspecialidades.dsfsdfds;
            DateTime fechaAdmision = DateTime.Now;
            int peso = new Random().Next(80);
            string talla = (new Random().NextDouble() * 10).ToString();
            //string dni = (new Random().Next(99999999)).ToString();
            Console.WriteLine($"Especialidad:\t{especialidad}");
            //Console.WriteLine($"codEspecialidad:\t{codEspecialidad}");
            Console.WriteLine($"Fecha de admision:\t{fechaAdmision}");
            Console.WriteLine($"Peso:\t{peso}");
            Console.WriteLine($"Talla:\t{talla}");
            Console.WriteLine($"Dni:\t{paciente.Dni}");
            HistoriaClinica historia = new HistoriaClinica(Codespecialidad, fechaAdmision, peso, talla, paciente.Dni);
            paciente.AsignarHistoria(historia);
            //return historia;
        }

        public static void GenerarCita(Paciente paciente, Medico medico, )
        {

        }
    }
}
