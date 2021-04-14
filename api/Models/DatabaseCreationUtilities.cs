using System.Diagnostics.Tracing;
namespace api.Models
{
    public class DatabaseCreationUtilities
    {
        public static void CreateAllTables()
        {
            Trainers.CreateTrainer.CreateTrainerTable();
            Customers.CreateCust.CreateCustTable();
            Admins.CreateAdmin.CreateAdminTable();
            Creditcards.CreateCC.CreateCCTable();
            Sessions.CreateSession.CreateSessionTable();
            Discounts.CreateDis.CreateDisTable();
            AdminEvents.CreateAdminEvent.CreateAdminEventTable();
            Edits.CreateEdits.CreateEditsTable();
            Creates.CreateCreates.CreateCreatesTable();
            Transactions.CreateTrans.CreateTransTable();
        }
    }
}