using System.Threading.Tasks;

namespace BlazorSportStoreAuth.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(string email, string password);
        Task<bool> LoginAsync(string email, string password);
    }
}
