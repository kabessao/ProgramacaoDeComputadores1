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
using DataAccess;

namespace ZooXaml
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private Animal _animal = new Animal();

        public MainWindow()
        {
            InitializeComponent();

            GerarLista();

            btnPesquisar.Click += (s, e) => GerarLista();

            txtPesquisa.KeyUp += (s, e) => GerarLista();

            btnSalvar.Click += (s, e) => Salvar();

            btnCancelar.Click += (s, e) => Cancelar();

            btnDeletar.Click += (s, e) => Deletar();

            Lista.MouseDoubleClick += (s, e) => SelectLista();

            DataContext = _animal;            

        }

        public void SelectLista()
        {
            if (Lista.SelectedIndex > -1)
            {
                Animal a = (Lista.SelectedItem as Animal);
                _animal.Nome = a.Nome;
                _animal.Id = a.Id;
                _animal.Descricao = a.Descricao;
                btnSalvar.Content = new TextBlock().Text = "Atualizar";
            }
            else
            {
                MessageBox.Show("Nenhum item selecionado");
            }
            
        }

        public void Cancelar()
        {
            _animal.Nome = "";
            _animal.Descricao = "";
            _animal.Id = 0;
            btnSalvar.Content = new TextBlock().Text = "Salvar";
        }
        
        public void GerarLista()
        {
            List<Animal> list = new List<Animal>();
            try
            {
                list = new AnimalDao().Select(txtPesquisa.Text);
            }
            finally { }

            Lista.ItemsSource = list;

        }

        private void Salvar()
        {

            if (btnSalvar.Content.ToString() == "Salvar")
            {
                if (!string.IsNullOrEmpty(_animal.Nome) || !string.IsNullOrEmpty(_animal.Descricao))
                {
                    new AnimalDao().Insert(_animal);
                    Cancelar();
                    GerarLista();
                    MessageBox.Show("Salvo com sucesso", "Sucesso");

                }
                else
                {
                    MessageBox.Show("Campos em branco");
                }
            }
            else if (btnSalvar.Content.ToString() == "Atualizar")
            {
                new AnimalDao().Update(_animal);
                MessageBox.Show("Atualizado com sucesso", "Sucesso");
                Cancelar();
                GerarLista();
            }
        }

        public void Deletar()
        {
            Animal animal;
            if (Lista.SelectedIndex > -1)
            {
                animal = (Lista.SelectedItem as Animal);
                if (MessageBox.Show($"Tem certeza que deseja deletar {animal.Nome}?", "Confirmação", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    new AnimalDao().Delete(animal.Id);
                GerarLista();
            }
            else
            {
                MessageBox.Show("nenhum item selecionado");
            }
        }
    }
}
