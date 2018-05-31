namespace ZooXaml.DAO
{
    class Animal
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public int Idade { get; set; }
        public string CaminhoFoto { get; set; }

        public Animal()
        {

        }

        public Animal(int id, string nome, string especie, int idade)
        {
            Id = id;
            Nome = nome;
            Especie = especie;
            Idade = idade;
        }
    }
}
