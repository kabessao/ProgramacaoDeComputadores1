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

        livrosTableAdapter banco = new livrosTableAdapter();

        private void Listar(object sender, RoutedEventArgs e)
        {
            foreach (var item in banco.GetData().ToList())
            {
                lstLista.Items.Add(new Livro { Id = item.id_livro, Autor = item.autor, Nome = item.nome });
            }
        }

        private void Gravar(object sender, RoutedEventArgs e)
        {
            banco.Insert(txtAutor.Text, txtNomeLivro.Text);
        }

        private void lstLista_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Livro livro = ((sender as ListView).SelectedItem as Livro);
            txtAutor.Text = livro.Autor;
            txtNomeLivro.Text = livro.Nome;
        }
    }
}
