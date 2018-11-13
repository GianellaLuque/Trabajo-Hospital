using System;
using Entities;
using BusinessLayer;

namespace ProyectoMedico
{
    class Program
    {
        static void Main(string[] args)
        {
            string menu = @"SISTEMA HOSPITALARIO:
            1.  Generar cita.
            2.  Administrar pacientes.
            3.  Administrar personal medico.
            4.  Otros.
                Ingrese numero para elegir opcion
            ";
            Console.WriteLine(menu);
            int selMain = int.Parse(Console.ReadLine());
            switch (selMain)
            {
                case 1:
                    Console.WriteLine("Ingrese DNI de paciente");
                    var dni = Console.ReadLine();
                    Console.WriteLine(Metodos.BuscarPaciente(dni));
                    break;
                case 2:
                    Console.WriteLine("Elija que desea hacer:");
                    string menuAdministracionPacientes = @"Menu pacientes:
                    1.  Actualizar paciente.
                    2.  Insertar paciente.
                    3.  Eliminar paciente.
                    ";
                    Console.WriteLine(menuAdministracionPacientes);
                    int selPac = int.Parse(Console.ReadLine());
                    switch (selPac)
                    {
                        case 1:
                            PacienteBL.ActualizarPaciente("12345678");
                            break;
                    }
                    PacienteBL pacienteBL = new PacienteBL();
                    var pacientes = pacienteBL.GetPacientes();

                    foreach (var item in pacientes)
                    {
                        Console.WriteLine($"{item.Dni},{item.Nombre},{item.Apellido},{item.fNacimiento},{item.Tipo}");
                    }
                    break;
            }
        }
    }
}
