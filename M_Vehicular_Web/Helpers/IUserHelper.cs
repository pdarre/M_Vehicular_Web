namespace M_Vehicular_Web.Helpers
{
    using Microsoft.AspNetCore.Identity;
    using Models;
    using System.Threading.Tasks;

    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);
    }
}