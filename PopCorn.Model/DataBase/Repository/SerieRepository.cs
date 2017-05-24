using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PopCorn.Model.DataBase.Repository
{
    public class SerieRepository : RepositoryBase
    {
        public SerieRepository(MySqlConnection conexao) : base(conexao)
        {
        }
    }
}
