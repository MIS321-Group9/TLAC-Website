namespace api.Models
{
    public class ConnectionString
    {
        // EVERY table starts with a "t" and ends with an "s" - in addition to the table name (i.e. tTRANSACTIONS)
        public string cs { get; set; }
        public ConnectionString(){
            string server = "u6354r3es4optspf.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "ainsia4friwohfpj";
            string port = "3306";
            string username = "b9h0ptqd0z7wirq5";
            string password = "imqwemr1gl1iisd2";

            cs = $@"server={server};user={username};database={database};port={port};password={password};";
        }
    }
}