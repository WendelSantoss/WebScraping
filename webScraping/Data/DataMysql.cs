namespace webScraping.Data
{
    public class DataMysql
    {
        const string servidor = "localhost";
        const string bancoDados = "webScraping";
        const string usuario = "root";
        const string senha = "1402";

       public static string ConexaoBanco = $"server={servidor}; user id={usuario};database={bancoDados};password={senha}";
    }
}
