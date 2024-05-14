using System;
using System.IO;

namespace web_api_loja.Utils
{
    public class Logger
    {
        public static void WriteException(string fullPath, Exception ex)
        {
            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.Write("Data: ");
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sw.Write("Mensagem: ");
                sw.WriteLine(ex.Message);
                sw.Write("StackTrace: ");
                sw.WriteLine(ex.StackTrace);
            }
        }
    }
}