using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace DataAccess
{
    public class HistoriaClinicaDAL:Conexion
    {
       public async Task<List<HistoriaClinica>> GetHistoriaClinicaAsync()
        {
            MySqlConnection MiConexion = AbrirConexionSql();
            string sql = "select * from historiasclinicas";
            try
            {
                List<HistoriaClinica> ListaHistoriasClinicas = null;
                if(MiConexion != null)
                {
                    ListaHistoriasClinicas = (await MiConexion.QueryAsync<HistoriaClinica>(sql)).ToList();
                }
                return ListaHistoriasClinicas;
            }
            catch
            {
                return null;
            }
            finally
            {
                if(MiConexion.State == System.Data.ConnectionState.Open)
                {
                    MiConexion.Close();
                }
            }
        }

        public async Task<int> InsertarHistoriaClinicaAsync(HistoriaClinica historia)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "INSERT into historiasclinicas (CodEspecialidad, FechaApertura, Peso, Talla, Dni) values (@CodEspecialidad, @FechaApertura, @Peso, @Talla, @Dni)";
            int FilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    FilasAfectadas = await conexion.ExecuteAsync(sql, new { CodEspecialidad = historia.CodEspecialidad, FechaApertura = historia.FechaApertura, Peso = historia.Peso, Talla = historia.Talla, Dni = historia.Dni});
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
