using Api.Objects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Servico.Implementacao;
using System.IO;

namespace Api
{
    public class WatcherConfig
    {
        private static Directories _directories { get; set; }
        public WatcherConfig(IConfiguration configuration)
        {
            _directories = new Directories();
            new ConfigureFromConfigurationOptions<Directories>(configuration.GetSection("Paths")).Configure(_directories);
            Register();
        }

        private static void Register()
        {
            // Verify - Create folders
            VerifyFoldersExist();

            var fsw = new FileSystemWatcher
            {
                Filter = "*.dat",
                Path = _directories.FullPathInDirectory,
                EnableRaisingEvents = true,
                IncludeSubdirectories = false
            };

            fsw.Created += new FileSystemEventHandler(OnCreated);
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            SalesAnalysisService.ProcessFile(e.FullPath, _directories.FullPathOutDirectory);
        }

        private static void VerifyFoldersExist()
        {
            if (!Directory.Exists(_directories.FullPathInDirectory))
                Directory.CreateDirectory(_directories.FullPathInDirectory);

            if (!Directory.Exists(_directories.FullPathOutDirectory))
                Directory.CreateDirectory(_directories.FullPathOutDirectory);
        }
    }
}
