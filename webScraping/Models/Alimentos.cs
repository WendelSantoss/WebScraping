using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webScraping.Data;

namespace webScraping.Models
{
    public class AlimentosModel
    {

        private int id;
        private string codigo;
        private string nome;
        private string nomeCientifico;
        private string grupo;

     

        public int Id {
            get { return id; } 
            set { id = value;}
        }
        
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string NomeCientifico
        {
            get { return nomeCientifico; } 
            set { nomeCientifico = value; }
        }

        public string Grupo { 
            get { return  grupo; }
            set {  grupo = value; } 
        }


        public void cadastrarAlimento()
        {
            try
            {
                
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(DataMysql.ConexaoBanco);
                MysqlConexaoBanco.Open();

                //comando de inserir dados o alimento no banco de dados
                string insert = $" insert into alimentos (codigo, nome, nomeCientifico, grupo) values ('{Codigo}','{Nome}', '{NomeCientifico}','{Grupo}')";

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
