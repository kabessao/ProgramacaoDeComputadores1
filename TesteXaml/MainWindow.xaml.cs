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
using System.Windows.Threading;

namespace TesteXaml
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        private int vezes;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += Timer_Tick;
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            txbPrimeiro.Text = $"{new Random(Environment.TickCount * -1).Next(1,100)}";
            await Task.Delay(1000);
            txbSegundo.Text = $"{new Random(Environment.TickCount * -1).Next(1,100)}";
            txbUpTime.Text = $"{Environment.TickCount}";
            if (txbSegundo.Text == txbPrimeiro.Text && vezes > 3) txbPrimeiro.Foreground = new SolidColorBrush(Colors.Red);
            vezes++;
            if (vezes > 100)
            {
                vezes = 0;
                txbPrimeiro.Foreground = new SolidColorBrush(Colors.Black);
            }

        }

        private void Start(object sender, RoutedEventArgs e)
        {
            Button button = (sender as Button);
            bool isOn = button.Content.ToString() == "Parar";

            if (isOn)
            {
                button.Content = new TextBlock().Text = "Começar";
                timer.Stop();
            }
            else
            {
                button.Content = new TextBlock().Text = "Parar";
                timer.Start();
            }
        }
    }
}
