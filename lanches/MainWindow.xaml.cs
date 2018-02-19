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

namespace lanches
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        Random Random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        string resultado { get
            {
                return txtTotal.Text;
            }
        set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    double.TryParse(value, out double numero);
                    double.TryParse(resultado, out double numAnterior);
                    txtTotal.Text = $"{numAnterior + resultado}";
                }
            }
        }

        private void Somar(object sender, RoutedEventArgs e)
        {
            TextBoxes.Children.OfType<TextBox>().ToList().ForEach(x => {
                resultado = x.Text;
            });




        }

        private void Aleatorio(object sender, RoutedEventArgs e)
        {

            TextBoxes.Children.OfType<TextBox>().ToList().ForEach(x =>
            {
                x.Text = $"{Random.Next(1, 99)}";
            });
        }
    }
}
