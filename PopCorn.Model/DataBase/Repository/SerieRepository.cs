using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PopCorn.Model.DataBase.Model;
using System.Data;

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
                var sql = "INSERT INTO serie (nome,descricao,genero,categoria,qtdEpisodios,assistido,duracaoEpisodio) VALUES (@nome,@descricao,@genero,@categoria,@quantidadeEpisodios,@assistido,@duracaoEpisodio);";
                var cmd = new MySqlCommand(sql, this.MySqlConnection);
                cmd.Parameters.AddWithValue("@nome", serie.Nome);
                cmd.Parameters.AddWithValue("@descricao", serie.Descricao);
                cmd.Parameters.AddWithValue("@genero", serie.Genero);
                cmd.Parameters.AddWithValue("@categoria", serie.Categoria);               
                cmd.Parameters.AddWithValue("@quantidadeEpisodios", serie.QuantidadeEpisodio);
                cmd.Parameters.AddWithValue("@assistido", serie.Assistido);
                cmd.Parameters.AddWithValue("@duracaoEpisodio", serie.DuracaoEpisodio);
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

        public List<Serie> BuscarTodos()
        {
            try
            {
                if (this.MySqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    this.MySqlConnection.Open();
                }
                var sql = "SELECT * FROM serie";
                var query = new MySqlDataAdapter(sql, this.MySqlConnection);
                var dataSet = new DataSet();
                query.Fill(dataSet);
                var tabela = dataSet.Tables[0].AsEnumerable().ToList();
                var series = new List<Serie>();
                foreach (var linha in tabela)
                {
                    var serie = new Serie()
                    {
                        Id = Convert.ToInt32(linha["id"]),
                        Nome = linha["nome"].ToString(),
                        Descricao = linha["descricao"].ToString(),
                        Genero = linha["genero"].ToString(),
                        Assistido = linha["assistido"].ToString(),
                        QuantidadeEpisodio = Convert.ToInt32(linha["qtdEpisodios"]),
                        DuracaoEpisodio = Convert.ToInt32(linha["duracaoEpisodio"])
                    };
                    series.Add(serie);
                }
                return series;

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel listar", ex);
            }
            finally
            {
                this.MySqlConnection.Close();
            }
        }
    }
}
