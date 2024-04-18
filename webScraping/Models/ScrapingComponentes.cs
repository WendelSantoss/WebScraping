using HtmlAgilityPack;

namespace webScraping.Models
{
    public class ScrapingComponentes
    {
        public void ColetorScraperComponentes(string Codigo)
        {
            if (Verificador.ComponenteJaCadastrado(Codigo) == false)
            {
                //requisição no site e armazenamento  dos dados
                HtmlWeb web = new HtmlWeb();

                //url para acesso dos componentes de cada alimento
                string urlComponentes = "https://www.tbca.net.br/base-dados/int_composicao_estatistica.php?cod_produto=" + Codigo;
                HtmlDocument componentes = web.Load(urlComponentes);

                HtmlNode tabelaComponentes = componentes.DocumentNode.SelectSingleNode("//tbody");

                if (tabelaComponentes != null)
                {
                    Console.WriteLine("table  componentes foi lida foi lida");

                    HtmlNodeCollection linhasComponentes = tabelaComponentes.SelectNodes("tr");
                    foreach (HtmlNode dadosComponentes in linhasComponentes)
                    {
                        HtmlNodeCollection colunasComponentes = dadosComponentes.SelectNodes("td");
                        if (colunasComponentes != null && colunasComponentes.Count > 0)
                        {
                            ComponentesModel componente = new ComponentesModel
                            {
                                Codigo = Codigo,
                                Definicao = colunasComponentes[0].InnerHtml.Trim(),
                                Unidades = colunasComponentes[1].InnerHtml.Trim(),
                                ValorP100g = colunasComponentes[2].InnerHtml.Trim(),
                                DesvioP = colunasComponentes[3].InnerHtml.Trim(),
                                ValorMin = colunasComponentes[4].InnerHtml.Trim(),
                                ValorMax = colunasComponentes[5].InnerHtml.Trim(),
                                NumeroDeDados = colunasComponentes[6].InnerHtml.Trim(),
                                Referencia = colunasComponentes[7].InnerHtml.Trim(),
                                TipoDeDados = colunasComponentes[8].InnerHtml.Trim()
                            };

                            // Funcao de salvar no banco
                            componente.cadastrarComponentes();
                        }
                    }
                    Console.WriteLine(" componentes cadastrado.");
                }
                else
                {

                     Console.WriteLine("table de componentes n foi lida");
                }
            }
           

        }
    }
}