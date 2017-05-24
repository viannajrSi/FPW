using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PopCorn.Model.DataBase.Model;

namespace PopCorn.Model.DataBase.Repository
{
    public class FilmeRepository : RepositoryBase
    {
        public FilmeRepository(MySqlConnection conexao) : base(conexao)
        {

        }

        public void inserir(Filme filme) {
            try
            {
                if (this.MySqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    this.MySqlConnection.Open();
                }
                var sql = "INSERT INTO filme (nome,descricao,genero,categoria,duracao) VALUES (@nome,@descricao,@genero,@categoria,@duracao);";
                var cmd = new MySqlCommand(sql, this.MySqlConnection);
                cmd.Parameters.AddWithValue("@nome", filme.Nome);
                cmd.Parameters.AddWithValue("@descricao", filme.Descricao);
                cmd.Parameters.AddWithValue("@genero", filme.Genero);
                //falta categoria
                cmd.Parameters.AddWithValue("@duracao", filme.Duracao);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception("Não foi possivel inserir", ex);
            }
            finally
            {
                //teste
                this.MySqlConnection.Close();
            }
        }
    }
}
