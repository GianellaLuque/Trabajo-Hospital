using System.Collections.Generic;
using Entities;
using DataAccess;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class HistoriaClinicaBL
    {
        public static List<HistoriaClinica> ListHistoriaClinica;

        // METODOS
        public async Task<List<HistoriaClinica>> GetHistoriaClinicaAsync()
        {
            HistoriaClinicaDAL dal = new HistoriaClinicaDAL();
            ListHistoriaClinica = await dal.GetHistoriaClinicaAsync();
            return ListHistoriaClinica;
        }

        public async Task<int> InsertarHistoriaClinicaAsync(HistoriaClinica historia)
        {
            HistoriaClinicaDAL dal = new HistoriaClinicaDAL();
            return await dal.InsertarHistoriaClinicaAsync(historia);
        }
        //public List<HistoriaClinica> GetHistoriaClinica()
        //{
        //    string path = HistoriaClinicaDAL.ConexionHistoriaClinica();
        //    string[] lineas = File.ReadAllLines($"{path}\\BD\\HistoriasClinicas.txt");

        //    foreach(var item in lineas)
        //    {
        //        int codEspecialidad = Convert.ToInt32(item.Split("%")[0]);
        //        //Enum.TryParse(codEspecialidad, out enumCodEspecialidades codEspec);
        //        DateTime fechaApertura = Convert.ToDateTime(item.Split("%")[1]);
        //        int Peso = int.Parse(item.Split("%")[2]);
        //        string Talla= item.Split("%")[3];
        //        string Dni = item.Split("%")[4];
        //        HistoriaClinica h = new HistoriaClinica(codEspecialidad, fechaApertura, Peso, Talla, Dni);
        //        ListHistoriaClinica.Add(h);
        //    }
        //    return ListHistoriaClinica;
        //}


        //public static void MostrarHistoriaClinica(Paciente paciente)
        //{
        //    Console.WriteLine("Se imprime historia Clinica de paciente:");
        //    Console.WriteLine($"Nombre:\t{paciente.Nombre}");
        //    Console.WriteLine($"Apellido:\t{paciente.Apellido}");
        //    //Console.WriteLine($"codEspecialidad:\t{codEspecialidad}");
        //    Console.WriteLine($"CodEspecialidad:\t{paciente.HistClinica.CodEspecialidad}");
        //    Console.WriteLine($"FechaApertura:\t{paciente.HistClinica.FechaApertura}");
        //    Console.WriteLine($"Peso:\t{paciente.HistClinica.Peso}");
        //    Console.WriteLine($"Talla:\t{paciente.HistClinica.Talla}");
        //    Console.WriteLine($"Dni:\t{paciente.Dni}");
        //}

        //public static Paciente GenerarHistoriaClinica(string dni)
        //{
        //    //HistoriaClinica hClinica = new HistoriaClinica();
        //    Paciente paciente = new Paciente();
        //    Console.WriteLine("Selecciones codigo especialidad: ");
        //    Console.WriteLine("General = 1");
        //    //Console.WriteLine("Pediatria: 2");
        //    //Console.WriteLine("Ginecologia = 3");
        //    //Console.WriteLine("Traumatologia = 4");
        //    //Console.WriteLine("Oftalmologia: 5");
        //    //Console.WriteLine("Neurologia: 6");
        //    int selEspec = int.Parse(Console.ReadLine());
        //    if (selEspec == 1)
        //    {
        //        paciente.HistClinica.CodEspecialidad = 1234;
        //        paciente.HistClinica.CodEspecialidad = 124;
        //        //paciente.HistClinica.CodEspecialidad = Convert.ToString(p);
        //        //int p = Convert.ToInt32((int)enumEspecialidades.General);
        //    }
        //    //if (selEspec == 2)
        //    //{
        //    //    paciente.HistClinica.CodEspecialidad = ((int)enumEspecialidades.Pediatria).ToString();
        //    //}
        //    //if (selEspec == 3)
        //    //{
        //    //    paciente.HistClinica.CodEspecialidad = ((int)enumEspecialidades.Ginecologia).ToString();
        //    //}
        //    //if (selEspec == 4)
        //    //{
        //    //    paciente.HistClinica.CodEspecialidad = ((int)enumEspecialidades.Traumatologia).ToString();
        //    //}
        //    //if (selEspec == 5)
        //    //{
        //    //    paciente.HistClinica.CodEspecialidad = ((int)enumEspecialidades.Oftalmologia).ToString();
        //    //}
        //    //if (selEspec == 6)
        //    //{
        //    //    paciente.HistClinica.CodEspecialidad = ((int)enumEspecialidades.Neurologia).ToString();
        //    //}

        //    paciente.HistClinica.FechaApertura = DateTime.Now;
        //    Console.WriteLine("Ingrese Peso: ");
        //    paciente.HistClinica.Peso = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Ingrese talla: ");
        //    paciente.HistClinica.Talla = Console.ReadLine();
        //    Console.WriteLine($"Se asingo el Dni de paciente: {paciente.Dni}");

        //    return paciente;
        //    // Se agrega historia a lista
        //    //paciente.HistClinica = hClinica;
        //    //ListHistoriaClinica.Add(hClinica);

        //    // Actualizamos base de datos de Historia Clinica


        //}

        //public static int ActualizarBDHistoriaClinica(List<HistoriaClinica> listHistorias)
        //{
        //    string path = HistoriaClinicaDAL.ConexionHistoriaClinica();
        //    int updatedLines = 0;
        //    using (StreamWriter outputFile = new StreamWriter($"{path}\\BD\\HistoriasClinicas.txt"))
        //    {
        //        // Que solo en estas lineas nos sirve, luego sera un objeto nulo
        //        foreach (var item in listHistorias)
        //        {
        //            string line = $"{item.CodEspecialidad}%{item.FechaApertura}%{item.Peso}%{item.Talla}%{item.Dni}";
        //            outputFile.WriteLine(line);
        //            updatedLines++;
        //        }
        //    }
        //    return updatedLines;
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

        //public static void AgregarHistoriaToLista(List<HistoriaClinica> historia)
        //{

        //}
    }
}
