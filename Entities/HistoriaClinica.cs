using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class HistoriaClinica
    {
        public string COD_Especialidad { get; set; }
        public DateTime FechaApertura { get; set; }
        public int Peso { get; set; }
        public string Talla { get; set; }
        public string Dni { get; set; }

        //CONSTRUCTOR
        public HistoriaClinica()
        {

        }
        public HistoriaClinica(string codEspecialidad, DateTime fechaAp, int peso, string talla, string dni)
        {
            COD_Especialidad = codEspecialidad;
            FechaApertura = fechaAp;
            Peso = peso;
            Talla = talla;
            Dni = dni;
        }

        //METODOS

    }

}
