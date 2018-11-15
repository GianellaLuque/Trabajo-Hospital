using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DataAccess;
namespace Entities
{
    public static class Metodos
    {
        // METODOS DE ADMINISTRACION DE HISTORIA CLINICA
        //public HistoriaClinica getHistoria(HistoriaClinica historia)
        //{
        //    //HistClinica = new List<HistoriaClinica>();
        //    //HistClinica = null;
        //    return HistClinica;
        //}

        //public static void AsignarHistoria(HistoriaClinica nuevaHistoria, Paciente paciente)
        //{
        //    paciente.HistClinica = new HistoriaClinica();
        //    paciente.HistClinica = nuevaHistoria;
        //}

        //public static bool VerificarHistoriaClinica(Paciente paciente)
        //{
        //    if (paciente.HistClinica != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        //public static void GenerarHistoriaClinica(Paciente paciente)
        //{
        //    //Paciente p = new Paciente();
        //    string dni = paciente.Dni;
        //    Console.WriteLine("Se genera historia con los siguientes datos:");
        //    var Codespecialidad = enumCodEspecialidades.dsfsdfds;
        //    //var codEspecialidad = enumCodEspecialidades.dsfsdfds;
        //    DateTime fechaAdmision = DateTime.Now;
        //    int peso = new Random().Next(80);
        //    string talla = (new Random().NextDouble() * 10).ToString();
        //    //string dni = (new Random().Next(99999999)).ToString();
        //    Console.WriteLine($"Especialidad:\t{Codespecialidad}");
        //    //Console.WriteLine($"codEspecialidad:\t{codEspecialidad}");
        //    Console.WriteLine($"Fecha de admision:\t{fechaAdmision}");
        //    Console.WriteLine($"Peso:\t{peso}");
        //    Console.WriteLine($"Talla:\t{talla}");
        //    Console.WriteLine($"Dni:\t{paciente.Dni}");
        //    HistoriaClinica historia = new HistoriaClinica(Codespecialidad, fechaAdmision, peso, talla, paciente.Dni);
        //    AsignarHistoria(historia);
        //}

        //public static void MostrarHistoriaClinica(Paciente paciente)
        //{
        //    Console.WriteLine("Se imprime historia Clinica de paciente:");
        //    Console.WriteLine($"Nombre:\t{paciente.Nombre}");
        //    Console.WriteLine($"Apellido:\t{paciente.Apellido}");
        //    //Console.WriteLine($"codEspecialidad:\t{codEspecialidad}");
        //    Console.WriteLine($"CodEspecialidad:\t{paciente.HistClinica.COD_Especialidad}");
        //    Console.WriteLine($"FechaApertura:\t{paciente.HistClinica.FechaApertura}");
        //    Console.WriteLine($"Peso:\t{paciente.HistClinica.Peso}");
        //    Console.WriteLine($"Talla:\t{paciente.HistClinica.Talla}");
        //    Console.WriteLine($"Dni:\t{paciente.Dni}");
        //}

        // METODOS DE ADMINISTRACION DE PACIENTES
        //public static void CrearPacienteNuevo(List<PacientesDAL> listPacientes)
        //{
        //    Paciente paciente = new Paciente();
        //    Console.WriteLine("Ingrese nombre de paciente: ");
        //    paciente.Nombre = Console.ReadLine();
        //    Console.WriteLine("Ingrese apellido de paciente: ");
        //    paciente.Apellido = Console.ReadLine();
        //    Console.WriteLine("Ingrese dni de paciente: ");
        //    paciente.Dni = Console.ReadLine();
        //    Console.WriteLine("Ingrese fecha de nacimiento de paciente: (yyyy/mm/dd)");
        //    string dato = Console.ReadLine();
        //    string[] fecha = dato.Split("/");
        //    int year = int.Parse(fecha[0]);
        //    int month = int.Parse(fecha[1]);
        //    int day = int.Parse(fecha[2]);
        //    paciente.fNacimiento = new DateTime(year, month, day);
        //    Console.WriteLine("Seleccione tipo de seguro: Asegurado = 0/ Particular = 1 ");
        //    int tipo = int.Parse(Console.ReadLine());
        //    if (tipo == 0) { paciente.Tipo = enumTipoPaciente.Asegurado; }
        //    else { paciente.Tipo = enumTipoPaciente.Particular; }

        //    // EL USUARIO NUEVO SE AÑADE A LISTA DE PACIENTES
        //}

        //public static void InsertarPaciente(List<Paciente> listPacientes)
        //{
        //    listPacientes.Add()

        //}

        //public static int ActualizarBDPacientes(List<Paciente> listPacientes)
        //{
        //    string path = PacientesDAL.ConexionPacientes();
        //    int updatedLines = 0;
        //    using (StreamWriter outputFile = new StreamWriter($"{path}\\BD\\Pacientes.txt"))
        //    {
        //        // Que solo en estas lineas nos sirve, luego sera un objeto nulo
        //        foreach (var item in listPacientes)
        //        {
        //            string line = $"{item.Dni},{item.Nombre},{item.Apellido}";
        //            outputFile.WriteLine(line);
        //            updatedLines++;
        //        }
        //    }
        //    return updatedLines;
        //}

        //public static void GenerarCita(Paciente paciente, Medico medico, )
        //{

        //}
    }
}