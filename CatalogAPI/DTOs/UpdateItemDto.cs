﻿using System.ComponentModel.DataAnnotations;

namespace CatalogAPI.DTOs
{
    public record UpdateItemDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        [Range(0, 1000)]
        public decimal Price { get; init; }
    }
}
