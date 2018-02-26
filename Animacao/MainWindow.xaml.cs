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

namespace Animacao
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {




        private string _ibagem;

        int num = 0;

        public string Ibagem {
            get
            {
                return _ibagem;
            }
            set
            {
                _ibagem = @"pack://application:,,,/Animacao;component/imagem/frame_" + value + @"_delay-0.03s.gif";
            }
        }
        


        public MainWindow()
        {
           
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 25);
            timer.Tick += (s, e) => Tick();
            timer.Start();
            
        }

        private void Tick()
        {
           
                if (num > 152) num = 0;
                Ibagem = $"{num:000}";
                imgImage.Source = new BitmapImage(new Uri(Ibagem));
                num++;
        }
    }
}
