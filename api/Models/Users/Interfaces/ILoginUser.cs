namespace API.Models.Users.Interfaces
{
    public interface ILoginUser
    {
         public User Login(string Email, string Password);
    }
}