using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace DataAccess
{
    public class HistoriaClinicaDAL
    {
        public static string ConexionHistoriaClinica()
        {
            string pathPBHistoriaClinica = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return pathPBHistoriaClinica;
        }
    }
}
