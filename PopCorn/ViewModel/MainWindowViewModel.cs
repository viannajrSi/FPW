
using PopCorn.Model.DataBase;
using PopCorn.Model.DataBase.Model;
using PopCorn.Processamento;
using PopCorn.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PopCorn.ViewModel
{
    public class MainWindowViewModel : NotifyPropertyBase
    {
        public ICommand CloseCommand { get; set;}
        public ICommand NovoFilmeCommand { get; set;}
        public ICommand ExcluirFilmeCommand { get; set;}
        public ICommand BuscarFilmeCommand { get; set; }
        public ICommand PreecherGridCommand { get; set; }
        private ObservableCollection<Filme> filmes;
        private Filme filmeSelecionado;
        private int campoBuscaFilme;


        public MainWindowViewModel()
        {
            var filmes = DBFactory.Instance.FilmeRepository.BuscarTodos();
            this.Filmes = new ObservableCollection<Filme>(filmes);
            this.CloseCommand =  new Command(this.Shutdown);
            this.ExcluirFilmeCommand = new Command(this.ExcluirFilme);
            this.NovoFilmeCommand = new Command(this.InserirFilme);
            this.BuscarFilmeCommand = new Command(BuscarFilme);
            this.PreecherGridCommand = new Command(PreencherLista);
        }

        private void BuscarFilme(object o)
        {
            if (this.Filmes.Count() == 1 || this.Filmes.Count() == 0)
            {
                var filmes = DBFactory.Instance.FilmeRepository.BuscarTodos();
                this.Filmes = new ObservableCollection<Filme>(filmes);
            }
            if (campoBuscaFilme > 0)
            {
                var filme = Filmes.Where(F => F.Id == campoBuscaFilme).ToList();
                if(filme.Count() == 0)
                {
                    this.Filmes = new ObservableCollection<Filme>(filme);
                }
                if(filme.Count() > 0)
                {
                    this.Filmes = new ObservableCollection<Filme>(filme);
                }
                
            }
        }

        private void PreencherLista(object o)
        {
            var filmes = DBFactory.Instance.FilmeRepository.BuscarTodos();
            this.Filmes = new ObservableCollection<Filme>(filmes);
        }

        public void Shutdown(object o)
        {
            System.Environment.Exit(0);
        }

        public void InserirFilme(object o)
        {
            var view = new IncAltFilmeView();
            var viewModel = new IncAltFilmeViewModel();

            view.DataContext = viewModel;
            viewModel.View = view;
            var filme = viewModel.Execute();

            if(filme != null)
            {
                DBFactory.Instance.FilmeRepository.inserir(filme);
                var filmes = DBFactory.Instance.FilmeRepository.BuscarTodos();
                this.Filmes = new ObservableCollection<Filme>(filmes);
            }
        }

        private void ExcluirFilme(object o)
        {
            if (this.filmeSelecionado != null)
            {
                if (MessageBox.Show("Deseja Excluir " + this.filmeSelecionado.Nome + " ?", "Excluir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        DBFactory.Instance.FilmeRepository.Excluir("filme", this.filmeSelecionado.Id);
                        var pessoas = DBFactory.Instance.FilmeRepository.BuscarTodos();
                        this.Filmes = new ObservableCollection<Filme>(pessoas);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Não foi possivel excluir o filme", ex);
                    }
                }
            }
        }

        public ObservableCollection<Filme> Filmes
        {
            get
            {
                return filmes;
            }

            set
            {
                filmes = value;
                OnPropertyChanged("Filmes");
            }
        }

        public Filme FilmeSelecionado
        {
            get
            {
                return filmeSelecionado;
            }

            set
            {
                filmeSelecionado = value;
                OnPropertyChanged("FilmeSelecionada");
            }
        }

        public int CampoBuscaFilme
        {
            get
            {
                return campoBuscaFilme;
            }

            set
            {
                campoBuscaFilme = value;
                OnPropertyChanged("CampoBuscaFilme");
            }
        }
    }
}
