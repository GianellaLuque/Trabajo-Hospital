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
            MedicoBL dal = new MedicoBL();
            ListaMedicos = await dal.GetMedicosAsync();
            return ListaMedicos;
        }
    }
}
