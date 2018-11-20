using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace DataAccess
{
    class MedicoDAL:Conexion
    {
        public async Task<List<Medico>> GetMedicosAsync()
        {
            MySqlConnection MiConexion = AbrirConexionSql();
            string sql = "select * from medicos";
            try
            {
                List<Medico> ListaMedicos = null;
                if (MiConexion != null)
                {
                    ListaMedicos = (await MiConexion.QueryAsync<Medico>(sql)).ToList();
                }
                return ListaMedicos;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (MiConexion.State == System.Data.ConnectionState.Open)
                {
                    MiConexion.Close();
                }
            }
        }
    }
}
