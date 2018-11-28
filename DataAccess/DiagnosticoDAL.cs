using Entities;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace DataAccess
{
    public class DiagnosticoDAL:Conexion
    {
        public async Task<List<Diagnostico>> GetDiagnosticosAsync()
        {
            MySqlConnection MiConexion = AbrirConexionSql();
            string sql = "select * from diagnosticos";
            try
            {
                List<Diagnostico> ListaDiagnosticos = null;
                if (MiConexion != null)
                {
                    ListaDiagnosticos = (await MiConexion.QueryAsync<Diagnostico>(sql)).ToList();
                }
                return ListaDiagnosticos;
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
        public async Task<int> InsertarDiagnosticoAsync(Diagnostico diagnostico)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "INSERT into diagnosticos (IdDiagnostico, CodEnfermedad, CodMedicamento) values (@IdDiagnostico, @CodEnfermedad, @CodMedicamento)";
            int FilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    FilasAfectadas = await conexion.ExecuteAsync(sql, new { IdDiagnostico = diagnostico.IdDiagnostico, IdEnfermedad = diagnostico.CodEnfermedad, IdMedicamento = diagnostico.CodMedicamento });
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
        public async Task<int> UpdateDiagnosticoAsync(Diagnostico diagnostico)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "UPDATE diagnosticos SET  IdDiagnostico = @IdDiagnostico, CodMedicamento = @CodMedicamento, CodEnfermedad = @CodEnfermedad WHERE IdDiagnostico = @IdDiagnostico";
            //string sql = "UPDATE talumnos SET  Nombre = @Nombre, Apellido = @Apellido, Dni = @Dni, Email = @Email WHERE idAlumno = @idAlumno";
            int NroFilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    NroFilasAfectadas = await conexion.ExecuteAsync(sql, new
                    {
                        IdDiagnostico = diagnostico.IdDiagnostico,
                        CodMedicamento = diagnostico.CodMedicamento,
                        CodEnfermedad = diagnostico.CodEnfermedad
                    });
                };
                return NroFilasAfectadas;
            }
            catch (Exception ex)
            {
                return NroFilasAfectadas;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
        }
        public async Task<int> DeleteDiagnosticoAsync(string IdDiagnostico)
        {
            MySqlConnection MiConexion = AbrirConexionSql();
            string sql = "delete from diagnosticos WHERE IdDiagnostico = @IdDiagnostico;";
            int FilasAfectadas = 0;
            try
            {
                if (MiConexion != null)
                {
                    FilasAfectadas = await MiConexion.ExecuteAsync(sql, new { IdDiagnostico = IdDiagnostico });
                }
                return FilasAfectadas;

            }
            catch
            {
                return FilasAfectadas;
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
