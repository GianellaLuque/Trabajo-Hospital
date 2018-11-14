using System;
using Entities;
using BusinessLayer;

namespace ProyectoMedico
{
    class Program
    {
        static void Main(string[] args)
        {
            PacienteBL Pacientes = new PacienteBL();
            var pacientes = Pacientes.GetPacientes();
            Paciente paciente = new Paciente();
            //Paciente paciente = new Paciente();
            Menu:
            string menu = @"SISTEMA HOSPITALARIO:
            1.  Generar cita.
            2.  Administrar pacientes.
            3.  Administrar personal medico.
            4.  Administrar .
                Ingrese numero para elegir opcion
            ";
            Console.WriteLine(menu);
            int selMain = int.Parse(Console.ReadLine());
            if(selMain == 1)
            {
                Console.WriteLine("Ingrese DNI de paciente");
                var dni = Console.ReadLine();
                paciente = Pacientes.BuscarPaciente(dni);
                if(paciente != null)
                {
                    if (Metodos.VerificarHistoriaClinica(paciente))
                    {
                        //Metodos.GenerarCita();
                    }
                    else
                    {
                        Metodos.GenerarHistoriaClinica(paciente);
                    }
                }
                else
                {
                    Console.WriteLine("No existe paciente con ese DNI");
                }
            }


            //if (paciente.getHistoria() != null)
            //{
            //    Console.WriteLine("Tiene historia");
            //    var h = paciente.getHistoria();
            //    Console.WriteLine($"{h.COD_Especialidad}\n{h.FechaApertura}\n{h.Peso}\n{h.Talla}\n{h.Dni}");

            //}
            //else
            //{
            //    Console.WriteLine("No tiene historia");
            //}

            //    Console.WriteLine("Elija que desea hacer:");
            //    string menuAdministracionPacientes = @"Menu pacientes:
            //    1.  Actualizar paciente.
            //    2.  Insertar paciente.
            //    3.  Eliminar paciente.
            //    ";
            //    Console.WriteLine(menuAdministracionPacientes);
            //    int selPac = int.Parse(Console.ReadLine());
            //    switch (selPac)
            //    {
            //        case 1:
            //            //PacienteBL.ActualizarPaciente();
            //            break;
            //    }
            //PacienteBL pacienteBL = new PacienteBL();
            //var pacientes = pacienteBL.GetPacientes();

            //foreach (var item in pacientes)
            //{
            //    Console.WriteLine($"{item.Dni},{item.Nombre},{item.Apellido},{item.fNacimiento},{item.Tipo}");
            //}
            //break;
        }
    }
}
