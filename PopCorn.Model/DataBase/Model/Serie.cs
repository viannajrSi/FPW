using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Model.DataBase.Model
{
    public class Serie : Midia
    {
        public int QuantidadeEpisodio { get; set; }
        public int DuracaoEpisodio { get; set; }
            
        public string calculoTempodeSerie()
        {
            double minutes = this.QuantidadeEpisodio * this.DuracaoEpisodio;
            TimeSpan span = TimeSpan.FromMinutes(minutes);
            string label = span.ToString(@"hh\:mm\:ss");
            return label;
        }
    }
}
