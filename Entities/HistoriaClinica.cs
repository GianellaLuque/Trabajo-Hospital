using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class HistoriaClinica
    {
        public enumEspecialidades COD_Especialidad { get; set; }
        public DateTime FechaApertura { get; set; }
        public int Peso { get; set; }
        public string Talla { get; set; }
        public string Dni { get; set; }

        //CONSTRUCTOR
        public HistoriaClinica()
        {

        }
        public HistoriaClinica(enumEspecialidades especialidad, DateTime fechaAp, int peso, string talla, string dni)
        {
            COD_Especialidad = especialidad;
            FechaApertura = fechaAp;
            Peso = peso;
            Talla = talla;
            Dni = dni;
        }

        //METODOS

    }

}
