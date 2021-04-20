using System.Diagnostics.Tracing;
namespace API.Models
{
    public class DatabaseCreationUtilities
    {
        public static void CreateAllTables()
        {
            // creates all the database tables in the correct order
            Trainers.CreateTrainer.CreateTrainerTable();
            Customers.CreateCust.CreateCustTable();
            Admins.CreateAdmin.CreateAdminTable();
            Creditcards.CreateCC.CreateCCTable();
            Sessions.CreateSession.CreateSessionTable();
            Discounts.CreateDis.CreateDisTable();
            AdminEvents.CreateAdminEvent.CreateAdminEventTable();
            Transactions.CreateTrans.CreateTransTable();
        }
    }
}