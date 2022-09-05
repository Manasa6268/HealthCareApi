using AdminApi.Models;

namespace AdminApi.Services
{
    public interface IAdminService
    {
        string CreateAccount(UserDetails userDetails);
    }
}