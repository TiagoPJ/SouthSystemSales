using System.IO;

namespace Repositorio.Implementacao.Repositorio
{
    public class SalesAnalysisRepository
    {
        #region Public Methods

        /// <summary>
        /// Save the file with yours statistics.
        /// </summary>
        /// <param name="outFileDirectory">Output file directory</param>
        /// <param name="qtdClient">Quantity of Clients</param>
        /// <param name="qtdSalesman">Quantity of Salesman</param>
        /// <param name="maxIdSale">Max ID Sale</param>
        /// <param name="salesmanName">Name of Salesman</param>
        public static void SaveData(string outFileDirectory, int qtdClient, int qtdSalesman, int maxIdSale, string salesmanName)
        {
            if (!File.Exists(outFileDirectory))
            {
                using (StreamWriter sw = new StreamWriter(outFileDirectory))
                {
                    sw.WriteLine($"Quantidade de clientes no arquivo de entrada: {qtdClient}");
                    sw.WriteLine($"Quantidade de vendedor no arquivo de entrada: {qtdSalesman}");
                    sw.WriteLine($"ID da venda mais cara: { maxIdSale }");
                    sw.WriteLine($"O pior vendedor: { salesmanName }");
                    sw.Close();
                }
            }
        }

        #endregion
    }
}
