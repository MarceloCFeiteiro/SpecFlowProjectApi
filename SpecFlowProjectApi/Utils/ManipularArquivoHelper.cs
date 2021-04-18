using System.IO;

namespace SpecFlowProjectApi.Utils
{
    public static class ManipularArquivoHelper
    {
        /// <summary>
        /// Representa o caminho para o arquivo;
        /// </summary>
        private static readonly string Caminho = @"C:\Users\Eshi\source\repos\SpecFlowProjectApi\SpecFlowProjectApi\Data\Files\";

        /// <summary>
        /// Representa o nome do arquivo
        /// </summary>
        private static readonly string NomeArquivo = @"Usuario.json";

        /// <summary>
        /// Método responsável por salvar um registro no arquivo em formato json.
        /// </summary>
        /// <param name="obj">Entidade a ser salva</param>
        public static void SalvarNoArquivoEmFormatoJson(object obj)
        {
            string texto = JsonHelper.EntidadeParaJson(obj);

            File.WriteAllText(string.Concat(Caminho, NomeArquivo), texto);
        }

        /// <summary>
        /// Método responsável por retornar um objeto dinâmico com os dados do arquivo.
        /// </summary>
        /// <returns>Retorna um tipo dinâmico com os valores de um json</returns>
        public static T LerDeUmArquivoQueEstaNoFormatoJson<T>()
        {
            string texto = File.ReadAllText(string.Concat(Caminho, NomeArquivo));

            return JsonHelper.JsonParaEntidade<T>(texto);
        }
    }
}