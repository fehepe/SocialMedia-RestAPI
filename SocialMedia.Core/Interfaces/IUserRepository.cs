using SocialMedia.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserId(int id);
        Task<IEnumerable<User>> GetUsers();
    }
}