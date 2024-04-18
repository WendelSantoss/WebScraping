using webScraping.Data;

namespace webScraping.Models
{
    public class Verificador
    {
        //componente de verificação para verificar se existe o alimento registrado na tabela ou nao
        public static bool AlimentoJaCadastrado(string Codigo)
        {
            List<AlimentosModel> listaAlimentos = ListaAlimentos.ListandoTodosAlimentos();

            foreach (var alimento in listaAlimentos)
            {
                if (alimento.Codigo == Codigo)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ComponenteJaCadastrado(string Codigo)
        {
            List<ComponentesModel> listaComponentes = ListaComponentes.ListandoTodosComponentes();

            foreach (var componete in listaComponentes)
            {
                if (componete.Codigo == Codigo)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
