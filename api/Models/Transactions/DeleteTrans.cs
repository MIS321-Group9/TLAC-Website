using api.Models.Transactions.Interfaces;
using MySql.Data.MySqlClient;

namespace api.Models.Transactions
{
    public class DeleteTrans : IDeleteTrans
    {
        public static void DeleteTransTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS ttransactions";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }

        void IDeleteTrans.DeleteTrans(int TransactionID)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $"DELETE FROM ttransaction WHERE id={TransactionID}";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}