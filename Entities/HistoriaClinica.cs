using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class HistoriaClinica
    {
        public string CodEspecialidad { get; set; }
        public DateTime FechaApertura { get; set; }
        public string Peso { get; set; }
        public string Talla { get; set; }
        public string Dni { get; set; }

        //CONSTRUCTOR
        public HistoriaClinica()
        {

        }
        public HistoriaClinica(string codEspecialidad, DateTime fechaAp, string peso, string talla, string dni)
        {
            CodEspecialidad = codEspecialidad;
            FechaApertura = fechaAp;
            Peso = peso;
            Talla = talla;
            Dni = dni;
        }

        public override string ToString()
        {
            return string.Format("CodEspecialidad = {0}, Fecha Apertura = {1}, Peso = {2}, Talla = {3}, Dni = {4}", CodEspecialidad, FechaApertura, Peso, Talla, Dni);
        }
    }

}
