namespace api.Models
{
    public class ConnectionString
    {
        public string cs { get; set; }
        public ConnectionString(){
            string server = "tlacfitness.mysql.database.azure.com";
            string database = "TLACFitness";
            string port = "3306";
            string username = "tlac_admin@tlacfitness";
            string password = "P@$$w0rd";

            cs = $@"server={server};user={username};database={database};port={port};password={password};";
        }
    }
}