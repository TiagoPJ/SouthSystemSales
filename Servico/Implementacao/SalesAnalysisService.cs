using Dominio.Enums;
using Dominio.Sales;
using Repositorio.Implementacao.Repositorio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Servico.Helper;

namespace Servico.Implementacao
{
    public class SalesAnalysisService
    {
        #region properties

        private static List<Salesman> _listSalesman { get; set; }
        private static List<Client> _listClient { get; set; }
        private static List<Sales> _listSales { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Execute  the process.
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <param name="outFileDirectory">Output file directory</param>
        public static void ProcessFile(string filePath, string outFileDirectory)
        {
            try
            {
                _listSalesman = new List<Salesman>();
                _listClient = new List<Client>();
                _listSales = new List<Sales>();

                string fileName = Path.GetFileNameWithoutExtension(filePath);
                var lines = ReadFile(filePath);
                ProcessLines(lines);
                ProcessResult(string.Concat(outFileDirectory, fileName, ".done.dat"));

                if (File.Exists(filePath))
                    //Delete file processed.
                    File.Delete(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Build the object.
        /// </summary>
        /// <Type name="T">Object type</Type>
        /// <param name="args">Object property arguments</param>
        private static T BuildObject<T>(object[] args)
        {
            return (T)Activator.CreateInstance(typeof(T), args);
        }

        /// <summary>
        /// Process the file.
        /// </summary>
        /// <param name="filePath">Input file directory</param>
        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        /// <summary>
        /// Process file line.
        /// </summary>
        /// <param name="lines">Lines of file</param>
        private static void ProcessLines(string[] lines)
        {
            foreach (var line in lines)
            {
                object[] data = line.Split('ç');
                TypeIdentifierEnum type = (TypeIdentifierEnum)int.Parse((string)data[0]);

                // Remove the first index to build object dynamic
                data = data.Skip(1).ToArray();

                switch (type)
                {
                    case TypeIdentifierEnum.Salesman:
                        _listSalesman.Add(BuildObject<Salesman>(data));
                        break;
                    case TypeIdentifierEnum.Client:
                        _listClient.Add(BuildObject<Client>(data));
                        break;
                    case TypeIdentifierEnum.Sale:
                        string[] itensToReplace = Regex.Replace((string)data[1], @"(\[)|(\])", "").Split(',');
                        var itens = new List<Item>();

                        itensToReplace.ToList().ForEach(x =>
                        {
                            itens.Add(BuildObject<Item>(x.Split('-')));
                        });

                        // Receive List of Itens
                        data[1] = itens;
                        _listSales.Add(BuildObject<Sales>(data));
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Execute  the process.
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <param name="outFileDirectory">Output file directory</param>
        private static void ProcessResult(string outFileDirectory)
        {
            int qtdClient = _listClient.Count;
            int qtdSalesman = _listSalesman.Count;
            int maxIdSale = _listSales.MaxBy(x => x.TotalValueSale).Id;
            string salesmanName = _listSales.MinBy(x => x.TotalValueSale).SalesmanName;

            SalesAnalysisRepository.SaveData(outFileDirectory, qtdClient, qtdSalesman, maxIdSale, salesmanName);
        }

        #endregion
    }
}
