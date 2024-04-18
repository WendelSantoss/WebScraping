using HtmlAgilityPack;
using System.Text.RegularExpressions;


namespace webScraping.Models
{
    public class ScrapingAlimentos
    {
        public static string RemoverTagsHtml(string input)
        {
            // metodo para retirar tags html que estao vindo nos dados
            return Regex.Replace(input, "<.*?>", string.Empty);
        }

        public void ColetorScraperAlimentos( )
        {
                   
             //outra variável que se encontra na url, que precisa ser tratada a cada mudança de 10 pages
            // int idPagination = ((pageAtual - 1) / 10) + 1;

            //requisição no site e armazenamento  dos dados
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load($"https://www.tbca.net.br/base-dados/composicao_estatistica.php?pagina={1}&atuald={1}#");// falta atualizar para dinamizar as paginas buscadas.

            // armazenando tabela que contém os dados alimentícios
            HtmlNode tabela = doc.DocumentNode.SelectSingleNode("//tbody");

            // verificação se tboddy foi lido
            if (tabela != null)
            {
                Console.WriteLine("table foi lida");

                // leitura de cada linha de table de alimentos
                HtmlNodeCollection linhasAlimentos = tabela.SelectNodes("tr");
                foreach (HtmlNode dados in linhasAlimentos)
                {
                    // extraindo os dados das colunas 
                    HtmlNodeCollection colunasAlimentos = dados.SelectNodes("td/a");
                    if (colunasAlimentos != null && colunasAlimentos.Count > 0)
                    {
                        AlimentosModel alimentos = new AlimentosModel
                        {
                            Codigo = colunasAlimentos[0].InnerHtml.Trim(),
                            Nome = RemoverTagsHtml(colunasAlimentos[1].InnerHtml.Trim()),
                            NomeCientifico = RemoverTagsHtml(colunasAlimentos[2].InnerHtml.Trim()),
                            Grupo = colunasAlimentos[3].InnerHtml.Trim()
                        };

                        // Inicio a Verificação se existe o alimento na tabela, se n, ele salvara o alimento e seus componentes em uma outra tabela
                        if (Verificador.AlimentoJaCadastrado(alimentos.Codigo) == false )
                        {
                            // aqui atribuo ao banco de dados as infos recolhidads do sites 
                            alimentos.cadastrarAlimento();
                        }
                        else
                        {
                            Console.WriteLine("Alimento já cadastrado no banco de dados.");
                        }
                    }
                }                 
            }
            else
            {

                Console.WriteLine("table n foi lida");
            }

        }
    }
}
