using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using DataAccess;


namespace BusinessLayer
{
    public class PacienteBL
    {
        public static List<Paciente> ListPacientes;
        public List<Paciente> GetPacientes()
        {
            string path = PacientesDAL.ConexionPacientes();
            string[] lines = System.IO.File.ReadAllLines($"{path}\\BD\\Pacientes.txt");
            ListPacientes = new List<Paciente>();
            foreach (var item in lines)
            {
                string Dni = item.Split(',')[0];
                string nombre = item.Split(',')[1];
                string Apellido = item.Split(',')[2];
                Paciente p = new Paciente(Dni, nombre, Apellido);
                ListPacientes.Add(p);
            }
            return ListPacientes;
        }
    }
}
