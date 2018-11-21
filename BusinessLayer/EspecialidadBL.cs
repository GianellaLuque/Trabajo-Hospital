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

        public async Task<int> UpdateEspecialidadAsync(string IdEspecialidad)
        {
            EspecialidadDAL dal = new EspecialidadDAL();
            ListaEspecialidades = await GetEspecialidadesAsync();
            Especialidad especialidad = new Especialidad();
            
            foreach (var item in ListaEspecialidades)
            {
                if (item.IdEspecialidad == IdEspecialidad)
                {
                    especialidad = item;
                    break;
                }
            }
            return await dal.UpdateEspecialidadAsync(especialidad);
        }
    }
}
