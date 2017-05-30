using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PopCorn.Model.DataBase.Model;

namespace PopCorn.Model.DataBase.Repository
{
    public class SerieRepository : RepositoryBase
    {
        public SerieRepository(MySqlConnection conexao) : base(conexao)
        {
        }
        public void inserir(Serie serie)
        {
            try
            {
                if (this.MySqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    this.MySqlConnection.Open();
                }
                var sql = "INSERT INTO filme (nome,descricao,genero,categoria,qtdEpisodios,assistido) VALUES (@nome,@descricao,@genero,@categoria,@qtdEpisodios,@assistido);";
                var cmd = new MySqlCommand(sql, this.MySqlConnection);
                cmd.Parameters.AddWithValue("@nome", serie.Nome);
                cmd.Parameters.AddWithValue("@descricao", serie.Descricao);
                cmd.Parameters.AddWithValue("@genero", serie.Genero);               
                cmd.Parameters.AddWithValue("@qtdEpisodios", serie.quantidadeEpisodio);
                cmd.Parameters.AddWithValue("@assistido", serie.Assistido);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
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
