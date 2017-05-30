﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Model.DataBase.Model
{
    public class Serie : Midia
    {
        public int quantidadeEpisodio { get; set; }

        public string calculoTempodeSerie()
        {
            double minutes = quantidadeEpisodio * 45;
            TimeSpan span = TimeSpan.FromMinutes(minutes);
            string label = span.ToString(@"hh\:mm\:ss");
            return label;
        }
    }
}
