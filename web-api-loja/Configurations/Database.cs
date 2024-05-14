namespace web_api_loja.Configurations
{
    public class Database
    {
        public static string getConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["loja"].ConnectionString;
        }
    }
}