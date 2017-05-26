using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Model.DataBase.Model
{
    public abstract class Midia
    {
        public int Id { get; set;}
        public string Nome { get; set;}
        public string Descricao { get; set;}
        public string Genero { get; set;}
        public Categoria Categoria { get; set;}
        public bool Assistido { get; set; }
    }
}
