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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TabuadaXaml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtNumero.Focus();
        }

        private void Calcular(object sender, RoutedEventArgs e)
        {
            Painel.Children.Clear();
            if (txtNumero.Text == "") return;
            if (double.TryParse(txtNumero.Text, out double Numero))
                for (int i = 1; i != 11; i++)
                {
                    Painel.Children.Add(new TextBlock { Text = $"{Numero} Vezes {i} é igual a {Numero * i}" });
                }
            else
                Painel.Children.Add(new TextBlock { Text = "Digita um numero sua mula quadrada!" });
        }

        private void KeyDownWindow(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Calcular(null, null);                
            }
        }
    }
}
