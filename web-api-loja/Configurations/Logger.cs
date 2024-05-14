using System;
using System.IO;

namespace web_api_loja.Configurations
{
    public class Logger
    {
        public static string GetPath()
        {
            return System.Configuration.ConfigurationManager.AppSettings["caminhoLog"];
        }

        private static string GetArchiveName()
        {
            return $"{DateTime.Now.ToString("yyyy-MM-dd")}.txt";
        }

        public static string GetFullPath()
        {
            return Path.Combine(GetPath(), GetArchiveName());
        }
    }
}