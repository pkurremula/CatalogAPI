using CatalogAPI.DTOs;
using CatalogAPI.Entities;
using CatalogAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : Controller
    {
        private readonly IItemRepository repository;

        public ItemsController(IItemRepository itemRepo)
        {
            repository = itemRepo;
        }


        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            var items = (await repository.GetItemsAsync()).Select(item => item.AsDTO());

            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var item = await repository.GetItemAsync(id);
            
            if (item is null)
                return NotFound();

            return item.AsDTO();
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await repository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDTO());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var exitingitem = await repository.GetItemAsync(id);

            if(exitingitem is null) return NotFound();

            Item updatedItem = exitingitem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

           await repository.UpdateItemAsync(updatedItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var exitingitem = await repository.GetItemAsync(id);

            if (exitingitem is null) return NotFound();

            await repository.DeleteItemAsync(id);

            return NoContent();
        }
    }
}
