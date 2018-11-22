using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace DataAccess
{
    public class PacienteDAL:Conexion
    {
        public async Task<List<Paciente>> GetPacientesAsync()
        {
            MySqlConnection MiConexion = AbrirConexionSql();
            string sql = "select * from pacientes";
            try
            {
                List<Paciente> ListaPacientes = null;
                if(MiConexion != null)
                {
                    ListaPacientes = (await MiConexion.QueryAsync<Paciente>(sql)).ToList();
                }
                return ListaPacientes;
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

        public async Task<int> InsertarPacienteAsync(Paciente paciente)
        {
            MySqlConnection conexion = AbrirConexionSql();
            string sql = "INSERT into pacientes (Dni, Nombre, Apellido, fNacimiento, Tipo) values (@Dni, @Nombre, @Apellido, @fNacimiento, @Tipo)";
            int FilasAfectadas = 0;
            try
            {
                if (conexion != null)
                {
                    FilasAfectadas = await conexion.ExecuteAsync(sql, new { Dni = paciente.Dni, Nombre = paciente.Nombre, Apellido = paciente.Apellido, fNacimiento = paciente.fNacimiento, Tipo = paciente.Tipo});
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
