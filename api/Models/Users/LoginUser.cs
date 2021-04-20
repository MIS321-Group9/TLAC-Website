using System.Threading.Tasks;
using API.Models.Admins;
using API.Models.Admins.Interfaces;
using API.Models.Customers;
using API.Models.Customers.Interfaces;
using API.Models.Trainers;
using API.Models.Trainers.Interfaces;

namespace API.Models.Users
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