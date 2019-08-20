using JuntoWebApi.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace JuntoWebApi.Login
{
    public class LoginAutentica
    {

        public SqlConnection pegaConnBd()
        {
            //string connString = "Server=tcp:dbbaringer.database.windows.net,1433;Initial Catalog=dbDanielBaringer;Persist Security Info=False;User ID=dbaringer;Password=!dbadb1979@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var conexaoString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var conexao = new SqlConnection(conexaoString);
            return conexao;
        }

        public Task<Usuario> loginUsuario(string usr, string pwd) {

            Usuario _usr = new Usuario();

            try {

                using (SqlConnection conn = pegaConnBd())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select TOP 1 * from tbl001sistemausuarios where tbl001Login = @usr AND tbl001Senha = @pwd;", conn);

                    cmd.Parameters.Add(new SqlParameter("@usr", System.Data.SqlDbType.NVarChar,50)).Value = usr;
                    cmd.Parameters.Add(new SqlParameter("@pwd", System.Data.SqlDbType.NVarChar, 50)).Value = pwd;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            _usr.Id = (int)reader["tbl001Id"];
                            _usr.Nome = (string)reader["tbl001NomeUsuario"];
                            _usr.Login = (string)reader["tbl001Login"];
                            _usr.Senha = (string)reader["tbl001Senha"];

                        }
                    }
                }

            }
            catch (Exception xp) {
                _usr = new Usuario();
            }

            return Task.FromResult(_usr);

        }

    }
}