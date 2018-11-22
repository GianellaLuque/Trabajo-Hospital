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
            bool salir = false;
            // INSTANCIAMOS CLASES DE LA CAPA DE NEGOCIOS
            HistoriaClinicaBL Historias = new HistoriaClinicaBL();
            //EspecialidadBL especialidades = new EspecialidadBL();
            PacienteBL Pacientes = new PacienteBL();
            MedicoBL Medicos = new MedicoBL();

        // MENU
        Menu:
            Console.Clear();
            string menu = @"MENU PRINCIPAL:
            1.  Generar cita.
            2.  Administracion de pacientes.
            3.  Administracion de especialidades.
            4.  Administracion de medicamentos de farmacia.
            5.  Administracion de stock en farmacia.
            6.  Administracion de personal medico. 

                Ingrese numero para elegir opcion:
            ";
            Console.WriteLine(menu);
            int selMain = int.Parse(Console.ReadLine());

            if (selMain == 1) await Admision(); if (salir) goto Menu;
            //if (selMain == 2) await GestionPacientes(); if (salir) goto Menu;
            if (selMain == 3) await GestionEspecialidades(); if (salir) goto Menu;
            if (selMain == 4) await GestionMedicamentos(); if (salir) goto Menu;
            //if (selMain == 1) await Admision();
            if (selMain == 6) await GestionPersonalMedico(); if (salir) goto Menu;
            //if (selMain == 1) await Admision();


            // Admision y generacion de cita
            async Task Admision()
            {
            Admision:
                var pacientes = await Metodos.GetPacientes();
                var historias = await Metodos.GetHistoriasClinicas();
                var especialidades = await Metodos.GetEspecialidades();
                var medicos = await Metodos.GetMedicos();
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE PACIENTES");
                foreach (var item in pacientes)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE HISTORIAS CLINICAS");
                foreach (var item in historias)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE ESPECIALIDADES");
                foreach (var item in especialidades)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE MEDICOS");
                foreach (var item in medicos)
                {
                    Console.WriteLine(item);
                }
                string MenuAdmision = @"MENU ADMISION:
                1.  Crear paciente.
                2.  Buscar historia clinica.
                3.  Generar historia clinica.
                4.  Generar cita.
                5.  Volver a menu principal.
                ";
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(MenuAdmision);
                int selMainAdm = int.Parse(Console.ReadLine());

                if (selMainAdm == 1){await Metodos.InsertarPaciente();goto Admision;}
                if (selMainAdm == 2)
                {
                    var h = await Metodos.BuscarHistoriaClinica();
                    if(h != null)
                    {
                        Console.WriteLine(h);
                    }
                    else
                    {
                        Console.WriteLine("No tiene historia");
                    }
                    goto Admision;
                }
                if (selMainAdm == 3) { await Metodos.InsertarHistoriaClinica(); goto Admision; }
                if (selMainAdm == 4) { await GenerarCita(); goto Admision; }
                if (selMainAdm == 5) { Console.WriteLine("Volviendo a Menu principal"); salir = true; }
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

            // Gestion de especialidades
            async Task GestionEspecialidades()
            {
                MostrarEspecialidades:
                List<Especialidad> especialidades = await Metodos.GetEspecialidades();
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE ESPECIALIDADES");
                foreach (var item in especialidades)
                {
                    //Console.WriteLine($"{item.CodEspecialidad}\t{item.IdEspecialidad}");
                    Console.WriteLine(item);
                }
                string MenuEspecialidades = @"MENU ESPECIALIDADES:
                1.  Generar especialidad.
                2.  Actualizar especialidad.
                3.  Eliminar especialidad.
                4.  Volver a menu principal.
                ";
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(MenuEspecialidades);
                int selMainEsp = int.Parse(Console.ReadLine());
                if (selMainEsp == 1) { await Metodos.InsertarEspecialidad(); goto MostrarEspecialidades; }
                if (selMainEsp == 2) {await Metodos.UpdateEspecialidad(); goto MostrarEspecialidades;}
                if (selMainEsp == 3) { await Metodos.DeleteEspecialidad(); goto MostrarEspecialidades; }
                if (selMainEsp == 4) { Console.WriteLine("Volviendo a Menu principal"); salir = true; }
            }

            // Diagnostico y receta de medicamentos
            async Task GestionMedicamentos()
            {
                MenuMedicamentos:
                string MenuMedicamentos = @"SISTEMA HOSPITALARIO:
                1.  Insertar Medicamento.
                2.  Actualizar Medicamento.
                3.  Eliminar Medicamento.
                4.  Mostrar Medicamentos.
                5.  Volver a menu principal.
                ";
                Console.WriteLine(MenuMedicamentos);
                int selMainMed = int.Parse(Console.ReadLine());
                if (selMainMed == 1) { await Metodos.InsertarMedicamento(); goto MenuMedicamentos; }
                if (selMainMed == 2) { await Metodos.UpdateMedicamento(); goto MenuMedicamentos; }
                //if (selMainMed == 3) { await Metodos.(); goto MostrarEspecialidades; }
                if (selMainMed == 4)
                {
                    var ListaMedicamentos = await Metodos.GetMedicamentos();
                    foreach (var item in ListaMedicamentos)
                    {
                        Console.WriteLine(ListaMedicamentos);
                    }
                    goto MenuMedicamentos;
                }
                if (selMainMed == 5) { Console.WriteLine("Volviendo a Menu principal"); salir = true; }
            }

            async Task GestionPersonalMedico()
            {
                MostrarMedicos:
                var medicos = await Metodos.GetMedicos();
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("LISTA DE MEDICOS");
                foreach (var item in medicos)
                {
                    Console.WriteLine(item);
                }
                string MenuEspecialidades = @"MENU MEDICOS:
                1.  Crear Medico.
                2.  Actualizar Medico.
                3.  Eliminar Medico.
                4.  Volver a menu principal.
                ";
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(MenuEspecialidades);
                int selMainMed = int.Parse(Console.ReadLine());
                if (selMainMed == 1) { await Metodos.InsertarMedico(); goto MostrarMedicos; }
                //if (selMainMed == 2) { await Metodos.Update(); goto MostrarMedicos; }
                //if (selMainMed == 3) { await Metodos.Dele(); goto MostrarMedicos; }
                if (selMainMed == 4) { Console.WriteLine("Volviendo a Menu principal"); salir = true; }
            }

        }

        // METODOS
    }
}
