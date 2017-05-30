using PopCorn.Model.DataBase.Model;
using PopCorn.Processamento;
using PopCorn.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PopCorn.ViewModel
{
    public class IncAltFilmeViewModel : NotifyPropertyBase
    {
        public IncAltFilmeView View { get; set; }
        public ICommand StoreCommand { get; set;}
        public ICommand CancelCommand { get; set;}
        private Filme filme;

        public IncAltFilmeViewModel()
        {
            this.StoreCommand = new Command(this.Store);
            this.CancelCommand = new Command(this.Cancel);
        }

        public Filme Execute()
        {
            this.filme = new Filme();
            this.View.ShowDialog();
            return this.filme;
        }

        public void Store(object o)
        {
            //faltam alguns atributos
            this.filme.Id = this.Id;
            this.filme.Nome = this.Nome;
            this.filme.Descricao = this.Descricao;
            this.filme.Genero = this.Genero;
            this.filme.Duracao = this.Duracao;
            this.filme.Assistido = this.Assistido;
            this.View.Close();
        }

        public void Cancel(object o) {
            this.filme = null;
            this.View.Close();
        }



        //Variaveis binding e GET E SET

        private int id;
        private string nome;
        private string descricao;
        private string genero;
        private bool assistido;
        private int duracao;
        private Categoria.categoria categoria;

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

        public Categoria.categoria Categoria
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

        public bool Assistido
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

        public int Duracao
        {
            get
            {
                return duracao;
            }

            set
            {
                if (duracao == value)
                    return;
                this.duracao = value;
                OnPropertyChanged("Duracao");
            }
        }

    }
}
