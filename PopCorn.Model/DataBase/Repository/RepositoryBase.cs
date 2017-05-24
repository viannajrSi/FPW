using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Model.DataBase.Repository
{
    public class RepositoryBase
    {
        protected MySqlConnection MySqlConnection;

        public RepositoryBase(MySqlConnection conexao)
        {
            this.MySqlConnection = conexao;
        }

        public void Excluir(string tabela, int id)
        {
            try
            {
                if (this.MySqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    this.MySqlConnection.Open();
                }
                var sql = "DELETE FROM " + tabela + " WHERE id = @id";
                var cmd = new MySqlCommand(sql, this.MySqlConnection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel excluir", ex);
            }
            finally
            {
                this.MySqlConnection.Close();
            }
        }
    }
}
