using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDapperSPA.Data
{
    public interface IUserCollectionService
    {
        Task<IEnumerable<UserCollection>> GetCollections();
        Task<bool> CreateCollection(UserCollection collection);
        Task<bool> EditCollection(int id, UserCollection collection);
        Task<UserCollection> SingleCollection(int id);
        Task<bool> DeleteCollection(int id);
    }
}
