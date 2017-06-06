using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Model.DataBase.Model
{
    public enum categoria
    {
        lancamento = 1,
        normal = 2,
        erotico = 3,
        infantil = 4
    }

    public class CategoriaEnumUtils
    {
        public static categoria BuscarCategoriaPeloId(string id)
        {
            switch (id)
            {
                case "1":
                    return categoria.lancamento;
                    break;
                case "2":
                    return categoria.normal;
                    break;
                case "3":
                    return categoria.erotico;
                    break;
                case "4":
                    return categoria.infantil;
                    break;
            }
            return categoria.erotico;
        }
    }
}
