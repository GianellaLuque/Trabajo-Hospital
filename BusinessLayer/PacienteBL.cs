using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Entities;
using DataAccess;


namespace BusinessLayer
{
    public class PacienteBL
    {
        public static List<Paciente> ListPacientes;
        

        // METODO PARA OBTENER HISTORIA CLINICA
        

        // METODO PARA OBTENER PACIENTES
        public List<Paciente> GetPacientes()
        {
            string path = PacientesDAL.ConexionPacientes();
            string[] lines = File.ReadAllLines($"{path}\\BD\\Pacientes.txt");
            DateTime FNacimiento = DateTime.Now;
            enumTipoPaciente TipoSeguro = enumTipoPaciente.Asegurado;
            ListPacientes = new List<Paciente>();
            

            //Paciente paciente = new Paciente();
            foreach (var item in lines)
            {
                string Dni = item.Split('%')[0];
                string Nombre = item.Split('%')[1];
                string Apellido = item.Split('%')[2];
                Paciente p = new Paciente(Dni, Nombre, Apellido, FNacimiento, TipoSeguro);
                ListPacientes.Add(p);
            }
            return ListPacientes;
        }

        //public static void CrearPacienteNuevo()
        //{
        //    //Paciente paciente = new Paciente();
        //    //Console.WriteLine("Ingrese nombre de paciente: ");
        //    //paciente.Nombre = Console.ReadLine();
        //    //Console.WriteLine("Ingrese apellido de paciente: ");
        //    //paciente.Apellido = Console.ReadLine();
        //    //Console.WriteLine("Ingrese dni de paciente: ");
        //    //paciente.Dni = Console.ReadLine();
        //    //Console.WriteLine("Ingrese fecha de nacimiento de paciente: (yyyy/mm/dd)");
        //    string dato = Console.ReadLine();
        //    string[] fecha = dato.Split("/");
        //    int year = int.Parse(fecha[0]);
        //    int month = int.Parse(fecha[1]);
        //    int day = int.Parse(fecha[2]);
        //    paciente.fNacimiento = new DateTime(year, month, day);
        //    Console.WriteLine("Seleccione tipo de seguro: Asegurado = 0/ Particular = 1 ");
        //    int tipo = int.Parse(Console.ReadLine());
        //    if (tipo == 0) { paciente.Tipo = enumTipoPaciente.Asegurado; }
        //    else { paciente.Tipo = enumTipoPaciente.Particular; }

        //    // EL USUARIO NUEVO SE AÑADE A LISTA DE PACIENTES
        //}

        public static int ActualizarBDPacientes(List<Paciente> listPacientes)
        {
            string path = PacientesDAL.ConexionPacientes();
            int updatedLines = 0;
            using (StreamWriter outputFile = new StreamWriter($"{path}\\BD\\Pacientes.txt"))
            {
                // Que solo en estas lineas nos sirve, luego sera un objeto nulo
                foreach (var item in listPacientes)
                {
                    string line = $"{item.Dni}%{item.Nombre}%{item.Apellido}";
                    outputFile.WriteLine(line);
                    updatedLines++;
                }
            }
            return updatedLines;
        }

        // METODO PARA ENCONTRAR PACIENTES
        public Paciente BuscarPaciente(string dni)
        {
            Paciente p = null;
            foreach (Paciente item in ListPacientes)
            {
                if (item.Dni == dni)
                {
                    p = item;
                    break;
                }
            }
            return p;
        }

        // METODO PARA EDITAR PACIENTES
        public static void ActualizarPaciente(string dni, Paciente paciente)
        {
            bool flag = false;
            foreach (Paciente item in ListPacientes)
            {
                if (item.Dni == dni)
                {
                    item.Nombre = paciente.Nombre;
                    item.Apellido = paciente.Apellido;
                    flag = true;
                    if (flag) { UpdateDataBase(); break; }
                }
            }
        }

        public static void InsertarPaciente(Paciente paciente)
        {
            ListPacientes.Add(paciente);
            UpdateDataBase();
        }

        public static int DeletePaciente(string Dni)
        {
            int elementsRemoved = ListPacientes.RemoveAll(x => x.Dni == Dni); //Linq, metodo para remover, es como un for
            UpdateDataBase();
            return elementsRemoved;

            //int indice = 0;
            //foreach(Paciente item in Listpacientes)
            //{
            //    if(item.Dni == Dni)
            //    {
            //        break;
            //    }
            //    indice++;
            //}
        }

        public static int UpdateDataBase()
        {
            string path = PacientesDAL.ConexionPacientes();
            int updatedLines = 0;
            using (StreamWriter outputFile = new StreamWriter($"{path}\\BD\\Pacientes.txt"))
            {
                // Que solo en estas lineas nos sirve, luego sera un objeto nulo
                foreach (var item in ListPacientes)
                {
                    string line = $"{item.Dni},{item.Nombre},{item.Apellido}";
                    outputFile.WriteLine(line);
                    updatedLines++;
                }
            }
            return updatedLines;
        }
    }
}
