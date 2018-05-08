using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CassinoXaml
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool Terminou { get; private set; }

        DispatcherTimer timer = new DispatcherTimer();
        
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 15);
            timer.Tick += (s, e) => Teste();
        }

        private async void Teste()
        {
            int count = 0;
            txbNum1.Text = $"{new Random(System.Environment.TickCount * -1).Next(0, 7)}";
            await Task.Delay(1000);
            txbNum2.Text= $"{new Random(System.Environment.TickCount * -1).Next(0, 7)}";
            await Task.Delay(1000);
            txbNum3.Text = $"{new Random(System.Environment.TickCount * -1).Next(0, 7)}";
            await Task.Delay(1000);
            txbNum4.Text = $"{new Random(System.Environment.TickCount * -1).Next(0, 7)}";
            if (count < 100) timer.Stop(); 
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) => Apostar(null, null);

        private void Apostar(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void RodarRoleta()
        {

        }
    }
}
