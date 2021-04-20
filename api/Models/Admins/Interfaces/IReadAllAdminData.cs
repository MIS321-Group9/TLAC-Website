namespace API.Models.Admins.Interfaces
{
    public interface IReadAdmin
    {
        public Admin ReadAdmin(int AdminID);
        public Admin LoginAdmin(string Email, string Password);
    }
}