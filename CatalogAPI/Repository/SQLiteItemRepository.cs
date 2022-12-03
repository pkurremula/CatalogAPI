using CatalogAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Repository
{
    public class SQLiteItemRepository : IItemRepository
    {

        private readonly CatalogDBContext _context;

        public SQLiteItemRepository(CatalogDBContext context)
        {
            _context = context;
        }

        public async Task CreateItemAsync(Item item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(item => item.Id == id);
             _context.Items.Remove(item);
            _context.SaveChanges();
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            return await _context.Items.FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task UpdateItemAsync(Item item)
        {
             _context.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
