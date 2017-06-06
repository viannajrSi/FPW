
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
        public ICommand NovoSerieCommand { get; set; }
        public ICommand ExcluirFilmeCommand { get; set;}
        public ICommand ExcluirSerieCommand { get; set; }
        public ICommand BuscarFilmeCommand { get; set; }
        public ICommand BuscarSerieCommand { get; set; }
        public ICommand PreecherGridFilmeCommand { get; set; }
        public ICommand PreecherGridSerieCommand { get; set; }
        public ICommand BuscarSeriesNaoAssistadasCommand { get; set;}
        public ICommand CalcularTempoSerieCommand { get; set;}
        public ICommand NovoCadastoPrecoCommand { get; set;}
        private ObservableCollection<Filme> filmes;
        private ObservableCollection<Serie> series;

        private categoria categoria;
        private Filme filmeSelecionado;
        private Serie serieSelecionado;
        private int campoBuscaFilme;
        private int campoBuscaSerie;
        private string tempoSerie;

        public MainWindowViewModel()
        {
            var filmes = DBFactory.Instance.FilmeRepository.BuscarTodos();
            var series = DBFactory.Instance.SerieRepository.BuscarTodos();
            this.Filmes = new ObservableCollection<Filme>(filmes);
            this.Series = new ObservableCollection<Serie>(series);

            this.CloseCommand =  new Command(this.Shutdown);

            this.ExcluirFilmeCommand = new Command(this.ExcluirFilme);
            this.ExcluirSerieCommand = new Command(this.ExcluirSerie);

            this.NovoFilmeCommand = new Command(this.InserirFilme);
            this.NovoSerieCommand = new Command(this.InserirSerie);

            this.BuscarFilmeCommand = new Command(BuscarFilme);
            this.BuscarSerieCommand = new Command(BuscarSerie);
            this.BuscarSeriesNaoAssistadasCommand = new Command(BuscarSeriesNaoAssistidas);

            this.CalcularTempoSerieCommand = new Command(CalcularTempoSerie);
            this.PreecherGridFilmeCommand = new Command(PreencherLista);
            this.PreecherGridSerieCommand = new Command(PreencherListaSerie);

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

        private void BuscarSerie(object o)
        {
            if (this.Series.Count() == 1 || this.Series.Count() == 0)
            {
                var series = DBFactory.Instance.SerieRepository.BuscarTodos();
                this.Series = new ObservableCollection<Serie>(series);
            }
            if (campoBuscaSerie > 0)
            {
                var serie = Series.Where(F => F.Id == campoBuscaSerie).ToList();
                if (serie.Count() == 0)
                {
                    this.Series = new ObservableCollection<Serie>(serie);
                }
                if (serie.Count() > 0)
                {
                    this.Series = new ObservableCollection<Serie>(serie);
                }

            }
        }

        private void PreencherLista(object o)
        {
            var filmes = DBFactory.Instance.FilmeRepository.BuscarTodos();
            this.Filmes = new ObservableCollection<Filme>(filmes);
        }

        private void PreencherListaSerie(object o)
        {
            var series = DBFactory.Instance.SerieRepository.BuscarTodos();
            this.Series = new ObservableCollection<Serie>(series);
        }

        public void Shutdown(object o)
        {
            System.Environment.Exit(0);
        }


        public void InserirPreco(object o)
        {
            var view = new AddPrecoView();
            var viewModel = new PrecoViewModel();

            view.DataContext = viewModel;
            viewModel.View = view;
            var filme = viewModel.Execute();
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
        public void InserirSerie(object o)
        {
            var view = new IncAltSerieView();
            var viewModel = new IncAltSerieViewModel();

            view.DataContext = viewModel;
            viewModel.View = view;
            var serie = viewModel.Execute();

            if (serie != null)
            {
                DBFactory.Instance.SerieRepository.inserir(serie);
                var series = DBFactory.Instance.SerieRepository.BuscarTodos();
                this.Series = new ObservableCollection<Serie>(series);
            }
        }

        public void CalcularTempoSerie(object o)
        {
            this.TempoSerie = this.serieSelecionado.calculoTempodeSerie();
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
        private void ExcluirSerie(object o)
        {
            if (this.serieSelecionado != null)
            {
                if (MessageBox.Show("Deseja Excluir " + this.serieSelecionado.Nome + " ?", "Excluir", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        DBFactory.Instance.SerieRepository.Excluir("serie", this.serieSelecionado.Id);
                        var series = DBFactory.Instance.SerieRepository.BuscarTodos();
                        this.Series = new ObservableCollection<Serie>(series);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Não foi possivel excluir a série", ex);
                    }
                }
            }
        }



        public void BuscarSeriesNaoAssistidas(object o) {
            var series = Series.Where(S => S.Assistido.Equals("Não")).ToList();
            this.Series = new ObservableCollection<Serie>(series);
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

        public ObservableCollection<Serie> Series
        {
            get
            {
                return series;
            }

            set
            {
                series = value;
                OnPropertyChanged("Series");
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
        public Serie SerieSelecionado
        {
            get
            {
                return serieSelecionado;
            }

            set
            {
                serieSelecionado = value;
                OnPropertyChanged("SerieSelecionado");
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

        public categoria Categoria
        {
            get
            {
                return Categoria;
            }

            set
            {
                Categoria = value;
                OnPropertyChanged("Categoria");
            }
        }

        public int CampoBuscaSerie
        {
            get
            {
                return campoBuscaSerie;
            }

            set
            {
                campoBuscaSerie = value;
                OnPropertyChanged("CampoBuscaSerie");
            }
        }

        public string TempoSerie
        {
            get
            {
                return tempoSerie;
            }

            set
            {
                tempoSerie = value;
                OnPropertyChanged("TempoSerie");
            }
        }
    }
}
