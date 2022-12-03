using CatalogAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI
{
    public class CatalogDBContext : DbContext
    {

        public CatalogDBContext(DbContextOptions<CatalogDBContext> options) : base(options)
        {

        }

        public DbSet<Item> Items
        {
            get;
            set;
        }



    }
}
