using CatalogAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogAPI.Repository
{
    public interface IItemRepository
    {
       Task<Item> GetItemAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsAsync();

        Task CreateItemAsync(Item item);

        Task UpdateItemAsync(Item item);

        Task DeleteItemAsync(Guid id);
    }
}