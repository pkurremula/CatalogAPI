namespace CatalogAPI.Entities
{
    public class Catalog : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureURL { get; set; }
        
        public int ProductTypeId { get; set; }
        
        public int ProductBrandId { get; set; }
    }
}
