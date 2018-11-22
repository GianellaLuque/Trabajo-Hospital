using System;
using System.Collections.Generic;
using Entities;
using DataAccess;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class MedicoBL
    {
        public static List<Medico> ListaMedicos;
        public async Task<List<Medico>> GetMedicosAsync()
        {
            MedicoDAL dal = new MedicoDAL();
            ListaMedicos = await dal.GetMedicosAsync();
            return ListaMedicos;
        }
        public async Task<int> InsertMedicoAsync(Medico medico)
        {
            MedicoDAL dal = new MedicoDAL();
            return await dal.InsertarMedicoAsync(medico);
        }
        public async Task<int> UpdateMedicoAsync(Medico medico)
        {
            MedicoDAL dal = new MedicoDAL();
            return await dal.UpdateMedicoAsyn(medico);
        }
    }
}