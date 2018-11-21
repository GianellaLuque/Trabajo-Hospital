using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using BusinessLayer;
using System.Threading.Tasks;


namespace Entities
{
    public static class Metodos
    {
        
        // METODOS DE ADMINISTRACION DE PACIENTES
        public static async Task<List<Paciente>> GetPacientes()
        {
            PacienteBL bl = new PacienteBL();
            return await bl.GetPacientesAsync();
        }

        public static async Task<Paciente> BuscarPaciente(string dni)
        {
            PacienteBL bl = new PacienteBL();
            return await bl.BuscarPaciente(dni);
        }

        public static async Task<int> InsertarPaciente()
        {
            Paciente paciente = new Paciente();
            PacienteBL bl = new PacienteBL();
            Console.WriteLine("Ingrese Dni");
            paciente.Dni = Console.ReadLine();
            Console.WriteLine("Ingrese Nombre");
            paciente.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido");
            paciente.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese Fecha de nacimiento");
            paciente.fNacimiento = Console.ReadLine();
            Console.WriteLine("Ingrese Tipo");
            paciente.Tipo = Console.ReadLine();
            return await bl.InsertarPacienteAsync(paciente);
        }

        // METODOS DE ADMINISTRACION DE MEDICOS
        public static async Task<List<Medico>> GetMedicos()
        {
            MedicoBL bl = new MedicoBL();
            return await bl.GetMedicosAsync();
        }

        // METODOS DE ADMINISTRACION DE HISTORIAS CLINICAS
        public static async Task<List<HistoriaClinica>> GetHistoriasClinicas()
        {
            HistoriaClinicaBL bl = new HistoriaClinicaBL();
            return await bl.GetHistoriaClinicaAsync();
        }

        public static async Task<HistoriaClinica> BuscarHistoriaClinica(string dni)
        {
            HistoriaClinicaBL bl = new HistoriaClinicaBL();
            return await bl.BuscarHistoriaClinicaAsync(dni);
        }

        public static async Task<int> UpdateHistoriaClinica(HistoriaClinica historia, int dni)
        {
            HistoriaClinicaBL bl = new HistoriaClinicaBL();
            return await bl.UpdateHistoriaClinicaAsync(historia, dni);
        }

        public static async Task<int> InsertarHistoriaClinica(HistoriaClinica historia)
        {
            HistoriaClinicaBL bl = new HistoriaClinicaBL();
            Console.WriteLine("Ingrese CodEspecialidad");
            historia.CodEspecialidad = int.Parse(Console.ReadLine());
            //Console.WriteLine("Ingrese Fecha de apertura");
            historia.FechaApertura = DateTime.Now;
            Console.WriteLine("Ingrese Peso");
            historia.Peso = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese Talla");
            historia.Talla = Console.ReadLine();
            Console.WriteLine("Ingrese Dni");
            historia.Dni = Console.ReadLine();
            return await bl.InsertarHistoriaClinicaAsync(historia);
        }

        //METODOS DE ADMINISTRACION DE CITAS
        public static async Task<int> GenerarCita(Paciente paciente)
        {
            CitaBL bl = new CitaBL();
            Cita cita = new Cita();
            //Console.WriteLine("Ingrese Dni");
            cita.Dni = paciente.Dni;
            cita.Nombre = paciente.Nombre;
            cita.Apellido = paciente.Apellido;
            Console.WriteLine("Ingrese Codigo de especialidad");
            //string temp = Console.ReadLine();
            //cita.CodEspecialidad = (enumCodEspecialidades)(int.Parse(Console.ReadLine()));
            cita.CodEspecialidad = Console.ReadLine();
            Console.WriteLine("Ingrese Codigo de Doctor");
            cita.CodDoctor = Console.ReadLine();
            Console.WriteLine("Ingrese tipo Cita: ");
            //Console.WriteLine("Interconsulta: 0 ");
            //Console.WriteLine("Normal: 1 ");
            cita.TipoCita = Console.ReadLine();
            Console.WriteLine("Ingrese estado de cita");
            //Console.WriteLine("Pendiente: 0 ");
            //Console.WriteLine("Realizado: 1 ");
            //Console.WriteLine("Cancelado: 2 ");
            cita.EstadoCita = Console.ReadLine();

            return await bl.GenerarCitaAsync(cita);
        }

        public static string GenerarCodigoCita(Cita cita)
        {
            string firstWord = cita.Apellido.Substring(0, 3);
            string secondWord = cita.Nombre.Substring(0, 3);
            string thirdWord = cita.Dni.Substring(0, 3);
            string fourthWord = DateTime.Now.Day.ToString();
            string word = firstWord + secondWord + thirdWord + fourthWord;
            return word;
        }

        public static async Task<Cita> BuscarCita(string dni)
        {
            CitaBL bl = new CitaBL();
            return await bl.BuscarCita(dni);
        }

        // METODOS DE ADMINISTRACION DE ESPECIALIDADES
        public static async Task<List<Especialidad>> GetEspecialidades()
        {
            EspecialidadBL bl = new EspecialidadBL();
            return await bl.GetEspecialidadesAsync();
        }

        public static async Task<int> UpdateEspecialidad()
        {
            EspecialidadBL bl = new EspecialidadBL();
            Console.WriteLine("Ingrese IdEspecialidad");
            string IdEspecialidad = Console.ReadLine();
            return await bl.UpdateEspecialidadAsync(IdEspecialidad);
        }

        public static async Task<int> InsertarEspecialidad()
        {
            EspecialidadBL bl = new EspecialidadBL();
            Especialidad especialidad = new Especialidad();
            Console.WriteLine("Ingrese CodEspecialidad");
            especialidad.CodEspecialidad = Console.ReadLine();
            Console.WriteLine("Ingrese IdEspecialidad (nombre)");
            especialidad.IdEspecialidad = Console.ReadLine();
            return await bl.InsertarEspecialidadAsync(especialidad);
        }
    }
}