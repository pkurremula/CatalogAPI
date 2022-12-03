﻿using CatalogAPI.DTOs;
using CatalogAPI.Entities;

namespace CatalogAPI
{
    public static class Extensions
    {
        public static ItemDto AsDTO(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}
