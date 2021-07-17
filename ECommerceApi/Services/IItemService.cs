using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApi.Contracts;

namespace ECommerceApi.Services
{
    public interface IItemService
    {
        Task<ItemFull> CreateItem(ItemCreateRequest item);

        Task EditItemById(int id, ItemFull item);

        Task EditItemBySku(string sku, ItemFull item);

        Task DeleteItemById(int id);

        Task DeleteItemBySku(string sku);
        
        Task<ItemFull> GetItemById(int id);

        Task<ItemFull> GetItemBySku(string sku);

        Task<IEnumerable<ItemFull>> GetAllItems(GetItemsRequest parameters);
    }
}