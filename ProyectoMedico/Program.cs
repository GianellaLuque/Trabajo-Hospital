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
        // INICIO DE PROGRAMA
        
            // INSTANCIAMOS CLASES DE LA CAPA DE ENTIDADES
            HistoriaClinica historia = new HistoriaClinica();
            Especialidad especialidad = new Especialidad();
            Paciente paciente = new Paciente();
            Medico medico = new Medico();
            Cita cita = new Cita();
            string CodigoCita;

            // INSTANCIAMOS CLASES DE LA CAPA DE NEGOCIOS
            HistoriaClinicaBL Historias = new HistoriaClinicaBL();
            //EspecialidadBL especialidades = new EspecialidadBL();
            PacienteBL Pacientes = new PacienteBL();
            MedicoBL Medicos = new MedicoBL();

            // MENU
        Menu:
            string menu = @"SISTEMA HOSPITALARIO:
            1.  Generar cita.
            2.  Administracion de pacientes.
            3.  Administracion de especialidades.
            4.  Administracion de personal medico.
            5.  Administracion de stock en farmacia
            6.  Modulo, diagnostico, receta de medicamentos y reportes. 
                Ingrese numero para elegir opcion
            ";
            Console.WriteLine(menu);
            int selMain = int.Parse(Console.ReadLine());

            if (selMain == 1) await Admision();
            if (selMain == 3) await GestionEspecialidades();
            //if (selMain == 1) await Admision();
            //if (selMain == 1) await Admision();
            //if (selMain == 1) await Admision();
            //if (selMain == 1) await Admision();


            // Buscar paciente y su historial clinico
            async Task Admision()
            {
                ComprobarDni:
                Console.WriteLine("Buscando Paciente");
                Console.WriteLine("Ingrese Dni de paciente");
                string Dni = Console.ReadLine();
                if(Dni.Length != 8)
                {
                    Console.WriteLine("Ingrese de nuevo (8 digitos)");
                    goto ComprobarDni;
                }
                BuscarPaciente:
                paciente = await Metodos.BuscarPaciente(Dni);
                if (paciente != null)
                {
                    Console.WriteLine("Paciente encontrado: ");
                    Console.WriteLine(paciente);
                    BuscarHistoria:
                    historia = await Metodos.BuscarHistoriaClinica(Dni);
                    if (historia != null)
                    {
                        Console.WriteLine("Historia encontrada: ");
                        Console.WriteLine(historia);
                        await GenerarCita();
                    }
                    else
                    {
                        Console.WriteLine("Historia no encontrada: ");
                        await Metodos.InsertarHistoriaClinica(historia);
                        goto BuscarHistoria;
                    }
                }
                else
                {
                    Console.WriteLine("Paciente no encontrado: ");
                    await Metodos.InsertarPaciente();
                    goto BuscarPaciente;
                }
            }

            // Generar cita y codigo de cita
            async Task GenerarCita()
            {
                await Metodos.GenerarCita(paciente);
                cita = await Metodos.BuscarCita(paciente.Dni);
                CodigoCita = Metodos.GenerarCodigoCita(cita);
                Console.WriteLine(cita);
                Console.WriteLine($"Y el codigo de cita es: {CodigoCita}");
            }

            async Task GestionEspecialidades()
            {
                MostrarEspecialidades:
                //List<Especialidad> especialidades = await Metodos.GetEspecialidades();
                //foreach (var item in especialidades)
                //{
                //    //Console.WriteLine($"{item.CodEspecialidad}\t{item.IdEspecialidad}");
                //    Console.WriteLine(item);
                //}
                string MenuEspecialidades = @"SISTEMA HOSPITALARIO:
                1.  Generar especialidad.
                2.  Actualizar especialidad.
                3.  Eliminar especialidad.
                ";
                Console.WriteLine(MenuEspecialidades);
                int selMainEsp = int.Parse(Console.ReadLine());
                if (selMain == 1) { await Metodos.InsertarEspecialidad(); goto MostrarEspecialidades; }
                if (selMain == 3) {await Metodos.UpdateEspecialidad(); goto MostrarEspecialidades;}
            }

            // Diagnostico y receta de medicamentos


        }

        // METODOS
    }
}
