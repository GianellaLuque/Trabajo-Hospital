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
            2.  Administracion de pacientes.
            3.  Administracion de personal medico.
            4.  Administracion de stock en farmacia
            5.  Modulo, diagnostico, receta de medicamentos y reportes. 
                Ingrese numero para elegir opcion
            ";
            Console.WriteLine(menu);
            int selMain = int.Parse(Console.ReadLine());

            // GENERAR CITA
            if (selMain == 1)
            {
                Console.WriteLine("Ingrese DNI de paciente");
                var dni = Console.ReadLine();
                paciente = Pacientes.BuscarPaciente(dni);
                if(paciente != null)
                {
                    if (HistoriaClinicaBL.VerificarHistoriaClinica(paciente))
                    {
                        Console.WriteLine("Tiene historia");
                        //Metodos.GenerarCita();
                        goto Menu;
                    }
                    else
                    {
                        Console.WriteLine("No tiene historia");

                        Console.WriteLine("Crearemos historia clinica nueva");
                        HistoriaClinica hClinica = new HistoriaClinica();
                        Console.WriteLine("Selecciones codigo especialidad: ");
                        Console.WriteLine("Genearal = 1");
                        Console.WriteLine("Pediatria: 2");
                        Console.WriteLine("Ginecologia = 3");
                        Console.WriteLine("Traumatologia = 4");
                        Console.WriteLine("Oftalmologia: 5");
                        Console.WriteLine("Neurologia: 6");
                        int selEspec = int.Parse(Console.ReadLine());
                        if (selEspec == 1)
                        {
                            hClinica.CodEspecialidad = ((int)enumEspecialidades.General).ToString();
                        }
                        if (selEspec == 2)
                        {
                            hClinica.CodEspecialidad = ((int)enumEspecialidades.Pediatria).ToString();
                        }
                        if (selEspec == 3)
                        {
                            hClinica.CodEspecialidad = ((int)enumEspecialidades.Ginecologia).ToString();
                        }
                        if (selEspec == 4)
                        {
                            hClinica.CodEspecialidad = ((int)enumEspecialidades.Traumatologia).ToString();
                        }
                        if (selEspec == 5)
                        {
                            hClinica.CodEspecialidad = ((int)enumEspecialidades.Oftalmologia).ToString();
                        }
                        if (selEspec == 6)
                        {
                            hClinica.CodEspecialidad = ((int)enumEspecialidades.Neurologia).ToString();
                        }

                        hClinica.FechaApertura = DateTime.Now;
                        Console.WriteLine("Ingrese apellido de paciente: ");
                        nuevoPaciente.Apellido = Console.ReadLine();
                        Console.WriteLine("Ingrese dni de paciente: ");
                        nuevoPaciente.Dni = Console.ReadLine();
                        HistoriaClinicaBL.GenerarHistoriaClinica(paciente);
                        goto Menu;
                    }
                }
                else
                {
                    // CREACION DE PACIENTE NUEVO

                    Console.WriteLine("No existe paciente con ese DNI");
                    Console.WriteLine("Crearemos paciente nuevo;");
                    Paciente nuevoPaciente = new Paciente();
                    Console.WriteLine("Ingrese nombre de paciente: ");
                    nuevoPaciente.Nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese apellido de paciente: ");
                    nuevoPaciente.Apellido = Console.ReadLine();
                    Console.WriteLine("Ingrese dni de paciente: ");
                    nuevoPaciente.Dni = Console.ReadLine();
                    Console.WriteLine("Ingrese fecha de nacimiento de paciente: (yyyy/mm/dd)");
                    nuevoPaciente.fNacimiento = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Seleccione tipo de seguro: Asegurado = 0/ Particular = 1 ");
                    int tipo = int.Parse(Console.ReadLine());
                    if (tipo == 0) { nuevoPaciente.Tipo = enumTipoPaciente.Asegurado; }
                    else { nuevoPaciente.Tipo = enumTipoPaciente.Particular; }

                    //INSERTAMOS A LISTAPACIENTES PACIENTE NUEVO
                    pacientes.Add(nuevoPaciente);
                    PacienteBL.ActualizarBDPacientes(pacientes);
                }
            }


            //if(selMain == 2)
            //{
            //    Metodos.MostrarHistoriaClinica(paciente);
            //}

            //if(selMain == 4)
            //{

            //}

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
