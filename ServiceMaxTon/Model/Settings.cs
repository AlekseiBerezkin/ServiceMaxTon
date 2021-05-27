using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceMaxTon.Model
{
     static public class Settings
    {
        public static string Token { get; } = "1787244610:AAHjA_pa6Z3CdGCxUtNkad-SYCvD4EVGzCo";
        public static string Url { get; } = "https://3bd681281193.ngrok.io";
        public static string Name { get; } = "Maxtonirovka_bot";
        public static string connectionString = "Data Source=usersdata.db";
        public static string workingDirectory = Environment.CurrentDirectory;
        public static int GMT = 3;
    }
}
