using System.Threading.Tasks;
using api.Models.Admins;
using api.Models.Admins.Interfaces;
using api.Models.Customers;
using api.Models.Customers.Interfaces;
using api.Models.Trainers;
using api.Models.Trainers.Interfaces;

namespace api.Models.Users
{
    public class LoginUser
    {
        public User Login(string Email, string Password)
        {
            User curUser = new User();
            try
            {
                IReadCust newCustLogin = new ReadCustData();
                curUser.UserType='c';
                curUser.UserID = newCustLogin.LoginCustomer(Email, Password).ID;
            }
            catch
            {
                try
                {
                    IReadTrainer newTrainerLogin = new ReadTrainerData();
                    curUser.UserType='t';
                    curUser.UserID = newTrainerLogin.LoginTrainer(Email, Password).ID;
                }
                catch
                {
                    try
                    {
                        IReadAdmin newAdminLogin = new ReadAdminData();
                        curUser.UserType='a';
                        curUser.UserID = newAdminLogin.LoginAdmin(Email, Password).ID;
                    }
                    catch
                    {
                        curUser.UserID = 0;
                        curUser.UserType='d';
                        
                    }  
                }
            }
            return curUser;
        }
    }
}