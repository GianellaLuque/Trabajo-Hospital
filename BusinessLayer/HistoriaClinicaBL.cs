using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Entities;
using DataAccess;

namespace BusinessLayer
{
    public class HistoriaClinicaBL
    {
        public static List<HistoriaClinica> ListHistoriaClinica;

        public List<HistoriaClinica> GetHistoriaClinica()
        {
            string path = HistoriaClinicaDAL.ConexionHistoriaClinica();
            string[] lineas = File.ReadAllLines($"{path}\\BD\\HistoriasClinicas.txt");

            foreach(var item in lineas)
            {
                string codEspecialidad = item.Split("%")[0];
                //Enum.TryParse(codEspecialidad, out enumCodEspecialidades codEspec);
                DateTime fechaApertura = Convert.ToDateTime(item.Split("%")[1]);
                int Peso = int.Parse(item.Split("%")[2]);
                string Talla= item.Split("%")[3];
                string Dni = item.Split("%")[4];
                HistoriaClinica h = new HistoriaClinica(codEspecialidad, fechaApertura, Peso, Talla, Dni);
                ListHistoriaClinica.Add(h);
            }
            return ListHistoriaClinica;
        }


        public static void MostrarHistoriaClinica(Paciente paciente)
        {
            Console.WriteLine("Se imprime historia Clinica de paciente:");
            Console.WriteLine($"Nombre:\t{paciente.Nombre}");
            Console.WriteLine($"Apellido:\t{paciente.Apellido}");
            //Console.WriteLine($"codEspecialidad:\t{codEspecialidad}");
            Console.WriteLine($"CodEspecialidad:\t{paciente.HistClinica.CodEspecialidad}");
            Console.WriteLine($"FechaApertura:\t{paciente.HistClinica.FechaApertura}");
            Console.WriteLine($"Peso:\t{paciente.HistClinica.Peso}");
            Console.WriteLine($"Talla:\t{paciente.HistClinica.Talla}");
            Console.WriteLine($"Dni:\t{paciente.Dni}");
        }

        public static void GenerarHistoriaClinica(Paciente paciente)
        {
            //Paciente p = new Paciente();
            string dni = paciente.Dni;
            Console.WriteLine("Se genera historia con los siguientes datos:");
            var Codespecialidad = "1343";
            //var codEspecialidad = enumCodEspecialidades.dsfsdfds;
            DateTime fechaAdmision = DateTime.Now;
            int peso = new Random().Next(80);
            string talla = (new Random().NextDouble() * 10).ToString();
            //string dni = (new Random().Next(99999999)).ToString();
            Console.WriteLine($"Especialidad:\t{Codespecialidad}");
            //Console.WriteLine($"codEspecialidad:\t{codEspecialidad}");
            Console.WriteLine($"Fecha de admision:\t{fechaAdmision}");
            Console.WriteLine($"Peso:\t{peso}");
            Console.WriteLine($"Talla:\t{talla}");
            Console.WriteLine($"Dni:\t{paciente.Dni}");
            HistoriaClinica historia = new HistoriaClinica(Codespecialidad, fechaAdmision, peso, talla, paciente.Dni);
            AsignarHistoria(historia, paciente);
            //Persona persona = new Persona();
        }

        public static bool VerificarHistoriaClinica(Paciente paciente)
        {
            if (paciente.HistClinica != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void AsignarHistoria(HistoriaClinica nuevaHistoria, Paciente paciente)
        {
            paciente.HistClinica = new HistoriaClinica();
            paciente.HistClinica = nuevaHistoria;
        }
    }
}
