using System.IO;

namespace Repositorio.Implementacao.Repositorio
{
    public class SalesAnalysisRepository
    {
        #region Public Methods

        /// <summary>
        ///     Tries to open the file for R/W to see if its lock. Returns Boolean
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>bool</returns>
        public static bool IsFileLocked(string filePath)
        {
            FileStream stream = null;
            var file = new FileInfo(filePath);
            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException ex)
            {
                return true;
            }
            finally
            {
                stream?.Close();
            }

            //file is not locked
            return false;
        }

        /// <summary>
        /// Process the file.
        /// </summary>
        /// <param name="filePath">Input file directory</param>
        public static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

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
                    sw.WriteLine($"Amount of clients in the input file is: { qtdClient }");
                    sw.WriteLine($"Amount of salesman in the input file is: { qtdSalesman }");
                    sw.WriteLine($"ID of the most expensive sale is: { maxIdSale }");
                    sw.WriteLine($"Worst salesman ever is: { salesmanName }");
                    sw.Close();
                }
            }
        }

        #endregion
    }
}
