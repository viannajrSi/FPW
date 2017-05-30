using PopCorn.Model.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PopCorn.View
{
    /// <summary>
    /// Interaction logic for IncAltFilmeView.xaml
    /// </summary>
    public partial class IncAltFilmeView : Window
    {
        public IncAltFilmeView()
        {
            InitializeComponent();
        }

        private void load_Loaded(object sender, RoutedEventArgs e)
        {
            List<Categoria.categoria> data = new List<Categoria.categoria>();

            var array = Enum.GetValues(typeof(Categoria.categoria));

            for (int i = 1; i <= array.Length; i++)
            {
                data.Add((Categoria.categoria)i);
            }

            var combo = sender as ComboBox;
            combo.ItemsSource = data;
            combo.SelectedIndex = 0;
        }
    }
}
