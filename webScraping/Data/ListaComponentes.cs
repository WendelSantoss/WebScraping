using MySql.Data.MySqlClient;
using webScraping.Models;

namespace webScraping.Data
{
    public class ListaComponentes
    {
        public static List<ComponentesModel> ListandoTodosComponentes()
        {
            // lista com todos os elementos no banco de dados
            List<ComponentesModel> componentes = new List<ComponentesModel>();

            //conexao com o banco
            MySqlConnection ConnectionComponentes = new MySqlConnection(DataMysql.ConexaoBanco);
            ConnectionComponentes.Open();

            // comando para gerar a abertura do banco
            string query = "SELECT * FROM componentes";

            MySqlCommand comandoQuerySql = ConnectionComponentes.CreateCommand();
            comandoQuerySql.CommandText = query;


            using (MySqlDataReader reader = comandoQuerySql.ExecuteReader())
            {
                while (reader.Read())
                {
                    ComponentesModel componente = new ComponentesModel
                    {
                        Codigo = reader.GetString("codigo"),
                        Definicao = reader.GetString("definicao"),
                        Unidades = reader.GetString("unidades"),
                        ValorP100g = reader.GetString("valorP100g"),
                        DesvioP = reader.GetString("desvioP"),
                        ValorMin = reader.GetString("valorMin"),
                        ValorMax = reader.GetString("valorMax"),
                        NumeroDeDados = reader.GetString("numeroDeDados"),
                        Referencia = reader.GetString("referencia"),
                        TipoDeDados = reader.GetString("tipoDeDados")
                    };
                    componentes.Add(componente);
                }
            }

            ConnectionComponentes.Close();


            return componentes;
        }

    }
}
