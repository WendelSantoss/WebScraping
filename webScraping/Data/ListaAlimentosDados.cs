using MySql.Data.MySqlClient;
using webScraping.Models;


namespace webScraping.Data
{
    public static class ListaAlimentos
    {
     
        public static List<AlimentosModel> ListandoTodosAlimentos()
        {
            // lista com todos os elementos no banco de dados
            List<AlimentosModel> alimentos = new List<AlimentosModel>();

            //conexao com o banco
            MySqlConnection Connection = new MySqlConnection(DataMysql.ConexaoBanco);
            Connection.Open();

            // comando para gerar a abertura do banco
            string query = "SELECT * FROM alimentos";

            MySqlCommand comandoQuerySql = Connection.CreateCommand();
            comandoQuerySql.CommandText = query;
             
                    
            using (MySqlDataReader reader = comandoQuerySql.ExecuteReader())
            {
                while (reader.Read())
                {
                    AlimentosModel alimento = new AlimentosModel
                    {
                        Codigo = reader.GetString("codigo"),
                        Nome = reader.GetString("nome"),
                        NomeCientifico = reader.GetString("nomeCientifico"),
                        Grupo = reader.GetString("grupo")
                    };
                    alimentos.Add(alimento);
                }
            }

            Connection.Close();

            return alimentos;
        }


    }
}