using MySql.Data.MySqlClient;
using webScraping.Data;

namespace webScraping.Models
{

    public class ComponentesModel
    {

        private int id;
        private string definicao;
        private string codigo;
        private string unidades;
        private string valorP100g;
        private string desvioP;
        private string valorMin;
        private string valorMax;
        private string numeroDeDados;
        private string referencia;
        private string tipoDeDados;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Definicao
        {
            get { return definicao; }
            set { definicao = value; }
        }

        public string Unidades {
            get { return unidades; }
            set { unidades = value; } 
        }

        public string ValorP100g {

            get { return valorP100g; }
            set { valorP100g = value; }
        }

   
        public string DesvioP {
            get { return desvioP; }
            set { desvioP = value; }
        }

    
        public string ValorMin {
            get { return valorMin; }
            set { valorMin = value; } 
        }

        public string ValorMax {
            get { return valorMax; }
            set { valorMax = value; } 
        }

       
        public string NumeroDeDados {
            get { return numeroDeDados; }
            set { numeroDeDados = value; }
        }

   
        public string Referencia { 
            get { return referencia; }
            set {  referencia = value; }
        }

        public string TipoDeDados {
            get { return tipoDeDados; } 
            set {  tipoDeDados = value; }
        }

        public void cadastrarComponentes()
        {
            try
            {

                MySqlConnection MysqlConexaoBanco = new MySqlConnection(DataMysql.ConexaoBanco);
                MysqlConexaoBanco.Open();

                //comando de inserir dados o alimento no banco de dados
                string insert = $" insert into componentes ( codigo, definicao, unidades, valorP100g, desvioP, valorMin, valorMax, numeroDeDados, referencia, tipoDeDados) values ('{codigo}','{definicao}','{unidades}','{valorP100g}','{desvioP}','{valorMin}','{valorMax}','{NumeroDeDados}','{Referencia}','{TipoDeDados}')";

                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = insert;

                comandoSql.ExecuteNonQuery(); // Executa o comando SQL de inserção

                MysqlConexaoBanco.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar informações no banco: {ex.Message}");
            }
        }
    }
}
