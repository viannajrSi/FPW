using MySql.Data.MySqlClient;
using PopCorn.Model.DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Model.DataBase
{
    public class DBFactory
    {
        private static DBFactory _instance;
        private MySqlConnection _connection;

        public FilmeRepository FilmeRepository { get; set; }
        public SerieRepository SerieRepository { get; set; }

        private DBFactory()
        {
            Conectar();
            this.FilmeRepository = new FilmeRepository(this._connection);
            this.SerieRepository = new SerieRepository(this._connection);
        }

        private void Conectar()
        {
            try
            {
                var stringConexao = "Persist Security Info=False;server=localhost;database=popcorn;uid=root;pwd=";
                this._connection = new MySqlConnection(stringConexao);
                this._connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro! Não foi possível conectar ao banco de dados.", ex);
            }
            finally
            {
                if (this._connection.State != ConnectionState.Closed)
                {
                    this._connection.Close();
                }
            }
        }
        public static DBFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DBFactory();
                }
                return _instance;
            }
        }
    }
}
