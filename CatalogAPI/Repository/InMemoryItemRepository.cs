using CatalogAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Repository
{
    public class InMemoryItemRepository //: IItemRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name="Potion", Price=500, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name="Iron Sword", Price=600, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name="Bronse Shield", Price=700, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name="Boll", Price=800, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name="Bat", Price=900, CreatedDate = DateTimeOffset.UtcNow },
        };

        public IEnumerable<Item> GetItemsAsync()
        {
            return items;
        }

        public Item GetItemAsync(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItemAsync(Item item)
        {
            items.Add(item);
        }

        public void UpdateItemAsync(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }

        //Task<Item> IItemRepository.GetItemAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<IEnumerable<Item>> IItemRepository.GetItemsAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //Task IItemRepository.CreateItemAsync(Item item)
        //{
        //    throw new NotImplementedException();
        //}

        //Task IItemRepository.UpdateItemAsync(Item item)
        //{
        //    throw new NotImplementedException();
        //}

        //Task IItemRepository.DeleteItemAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
