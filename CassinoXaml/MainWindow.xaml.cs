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
        
        int i = 0, j = 0, k = 0;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Tick += (s, e) => Teste();
        }

        private void Teste()
        {
            if (i < 20)
            {
                i++;
                txbNum1.Text = $"{new Random(System.Environment.TickCount).Next(0, 7)}";
            }
            if (j < 50)
            {
                j++;
                txbNum2.Text= $"{new Random(System.Environment.TickCount).Next(0, 7)}";
            }
            if (k < 100)
            {
                k++;
                txbNum3.Text = $"{new Random(System.Environment.TickCount).Next(0, 7)}";
            }
            if (k == 100) timer.Stop();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Apostar(null, null);
        }

        private void Apostar(object sender, RoutedEventArgs e)
        {
            i = 0;j = 0;k = 0;
            timer.Start();
        }

        private void RodarRoleta()
        {

        }
    }
}
