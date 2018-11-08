using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DataAccess
{
    public class PacientesDAL
    {
        public static string ConexionPacientes()
        {
            string pathBDPacientes = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return pathBDPacientes;
        }
    }
}
