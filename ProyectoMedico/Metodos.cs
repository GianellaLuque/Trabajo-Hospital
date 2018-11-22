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
        //MedicoBL bl = new MedicoBL();
        // METODOS DE ADMINISTRACION DE PACIENTES
        public static async Task<List<Paciente>> GetPacientes()
        {
            PacienteBL bl = new PacienteBL();
            return await bl.GetPacientesAsync();
        }

        public static async Task<Paciente> BuscarPaciente(string dni)
        {
            PacienteBL bl = new PacienteBL();
            return await bl.BuscarPacienteAsync(dni);
        }

        public static async Task<int> InsertarPaciente()
        {
            Paciente paciente = new Paciente();
            PacienteBL bl = new PacienteBL();
            IngresarDni:
            Console.WriteLine("Ingrese Dni:");
            string Dni = Console.ReadLine();
            if (Dni.Length != 8)
            {
                Console.WriteLine("Ingrese de nuevo (8 digitos)");
                goto IngresarDni;
            }
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
        public static async Task<int> InsertarMedico()
        {
            bool Validado = await ValidarMedico();
            if (!Validado)
            {
                Console.WriteLine("Validacion incorrecta");
                return 0;
            }

            MedicoBL bl = new MedicoBL();
            var medico = new Medico();
            Console.WriteLine("Ingrese CMP");
            medico.CMP = Console.ReadLine();
            var especialidades = await GetEspecialidades();
            Console.WriteLine("LISTA ESPECIALIDADES");
            foreach (var item in especialidades) { Console.WriteLine(item); }
            Console.WriteLine("Ingrese Especialidad");
            medico.Especialidad = Console.ReadLine();
            Console.WriteLine("Ingrese Dni");
            medico.Dni = Console.ReadLine();
            Console.WriteLine("Ingrese Nombre");
            medico.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido");
            medico.Apellido = Console.ReadLine();
            return await bl.InsertMedicoAsync(medico);

        }
        public static async Task<bool> ValidarMedico()
        {
            bool Aceptado = false;
            MedicoBL bl = new MedicoBL();
            Console.WriteLine("Ingrese Usuario");
            string CMP = Console.ReadLine();
            Console.WriteLine("Ingrese Contraseña");
            string Dni = Console.ReadLine();
            var listaMedicos = await GetMedicos();
            if(listaMedicos.Count != 0)
            {
                foreach(var item in listaMedicos)
                {
                    if(item.CMP == CMP && item.Dni == Dni)
                    {
                        Aceptado = true;
                        break;
                    }
                }
                return Aceptado; 
            }
            else
            {
                if (CMP == "admin" && Dni == "1234")
                {
                    return true;
                }
                else { return false; }
            }
        }



        // METODOS DE ADMINISTRACION DE HISTORIAS CLINICAS
        public static async Task<List<HistoriaClinica>> GetHistoriasClinicas()
        {
            HistoriaClinicaBL bl = new HistoriaClinicaBL();
            return await bl.GetHistoriaClinicaAsync();
        }

        public static async Task<HistoriaClinica> BuscarHistoriaClinica()
        {
            IngresarDni:
            Console.WriteLine("Ingrese Dni:");
            string Dni = Console.ReadLine();
            if (Dni.Length != 8)
            {
                Console.WriteLine("Ingrese de nuevo (8 digitos)");
                goto IngresarDni;
            }
            HistoriaClinicaBL bl = new HistoriaClinicaBL();
            return await bl.BuscarHistoriaClinicaAsync(Dni);
        }

        public static async Task<int> UpdateHistoriaClinica(HistoriaClinica historia)
        {
            IngresarDni:
            Console.WriteLine("Ingrese Dni:");
            string Dni = Console.ReadLine();
            if (Dni.Length != 8)
            {
                Console.WriteLine("Ingrese de nuevo (8 digitos)");
                goto IngresarDni;
            }
            HistoriaClinicaBL bl = new HistoriaClinicaBL();
            return await bl.UpdateHistoriaClinicaAsync(historia, Dni);
        }

        public static async Task<int> InsertarHistoriaClinica()
        {
            IngresarDni:
            Console.WriteLine("Ingrese Dni:");
            string Dni = Console.ReadLine();
            if (Dni.Length != 8)
            {
                Console.WriteLine("Ingrese de nuevo (8 digitos)");
                goto IngresarDni;
            }
            HistoriaClinicaBL bl = new HistoriaClinicaBL();
            var historia = new HistoriaClinica();
            Console.WriteLine("Ingrese CodEspecialidad");
            historia.CodEspecialidad = int.Parse(Console.ReadLine());
            //Console.WriteLine("Ingrese Fecha de apertura");
            historia.FechaApertura = DateTime.Now;
            Console.WriteLine("Ingrese Peso");
            historia.Peso = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese Talla");
            historia.Talla = Console.ReadLine();
            //Console.WriteLine("Ingrese Dni");
            historia.Dni = Dni;
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
            Especialidad nuevaEspecialidad = new Especialidad();
            Console.WriteLine("Ingrese CodEspecialidad");
            string CodEspecialidad = Console.ReadLine();
            Console.WriteLine("Ingrese Nueva IdEspecialidad");
            nuevaEspecialidad.IdEspecialidad = Console.ReadLine();
            Console.WriteLine("Ingrese Nueva CodEspecialidad");
            nuevaEspecialidad.CodEspecialidad = CodEspecialidad;
            return await bl.UpdateEspecialidadAsync(nuevaEspecialidad);
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

        public static async Task<int> DeleteEspecialidad()
        {
            EspecialidadBL bl = new EspecialidadBL();
            Console.WriteLine("Ingrese CodEspecialidad");
            string CodEspecialidad = Console.ReadLine();
            return await bl.DeleteEspecialidadesAsync(CodEspecialidad);
        }

        // METODOS DE ADMINISTRACION DE MEDICAMENTOS
        public static async Task<List<Medicamento>> GetMedicamentos()
        {
            MedicamentoBL bl = new MedicamentoBL();
            return await bl.GetListaMedicamentosAsync();
        }
        public static async Task<int> InsertarMedicamento()
        {
            MedicamentoBL bl = new MedicamentoBL();
            Medicamento medicamento = new Medicamento();
            Console.WriteLine("Ingrese CodMedicamento");
            medicamento.CodMedicamento = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese Nombre producto");
            medicamento.NombreProducto = Console.ReadLine();
            Console.WriteLine("Ingrese Presentacion de medicamento");
            medicamento.Presentacion = Console.ReadLine();
            Console.WriteLine("Ingrese Cantidad de medicamento");
            medicamento.Fracciones = int.Parse(Console.ReadLine());
            return await bl.InsertarMedicamentoAsync(medicamento);
        }
        public static async Task<int> UpdateMedicamento()
        {
            MedicamentoBL bl = new MedicamentoBL();
            Medicamento medicamento = new Medicamento();
            Console.WriteLine("Ingrese CodMedicamento");
            medicamento.CodMedicamento = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese nuevo Nombre producto");
            medicamento.NombreProducto = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo Presentacion de medicamento");
            medicamento.Presentacion = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo Cantidad de medicamento");
            medicamento.Fracciones = int.Parse(Console.ReadLine());
            return await bl.UpdateMedicamentoAsync(medicamento);
        }
    }
}