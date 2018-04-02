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

namespace EleicoesXaml
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        int VotosJc = 0;
        int VotosPicaPau = 0;
        int VotosPivete = 0;
        int VotosLinus = 0;
        int tempo = 0;

        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            btnVotarJc.Click += (s, e) => { VotosJc++; timer.Start(); };
            btnVotarPicaPau.Click += (s, e) =>{ VotosPicaPau++; timer.Start(); };
            btnVotarLinus.Click += (s, e) =>{ VotosLinus++; timer.Start(); };
            btnVotarPiv.Click += (s, e) =>{ VotosPivete++; timer.Start(); };

            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.Tick += Timer_Tick1;
        }

        private void Timer_Tick1(object sender, EventArgs e)
        {
            btnVotarPiv.IsEnabled = false;
            btnVotarPicaPau.IsEnabled = false;
            btnVotarLinus.IsEnabled = false;
            btnVotarJc.IsEnabled = false;
            tempo++;
            if (tempo == 100)
            {
                tempo = 0;
                timer.Stop();                

                btnVotarPiv.IsEnabled = true;
                btnVotarPicaPau.IsEnabled = true;
                btnVotarLinus.IsEnabled = true;
                btnVotarJc.IsEnabled = true;

            }
        }


        private void Resetar(object sender, RoutedEventArgs e)
        {
            VotosJc = 0;
            VotosLinus = 0;
            VotosPicaPau = 0;
            VotosPivete = 0;
        }

        private void Apurar(object sender, RoutedEventArgs e)
        {
            string vencedor = "";
            if ((VotosLinus > VotosPicaPau) || (VotosLinus > VotosJc) || (VotosLinus > VotosPivete) )
            {
                vencedor = "Linus Torvalds"; 
            } else if ((VotosPicaPau > VotosJc) || (VotosPicaPau > VotosPivete))
            {
                vencedor = "Pica Pau";
            } else if (VotosPivete > VotosJc)
            {
                vencedor = "Pivete";
            } else
            {
                vencedor = "JC";
            }
            MessageBox.Show("O vencedor desta eleição foi o " + vencedor);
            Resetar(null, null);
        }
    }
}
