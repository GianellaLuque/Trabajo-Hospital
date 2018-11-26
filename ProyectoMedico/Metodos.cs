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
            return await bl.BuscarPacienteAsync(dni);
        }
        public static async Task<string> ActualizarPaciente()
        {
            var paciente = new Paciente();
            Console.WriteLine("Ingrese Dni:");
            string Dni = Console.ReadLine();
            if (Dni.Length != 8)
            {
                return "Numero de digitos invalidos para Dni";
            }
            var bl = new PacienteBL();
            //await MostrarPacientes();
            if (!await ValidarPaciente(Dni))
            {
                return "Ingrese Dni de paciente valido";
            }
            paciente.Dni = Dni;
            Console.WriteLine("Ingrese nuevo Nombre: ");
            paciente.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo Apellido: ");
            paciente.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese nueva Fecha de nacimiento (YYYY/MM/DD): ");
            paciente.fNacimiento = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo Tipo de seguro (Asegurado/Particular): ");
            paciente.Tipo = Console.ReadLine();
            
            await bl.ActualizarPacienteAsync(paciente);
            return "Actualizacion de paciente exitoso";
        }
        public static async Task<string> InsertarPaciente()
        {
            Console.WriteLine("Ingrese Dni:");
            string Dni = Console.ReadLine();
            if (Dni.Length != 8)
            {
                return "Numerode digitos invalidos para Dni";
            }
            if (await ValidarPaciente(Dni)) { return "Paciente encontrado, ingrese otro Dni"; }
            Paciente paciente = new Paciente();
            PacienteBL bl = new PacienteBL();
            paciente.Dni = Dni;
            Console.WriteLine("Ingrese Nombre: ");
            paciente.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido: ");
            paciente.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese Fecha de nacimiento (YYYY/MM/DD): ");
            paciente.fNacimiento = Console.ReadLine();
            Console.WriteLine("Ingrese Tipo (Interconsulta/Normal): ");
            paciente.Tipo = Console.ReadLine();
            await bl.InsertarPacienteAsync(paciente);
            return "Paciente creado exitosamente";
        }
        public static async Task<int> InsertarPaciente(string Dni)
        {
            Paciente paciente = new Paciente();
            PacienteBL bl = new PacienteBL();
            paciente.Dni = Dni;
            Console.WriteLine("Ingrese Nombre: ");
            paciente.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido: ");
            paciente.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese Fecha de nacimiento (YYYY/MM/DD): ");
            paciente.fNacimiento = Console.ReadLine();
            Console.WriteLine("Ingrese Tipo (Interconsulta/Normal): ");
            paciente.Tipo = Console.ReadLine();
            return await bl.InsertarPacienteAsync(paciente);
        }
        public static async Task<string> EliminarPacientesTodos()
        {
            var bl = new PacienteBL();
            await bl.EliminarPacientesTodo();
            return "Proceso de eliminacion de todos los pacientes exitoso";
        }
        public static async Task<string> EliminarPaciente()
        {
            Console.WriteLine("Ingrese Dni:");
            string Dni = Console.ReadLine();
            if (Dni.Length != 8)
            {
                return "Numero de digitos invalidos para Dni";
            }
            if (!await ValidarPaciente(Dni))
            {
                return "Ingrese Dni de paciente valido";
            }
            var bl = new PacienteBL();
            Console.WriteLine(await ValidarPaciente(Dni));
            await bl.EliminarPaciente(Dni);
            return "Proceso de eliminacion de paciente exitoso";
        }
        public static async Task<int> MostrarPacientes()
        {
            var pacientes = await GetPacientes();
            foreach (var item in pacientes)
            {
                Console.WriteLine(item);
            }
            return 1;
        }
        public static async Task<bool> ValidarPaciente(string Dni)
        {
            var pacientes = await GetPacientes();
            //while (!validar(Dni))
            //{
            //    Console.WriteLine("Ingrese Dni de paciente valido");
            //    Dni = Console.ReadLine();
            //}
            //return "Paciente encontrado";
            if (validar(Dni))
                return true;
            else return false;

            bool validar(string valor)
            {
                foreach (var item in pacientes)
                {
                    if (item.Dni == valor)
                    {
                        return true;
                    }
                }
                return false;
            }
        }


        // METODOS DE ADMINISTRACION DE MEDICOS
        public static async Task<List<Medico>> GetMedicos()
        {
            MedicoBL bl = new MedicoBL();
            return await bl.GetMedicosAsync();
        }
        public static async Task<string> InsertarMedico()
        {
            if (!await ValidarMedico())
            {
                return "Validacion de usuario incorrecta";
            }
            MedicoBL bl = new MedicoBL();
            var medico = new Medico();

            await MostrarEspecialidades();
            Console.WriteLine("Ingrese CMP");
            string CMP = Console.ReadLine();
            Console.WriteLine("Ingrese Especialidad");
            string Especialidad = Console.ReadLine();
            if(await ValidarCMP(CMP) && await ValidarEspecialidad(Especialidad)) { return "Medico en esa especialidad ya asignado"; }
            medico.CMP = CMP;
            medico.Especialidad = Especialidad;
            Console.WriteLine("Ingrese Dni");
            medico.Dni = Console.ReadLine();
            Console.WriteLine("Ingrese Nombre");
            medico.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido");
            medico.Apellido = Console.ReadLine();
            await bl.InsertMedicoAsync(medico);
            return "Creacion de medico exitosa";

        }
        public static async Task<string> EliminarMedico()
        {
            var bl = new MedicoBL();
            Console.WriteLine("Ingrese CMP de medico a eliminar:");
            string cmp = Console.ReadLine();
            if(!await ValidarCMP(cmp)) { return "CMP de medico incorrecto o inexistente"; }
            await bl.EliminarMedicoAsync(cmp);
            return "Medico eliminado exitosamente";
        }
        public static async Task<string> ActualizarMedico()
        {
            if(!await ValidarMedico()) { return "Medico no registrado"; }
            var bl = new MedicoBL();
            var medico = new Medico();
            Console.WriteLine("Ingrese CMP:");
            string cmp = Console.ReadLine();
            if(!await ValidarCMP(cmp)) { return "Medico inexistente o CMP ingresado incorrecto"; }
            medico.CMP = cmp;
            await MostrarEspecialidades();
            Console.WriteLine("Ingrese Especialidad:");
            string CodEspecialidad = Console.ReadLine();
            if(!await ValidarEspecialidad(CodEspecialidad)) { return "Especialidad incorrecta"; }
            medico.Especialidad = CodEspecialidad;
            Console.WriteLine("Ingrese Dni:");
            string Dni = Console.ReadLine();
            if(!await ValidarLongitudDni(Dni)) { return "Numero de digitos no validos para Dni"; }
            medico.Dni = Console.ReadLine();
            Console.WriteLine("Ingrese Nombre:");
            medico.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido:");
            medico.Apellido = Console.ReadLine();

            await bl.ActualizarMedicoAsync(medico);
            return "Medico actualizado exitosamente";

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
        public static async Task<int> MostrarMedicos()
        {
            var medicos = await GetMedicos();
            foreach (var item in medicos)
            {
                Console.WriteLine(item);
            }
            return 1;
        }
        public static async Task<bool> ValidarCMP(string cmp)
        {
            var medicos = await GetMedicos();
            if (validar(cmp))
                return true;
            else return false;

            bool validar(string valor)
            {
                foreach (var item in medicos)
                {
                    if (item.CMP == valor)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public static async Task<bool> ValidarCodEspecialidad(string CodEspecialidad)
        {
            var medicos = await GetMedicos();
            if (validar(CodEspecialidad))
                return true;
            else return false;

            bool validar(string valor)
            {
                foreach (var item in medicos)
                {
                    if (item.Especialidad == valor)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public static async Task<bool> ValidarLongitudDni(string Dni)
        {
            if (Dni.Length != 8) return false;
            else return true;
        }


        // METODOS DE ADMINISTRACION DE HISTORIAS CLINICAS
        public static async Task<List<HistoriaClinica>> GetHistoriasClinicas()
        {
            HistoriaClinicaBL bl = new HistoriaClinicaBL();
            return await bl.GetHistoriaClinicaAsync();
        }
        public static async Task<HistoriaClinica> BuscarHistoriaClinica(string Dni)
        {
            
            HistoriaClinicaBL bl = new HistoriaClinicaBL();
            return await bl.BuscarHistoriaClinicaAsync(Dni);
        }
        public static async Task<string> UpdateHistoriaClinica()
        {
            Console.WriteLine("Ingrese Dni:");
            string Dni = Console.ReadLine();
            if (Dni.Length != 8)
            {
                return "Numerode digitos invalidos para Dni";
            }
            if (!await ValidarPaciente(Dni)) { return "Paciente no encontrado con ese Dni, asegurese de registrarlo primero"; }
            var historia = new HistoriaClinica();
            await MostrarEspecialidades();
            Console.WriteLine("Ingrese CodEspecialidad: ");
            historia.CodEspecialidad = Console.ReadLine();
            //Console.WriteLine("Ingrese : ");
            historia.FechaApertura = DateTime.Now;
            Console.WriteLine("Ingrese Peso: ");
            historia.Peso = Console.ReadLine();
            Console.WriteLine("Ingrese Talla: ");
            historia.Talla = Console.ReadLine();
            //Console.WriteLine("Ingrese CodEspecialidad: ");
            historia.CodEspecialidad = Dni;

            HistoriaClinicaBL bl = new HistoriaClinicaBL();
            await bl.UpdateHistoriaClinicaAsync(historia, Dni);
            return "Historia actualizada con exito";
        }
        public static async Task<string> InsertarHistoriaClinica()
        {
            Console.WriteLine("Ingrese Dni:");
            string Dni = Console.ReadLine();
            if (Dni.Length != 8)
            {
                return "Numerode digitos invalidos para Dni";
            }
            if (!await ValidarPaciente(Dni)){  return "Paciente no encontrado con ese Dni, asegurese de registrarlo primero"; }
            var historia = new HistoriaClinica();
            var bl = new HistoriaClinicaBL();
            Console.WriteLine("Paciente encontrado");
            await MostrarEspecialidades();
            Console.WriteLine("Ingrese CodEspecialidad");
            historia.CodEspecialidad = Console.ReadLine();
            //Console.WriteLine("Ingrese Fecha de apertura");
            historia.FechaApertura = DateTime.Now;
            Console.WriteLine("Ingrese Peso");
            historia.Peso = Console.ReadLine();
            Console.WriteLine("Ingrese Talla");
            historia.Talla = Console.ReadLine();
            //Console.WriteLine("Ingrese Dni");
            historia.Dni = Dni;
            await bl.InsertarHistoriaClinicaAsync(historia);
            return "Historia creada";
        }
        public static async Task<string> EliminarHistoriaClinica()
        {
            Console.WriteLine("Ingrese Dni:");
            string Dni = Console.ReadLine();
            if (Dni.Length != 8)
            {
                return "Numero de digitos invalido";
            }
            if (!await ValidarPaciente(Dni)) { return "Paciente no encontrado con ese Dni, asegurese de registrarlo primero"; }
            var bl = new HistoriaClinicaBL();
            await bl.EliminarHistoriaClinicaAsync(Dni);
            return "Historia clinica eliminada con exito";
        }
        public static async Task<int> InsertarHistoriaClinica(string Dni)
        {
            var historia = new HistoriaClinica();
            var bl = new HistoriaClinicaBL();
            await MostrarEspecialidades();
            Console.WriteLine("Ingrese CodEspecialidad");
            historia.CodEspecialidad = Console.ReadLine();
            //Console.WriteLine("Ingrese Fecha de apertura");
            historia.FechaApertura = DateTime.Now;
            Console.WriteLine("Ingrese Peso");
            historia.Peso = Console.ReadLine();
            Console.WriteLine("Ingrese Talla");
            historia.Talla = Console.ReadLine();
            //Console.WriteLine("Ingrese Dni");
            historia.Dni = Dni;
            return await bl.InsertarHistoriaClinicaAsync(historia);
        }
        public static async Task<int> MostrarHistorias()
        {
            var historias = await GetHistoriasClinicas();
            foreach (var item in historias)
            {
                Console.WriteLine(item);
            }
            return 1;
        }
        public static async Task<bool> ValidarHistoria(string Dni)
        {
            var historias = await GetHistoriasClinicas();
            if (validar(Dni))
                return true;
            else return false;

            bool validar(string valor)
            {
                foreach (var item in historias)
                {
                    if (item.Dni == valor)
                    {
                        return true;
                    }
                }
                return false;
            }
        }


        //METODOS DE ADMINISTRACION DE CITAS
        public static async Task<List<Cita>> GetCitas()
        {
            var bl = new CitaBL();
            return await bl.GetCitasAsync();
        }
        public static async Task<string> GenerarCita()
        {
            CitaBL bl = new CitaBL();
            Cita cita = new Cita();
            Console.WriteLine("Ingrese Dni de paciente: ");
            string Dni = Console.ReadLine();
            if (Dni.Length != 8)
            {
                return "Ingrese numero de digitos validos para Dni";
            }
            //if(!await ValidarCita())
            var pacientes = await GetPacientes();
            var historias = await GetHistoriasClinicas();
            Paciente paciente = await BuscarPaciente(Dni);
            if (paciente != null)
            {
                Console.WriteLine("Paciente encontrado");
                HistoriaClinica historia = await BuscarHistoriaClinica(Dni);
                if (historia != null)
                {
                    Console.WriteLine("Historia clinica encontrada");
                    cita.Dni = Dni;
                    cita.Nombre = paciente.Nombre;
                    cita.Apellido = paciente.Apellido;
                    Console.WriteLine("Ingrese Codigo de especialidad:");
                    string _CodEspecialidad = Console.ReadLine();
                    await ValidarEspecialidad(_CodEspecialidad);
                    cita.CodEspecialidad = _CodEspecialidad;
                    Console.WriteLine("Ingrese Codigo de Doctor (CMP):");
                    cita.CMP = Console.ReadLine();
                    Console.WriteLine("Ingrese tipo Cita:");
                    cita.TipoCita = Console.ReadLine();
                    Console.WriteLine("Ingrese estado de cita");
                    cita.EstadoCita = Console.ReadLine();

                    //Generar codigo cita
                    string zeroWord = cita.CodEspecialidad;
                    string firstWord = cita.Apellido.Substring(0, 3);
                    string secondWord = cita.Nombre.Substring(0, 3);
                    string thirdWord = cita.Dni.Substring(0, 3);
                    string fourthWord = DateTime.Now.Second.ToString();
                    cita.IdCita = zeroWord + firstWord + secondWord + thirdWord + fourthWord;
                    await bl.GenerarCitaAsync(cita);
                    return "Cita creada exitosamente";
                    //return await GenerarCodigoCita(cita);
                }
                else
                {
                    Console.WriteLine("Historia clinica de paciente NO encontrado");
                    Console.WriteLine("Crearemos Historia Clinica");
                    await InsertarHistoriaClinica(Dni);
                    return "Historia clinica exitosamente";
                }
            }
            else
            {
                Console.WriteLine("Paciente NO registrado");
                Console.WriteLine("Crearemos paciente");
                await InsertarPaciente(Dni);
                return "Paciente creado exitosamente";
            }
            
        }
        public static string GenerarCodigoCita(Cita cita)
        {
            string zeroWord = cita.CMP;
            string firstWord = cita.Apellido.Substring(0, 3);
            string secondWord = cita.Nombre.Substring(0, 3);
            string thirdWord = cita.Dni.Substring(0, 3);
            string fourthWord = DateTime.Now.Day.ToString();
            string word = zeroWord + firstWord + secondWord + thirdWord + fourthWord;
            //return word;
            return word;
        }
        public static async Task<string> EliminarCita()
        {
            Console.WriteLine("Ingrese IdCita de paciente del que desea eliminar su cita");
            string IdCita = Console.ReadLine();
            if(!await ValidarCita(IdCita)) { return "Cita no registrada o incorrecta"; }
            var bl = new CitaBL();
            await bl.EliminarCitaAsync(IdCita);
            return "Cita eliminada exitosamente";
        }
        public static async Task<Cita> BuscarCita()
        {
            Console.WriteLine("Ingrese Dni de paciente: ");
            string Dni = Console.ReadLine();
            CitaBL bl = new CitaBL();
            return await bl.BuscarCita(Dni);
        }
        public static async Task<int> MostrarCitas()
        {
            var citas = await GetCitas();
            foreach (var item in citas)
            {
                Console.WriteLine(item);
            }
            return 1;
        }
        public static async Task<bool> ValidarCita(string IdCita)
        {
            var citas = await GetCitas();
            if (validar(IdCita))
            {
                return true;
            }
            return false;

            bool validar(string valor)
            {
                foreach (var item in citas)
                {
                    if (item.IdCita == valor)
                    {
                        return true;
                    }
                }
                return false;
            }
        }


        // METODOS DE ADMINISTRACION DE ESPECIALIDADES
        public static async Task<List<Especialidad>> GetEspecialidades()
        {
            EspecialidadBL bl = new EspecialidadBL();
            return await bl.GetEspecialidadesAsync();
        }
        public static async Task<string> InsertarEspecialidad()
        {
            EspecialidadBL bl = new EspecialidadBL();
            Especialidad especialidad = new Especialidad();
            Console.WriteLine("Ingrese CodEspecialidad");
            string CodEspecialidad = Console.ReadLine();
            if(await ValidarEspecialidad(CodEspecialidad))
            {
                return "Esta especialidad ya existe, ingrese otro codigo";
            }
            //if(!await )
            especialidad.CodEspecialidad = CodEspecialidad;
            Console.WriteLine("Ingrese IdEspecialidad (nombre)");
            especialidad.IdEspecialidad = Console.ReadLine();
            await bl.InsertarEspecialidadAsync(especialidad);
            return "Especialidad creada exitosamente";
        }
        public static async Task<string> UpdateEspecialidad()
        {
            EspecialidadBL bl = new EspecialidadBL();
            Especialidad nuevaEspecialidad = new Especialidad();
            Console.WriteLine("Ingrese CodEspecialidad");
            string CodEspecialidad = Console.ReadLine();
            if (!await ValidarEspecialidad(CodEspecialidad))
            {
                return "Ingrese codigo de especialidad valido";
            }
            nuevaEspecialidad.CodEspecialidad = CodEspecialidad;
            Console.WriteLine("Ingrese Nueva IdEspecialidad");
            nuevaEspecialidad.IdEspecialidad = Console.ReadLine();
            Console.WriteLine("Ingrese Nueva CodEspecialidad");
            nuevaEspecialidad.CodEspecialidad = CodEspecialidad;
            await bl.UpdateEspecialidadAsync(nuevaEspecialidad);
            return "Especialidad actualizada exitosamente";

        }
        public static async Task<string> DeleteEspecialidad()
        {
            EspecialidadBL bl = new EspecialidadBL();
            Console.WriteLine("Ingrese CodEspecialidad");
            string CodEspecialidad = Console.ReadLine();
            if (!await ValidarEspecialidad(CodEspecialidad))
            {
                return "Ingrese codigo de especialidad valido";
            }
            await bl.DeleteEspecialidadesAsync(CodEspecialidad);
            return "Especialidad eliminada exitosamente";
            
        }
        public static async Task<int> MostrarEspecialidades()
        {
            var especialidades = await GetEspecialidades();
            foreach(var item in especialidades)
            {
                Console.WriteLine(item);
            }
            return 1;
        }
        public static async Task<bool> ValidarEspecialidad(string CodEspecialidad)
        {
            var especialidades = await GetEspecialidades();
            if (validar(CodEspecialidad))
            {
                return true;
            }
            return false;

            bool validar(string valor)
            {
                foreach(var item in especialidades)
                {
                    if (item.CodEspecialidad == valor)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        // METODOS DE ADMINISTRACION DE MEDICAMENTOS
        public static async Task<List<Medicamento>> GetMedicamentos()
        {
            MedicamentoBL bl = new MedicamentoBL();
            return await bl.GetListaMedicamentosAsync();
        }
        public static async Task<string> InsertarMedicamento()
        {
            MedicamentoBL bl = new MedicamentoBL();
            Medicamento medicamento = new Medicamento();
            Console.WriteLine("Ingrese CodMedicamento");
            int CodMedicamento = int.Parse(Console.ReadLine());
            if(await ValidarCodMedicamento(CodMedicamento)) { return "Medicamente ya registrado"; }
            medicamento.CodMedicamento = CodMedicamento;
            Console.WriteLine("Ingrese Nombre producto");
            medicamento.NombreProducto = Console.ReadLine();
            Console.WriteLine("Ingrese Presentacion de medicamento");
            medicamento.Presentacion = Console.ReadLine();
            Console.WriteLine("Ingrese Cantidad de medicamento");
            medicamento.Fracciones = int.Parse(Console.ReadLine());
            await bl.InsertarMedicamentoAsync(medicamento);
            return "Medicamento nuevo creado";
        }
        public static async Task<string> UpdateMedicamento()
        {
            MedicamentoBL bl = new MedicamentoBL();
            Medicamento medicamento = new Medicamento();
            Console.WriteLine("Ingrese CodMedicamento");
            int CodMedicamento = int.Parse(Console.ReadLine());
            if (!await ValidarCodMedicamento(CodMedicamento)) { return "Cod de medicamento no registrado"; }
            medicamento.CodMedicamento = CodMedicamento;
            Console.WriteLine("Ingrese nuevo Nombre producto");
            medicamento.NombreProducto = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo Presentacion de medicamento");
            medicamento.Presentacion = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo Cantidad de medicamento");
            medicamento.Fracciones = int.Parse(Console.ReadLine());
            await bl.UpdateMedicamentoAsync(medicamento);
            return "Medicamento actualizado";
        }
        public static async Task<string> EliminarMedicamento()
        {
            var bl = new MedicamentoBL();
            Console.WriteLine("Ingrese CodMedicamento");
            int CodMedicamento = int.Parse(Console.ReadLine());
            if (!await ValidarCodMedicamento(CodMedicamento)) { return "Cod de medicamento no registrado"; }
            await bl.EliminarMedicamentoAsync(CodMedicamento);
            return "Medicamento eliminado exitosamente";
        }
        public static async Task<int> MostrarMedicamentos()
        {
            var medicamentos = await GetMedicamentos();
            foreach (var item in medicamentos)
            {
                Console.WriteLine(item);
            }
            return 1;
        }
        public static async Task<bool> ValidarCodMedicamento(int CodMedicamento)
        {
            var medicamentos = await GetMedicamentos();
            if (validar(CodMedicamento))
            {
                return true;
            }
            return false;

            bool validar(int valor)
            {
                foreach (var item in medicamentos)
                {
                    if (item.CodMedicamento == valor)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}