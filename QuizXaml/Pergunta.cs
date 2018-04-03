using System.Collections.Generic;

namespace QuizXaml
{
    public class Pergunta
    {
        public string Texto { get; set; }
        public bool Resposta { get; set; }
        public static List<Pergunta> GerarPerguntas()
        {
            return new List<Pergunta>()
            {
                new Pergunta()
                {
                    Texto = "O nome do criador do kernel Linux é\nLunus Trovalds!",
                    Resposta = false
                },
                new Pergunta()
                {
                    Texto = "Existem varios tipos de G.P.L!",
                    Resposta = false
                },
                new Pergunta()
                {
                    Texto = "O sistema Operacional Windows atualmente\ndomina o mercado" ,
                    Resposta = true
                },
                new Pergunta(){
                    Texto = "O significado da vida, do universo\ne tudo mais é 42",
                    Resposta = true
                },
                new Pergunta()
                {
                    Texto = "Hardware são aplicativos e\nSoftware é a parte fisica",
                    Resposta = false
                },
                new Pergunta()
                {
                    Texto = "Linux foi baseado em UNIX",
                    Resposta = true
                },
                new Pergunta()
                {
                    Texto ="Este programa foi feito em Visual Basic",
                    Resposta = false
                },
                new Pergunta()
                {
                    Texto = "Este programa foi feito\nem uma maquina virtual",
                    Resposta = true
                }
            };
        }
    } 
}
