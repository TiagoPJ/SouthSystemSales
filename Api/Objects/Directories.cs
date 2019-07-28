using System;

namespace Api.Objects
{
    public class Directories
    {
        public string InDirectory { get; set; }
        public string OutDirectory { get; set; }
        public string FullPathInDirectory { get { return $"{Environment.GetEnvironmentVariable("HOMEPATH")}{InDirectory}"; } }
        public string FullPathOutDirectory { get { return $"{Environment.GetEnvironmentVariable("HOMEPATH")}{OutDirectory}"; } }
    }
}
