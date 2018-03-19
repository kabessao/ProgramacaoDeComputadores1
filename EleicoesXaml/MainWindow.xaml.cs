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

        public MainWindow()
        {
            InitializeComponent();
            btnVotarJc.Click += (s, e) => VotosJc++;
            btnVotarPicaPau.Click += (s, e) => VotosPicaPau++;
            btnVotarLinus.Click += (s, e) => VotosLinus++;
            btnVotarPiv.Click += (s, e) => VotosPivete++;
        }

        private void Resetar(object sender, RoutedEventArgs e)
        {
            VotosJc = 0;
            VotosLinus = 0;
            VotosPivete = 0;
            VotosPivete = 0;
        }

        private void Apurar(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
