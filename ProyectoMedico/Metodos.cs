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

        public static async Task<int> InsertarPaciente(Paciente paciente)
        {
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
    }
}