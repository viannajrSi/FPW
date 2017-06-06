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
                var sql = "INSERT INTO filme (nome,descricao,genero,duracao,assistido,categoria) VALUES (@nome,@descricao,@genero,@duracao,@assistido,@categoria);";
                var cmd = new MySqlCommand(sql, this.MySqlConnection);
                cmd.Parameters.AddWithValue("@nome", filme.Nome);
                cmd.Parameters.AddWithValue("@descricao", filme.Descricao);
                cmd.Parameters.AddWithValue("@genero", filme.Genero);
                cmd.Parameters.AddWithValue("@categoria", filme.Categoria);
                cmd.Parameters.AddWithValue("@duracao", filme.Duracao);
                cmd.Parameters.AddWithValue("@assistido", filme.Assistido);
                cmd.ExecuteNonQuery();
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

        public List<Filme> BuscarTodos()
        {
            try
            {
                if (this.MySqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    this.MySqlConnection.Open();
                }
                var sql = "SELECT * FROM filme";
                var query = new MySqlDataAdapter(sql, this.MySqlConnection);
                var dataSet = new DataSet();
                query.Fill(dataSet);
                var tabela = dataSet.Tables[0].AsEnumerable().ToList();
                var filmes = new List<Filme>();
                foreach (var linha in tabela)
                {
                    var filme = new Filme()
                    {
                        Id = Convert.ToInt32(linha["id"]),
                        Nome = linha["nome"].ToString(),
                        Descricao = linha["descricao"].ToString(),
                        Genero = linha["genero"].ToString(),
                        Categoria = CategoriaEnumUtils.BuscarCategoriaPeloId(linha["categoria"].ToString()),
                        Duracao = Convert.ToInt32(linha["duracao"])
                    };
                    filmes.Add(filme);
                }
                return filmes;

            } catch (Exception ex) {
                throw new Exception("Não foi possivel inserir", ex);
            }
            finally {
                this.MySqlConnection.Close();
            }
        }


    }
}
