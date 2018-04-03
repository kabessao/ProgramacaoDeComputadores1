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

namespace QuizXaml
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {

        Button btnIniciar = new Button();
        List<Pergunta> Perguntas = Pergunta.GerarPerguntas();
        short Numero = 0;
        public short Acertos
        {
            get
            {
                return short.Parse(txbAcertos.Text);
            }
            set
            {
                txbAcertos.Text = $"{value}";
            }
        }
        public short Erros
        {
            get
            {
                return short.Parse(txbErros.Text);
            }
            set
            {
                txbErros.Text = $"{value}";
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            btnIniciar.Click += Inicio;
            btnIniciar.Content = new TextBlock().Text = "Iniciar";
            Painel.Children.Add(btnIniciar);
        }

        private void Inicio(object sender, RoutedEventArgs e)
        {
            Acertos = 0;
            Erros = 0;
            btnVerdadeiro.IsEnabled = true;
            btnFalso.IsEnabled = true;
            Painel.Children.Remove(btnIniciar);
            Numero = 0;
            ProximaPergunta();
        }

        private void ProximaPergunta()
        {
            if (Numero != Perguntas.Count)
            {
                txbPergunta.Text = Perguntas[Numero].Texto;
            } else
            {
                MessageBox.Show("O jogo Acabou");
                MostrarResultado();
                txbPergunta.Text = "[Perguntas]";
                btnFalso.IsEnabled = false;
                btnVerdadeiro.IsEnabled = false;
                Painel.Children.Add(btnIniciar); 
            }
        }

        private void MostrarResultado()
        {
            string mensagem = "";
            string ace = "nada, que bosta em!";
            if (Acertos != 0)
                ace = $"{Acertos} perguntas";
            if (Acertos == Perguntas.Count)
                ace = "todas as perguntas, mizeravi!";
            if (Acertos > (Perguntas.Count / 2))
                mensagem = "Parabens";
            else
                mensagem = "Que decepção";
            MessageBox.Show(mensagem + ", você acertou " + ace,"Resultado");
        }

        private void Resposta(object sender, RoutedEventArgs e)
        {
            bool resposta = ((sender as Button).Content.ToString() == "Verdadeiro");
            if (Numero != Perguntas.Count)
            if (resposta == Perguntas[Numero].Resposta)
            {
                Acertos++; 
            }            
            else
            {
                Erros++;
            }
            Numero++;
            ProximaPergunta();
        }
    }
}
