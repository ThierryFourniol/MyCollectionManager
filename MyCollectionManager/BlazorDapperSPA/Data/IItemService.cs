using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDapperSPA.Data
{
    public interface IItemService
    {
        Task<IEnumerable<ItemModel>> GetItems();
        Task<bool> CreateItem(Item item);
        Task<bool> EditItem(int id, ItemModel item);
        Task<ItemModel> SingleItem(int id);
        Task<bool> DeleteItem(int id);
    }
}
