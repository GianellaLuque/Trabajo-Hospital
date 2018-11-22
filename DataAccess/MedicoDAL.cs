using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace DataAccess
{
    public class MedicoDAL : Conexion
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

        public async Task<int> InsertarMedicoAsync(Medico medico)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "INSERT into medicos (CMP, Especialidad, Dni, Nombre, Apellido) values (@CMP, @Especialidad, @Dni, @Nombre, @Apellido)";
            int FilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    FilasAfectadas = await conexion.ExecuteAsync(sql, new { CMP = medico.CMP, Especialidad = medico.Especialidad, Dni = medico.Dni, Nombre = medico.Nombre, Apellido = medico.Apellido });
                }
                return FilasAfectadas;
            }
            catch
            {
                return FilasAfectadas;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open) { conexion.Close(); }
            }
        }

        public async Task<int> UpdateMedicoAsyn(Medico medico)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "UPDATE medicos SET (CMP, Especialidad, Dni, Nombre, Apellido) values (@CMP, @Especialidad, @Dni, @Nombre, @Apellido) WHERE CMP = @CMP";
            int FilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    FilasAfectadas = await conexion.ExecuteAsync(sql, new { CMP = medico.CMP, Especialidad = medico.Especialidad, Dni = medico.Dni, Nombre = medico.Nombre, Apellido = medico.Apellido });
                }
                return FilasAfectadas;
            }
            catch
            {
                return FilasAfectadas;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open) { conexion.Close(); }
            }
        }
    }
}
