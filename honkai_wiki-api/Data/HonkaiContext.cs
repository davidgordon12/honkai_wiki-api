using System.Data.SqlClient;

namespace honkai_wiki_api.Data
{
    public class HonkaiContext
    {
        public static string conString { get; set; }
        public SqlConnection sqlConnection;
        public HonkaiContext()
        {
             sqlConnection = new(conString);
        }

    }
}