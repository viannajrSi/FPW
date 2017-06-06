using PopCorn.Model.DataBase.Model;
using PopCorn.Processamento;
using PopCorn.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static PopCorn.Model.DataBase.Model.categoria;

namespace PopCorn.ViewModel
{
    public class IncAltSerieViewModel : NotifyPropertyBase
    {
        public IncAltSerieView View { get; set; }
        public ICommand StoreCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        private ObservableCollection<String> LstAssistidos;
        private Serie serie;

        public IncAltSerieViewModel() {
            this.StoreCommand = new Command(this.Store);
            this.CancelCommand = new Command(this.Cancel);
            this.LstAssistidos1 = new ObservableCollection<string>();
            LstAssistidos1.Add("Sim");
            LstAssistidos1.Add("Não");
        }

        public Serie Execute()
        {
            this.serie = new Serie();
            this.View.ShowDialog();
            return this.serie;

        }

        public void Cancel(object o)
        {
            this.serie = null;
            this.View.Close();
        }

        public void Store(object o)
        {
            //faltam alguns atributos
            this.serie.Id = this.Id;
            this.serie.Nome = this.Nome;
            this.serie.Descricao = this.Descricao;
            this.serie.Genero = this.Genero;
            this.serie.Assistido = this.Assistido;
            this.serie.QuantidadeEpisodio = this.QuantidadeEpisodio;
            this.serie.DuracaoEpisodio = this.DuracaoEpisodio;
            this.serie.Categoria = this.Categoria;     
            this.View.Close();
        }


        private int id;
        private string nome;
        private string descricao;
        private string genero;
        private string assistido;
        private int quantidadeEpisodio;
        private int duracaoEpisodio;
        private categoria categoria;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                if (id == value)
                    return;
                this.id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                if (nome == value)
                    return;
                this.nome = value;
                OnPropertyChanged("Nome");
            }
        }

        public string Descricao
        {
            get
            {
                return descricao;
            }

            set
            {
                if (descricao == value)
                    return;
                this.descricao = value;
                OnPropertyChanged("Descricao");
            }
        }

        public string Genero
        {
            get
            {
                return genero;
            }

            set
            {
                if (genero == value)
                    return;
                this.genero = value;
                OnPropertyChanged("Genero");
            }
        }

        public string Assistido
        {
            get
            {
                return assistido;
            }

            set
            {
                if (assistido == value)
                    return;
                this.assistido = value;
                OnPropertyChanged("Assistido");
            }
        }

        public ObservableCollection<string> LstAssistidos1
        {
            get
            {
                return LstAssistidos;
            }

            set
            {
                LstAssistidos = value;
            }
        }

       

        public int DuracaoEpisodio
        {
            get
            {
                return duracaoEpisodio;
            }

            set
            {
                duracaoEpisodio = value;
                OnPropertyChanged("DuracaoEpisodio");
            }
        }

        public int QuantidadeEpisodio
        {
            get
            {
                return quantidadeEpisodio;
            }

            set
            {
                quantidadeEpisodio = value;
                OnPropertyChanged("QuantidadeEpisodio");
            }
        }

        public categoria Categoria
        {
            get
            {
                return categoria;
            }

            set
            {
                if (categoria == value)
                    return;
                this.categoria = value;
                OnPropertyChanged("Categoria");
            }
        }
    }
}
