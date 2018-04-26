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
using CadastroLivrosXaml.dadosTableAdapters;

namespace CadastroLivrosXaml
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        livroTableAdapter banco = new livroTableAdapter();

        private void Listar(object sender, RoutedEventArgs e)
        {
            Painel.Children.Clear();
            List<StackPanel> list = new List<StackPanel>();
            foreach (var item in banco.GetData().ToList())
            {
                StackPanel stack = new StackPanel()
                {
                    Orientation = Orientation.Horizontal
                };
                stack.Children.Add(new TextBlock() { Text = $"Id: {item.cod_livro}" });
                stack.Children.Add(new TextBlock() { Text = " Autor: "+item.autor });
                stack.Children.Add(new TextBlock() { Text = " Nome: "+item.nome });
                Painel.Children.Add(stack);
            }
        }

        private void Gravar(object sender, RoutedEventArgs e) => banco.Insert(txtAutor.Text, txtNomeLivro.Text);

    }
}
