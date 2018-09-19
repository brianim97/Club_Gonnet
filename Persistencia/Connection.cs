using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace Persistencia
{
    public static class Connection
    {
        public static string ConnectionString;

        public static void LoadConnectionString()
        {
            string[] f = File.ReadAllLines("..\\..\\..\\Persistencia\\bin\\Debug\\ConnectionStringFile.txt");
            
            ConnectionString = f[0];
        }
    }
}
