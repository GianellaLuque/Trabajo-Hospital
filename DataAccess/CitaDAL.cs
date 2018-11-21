using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace DataAccess
{
    public class CitaDAL:Conexion
    {
        // CITAS
        public async Task<List<Cita>> GetCitasAsync()
        {
            MySqlConnection MiConexion = AbrirConexionSql();
            string sql = "select * from citas";
            try
            {
                List<Cita> ListaCitas = null;
                if (MiConexion != null)
                {
                    ListaCitas = (await MiConexion.QueryAsync<Cita>(sql)).ToList();
                }
                return ListaCitas;
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

        public async Task<int> GenerarCitaAsync(Cita cita)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "INSERT into citas (Dni, Nombre, Apellido, CodEspecialidad, CodDoctor, TipoCita, EstadoCita) values (@Dni, @Nombre, @Apellido, @CodEspecialidad, @CodDoctor, @TipoCita, @EstadoCita)";
            int FilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {

                    //FilasAfectadas = await conexion.ExecuteAsync(sql, new { Dni = cita.Dni, Nombre = cita.Nombre, Apellido = cita.Apellido, CodEspecialidad = (int)cita.CodEspecialidad, CodDoctor = cita.CodDoctor, TipoCita = (int)cita.TipoCita, EstadoCita = (int)cita.EstadoCita });
                    //FilasAfectadas = await conexion.ExecuteAsync(sql, new { Dni = cita.Dni, Nombre = cita.Nombre, Apellido = cita.Apellido, CodEspecialidad = nameof(cita.CodEspecialidad), CodDoctor = cita.CodDoctor, TipoCita = nameof(cita.TipoCita), EstadoCita = nameof(cita.EstadoCita) });
                    FilasAfectadas = await conexion.ExecuteAsync(sql, new { Dni = cita.Dni, Nombre = cita.Nombre, Apellido = cita.Apellido, CodEspecialidad = cita.CodEspecialidad, CodDoctor = cita.CodDoctor, TipoCita = cita.TipoCita, EstadoCita = cita.EstadoCita });
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
