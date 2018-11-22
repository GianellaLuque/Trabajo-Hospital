using System.Collections.Generic;
using Entities;
using DataAccess;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EspecialidadBL
    {
        public static List<Especialidad> ListaEspecialidades;
        public async Task<List<Especialidad>> GetEspecialidadesAsync()
        {
            EspecialidadDAL dal = new EspecialidadDAL();
            ListaEspecialidades = await dal.GetEspecialidades();
            return ListaEspecialidades;
        }

        public async Task<int> InsertarEspecialidadAsync(Especialidad especialidad)
        {
            EspecialidadDAL dal = new EspecialidadDAL();
            return await dal.InsertarEspecialidadAsync(especialidad);
        }

        public async Task<int> UpdateEspecialidadAsync(Especialidad newEspecialidad)
        {
            EspecialidadDAL dal = new EspecialidadDAL();
            //ListaEspecialidades = await GetEspecialidadesAsync();
            ////Especialidad especialidad = new Especialidad();
            
            //foreach (var item in ListaEspecialidades)
            //{
            //    if (item.CodEspecialidad == CodEspecialidad)
            //    {
            //        item = newEspecialidad;
            //        break;
            //    }
            //}
            return await dal.UpdateEspecialidadAsync(newEspecialidad);
        }

        public async Task<int> DeleteEspecialidadesAsync(string CodEspecialidad)
        {
            EspecialidadDAL dal = new EspecialidadDAL();
            return await dal.DeleteEspecialidadAsync(CodEspecialidad);
        }
    }
}
