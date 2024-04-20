
namespace StoreService.Application.Models.Responses.Products
{
    public class ProductResponse
    {
        public int Id { get; set; }
        
        
        public string Title { get; set; }
        public uint InventoryCount { get; set; }
        public double OriginalPrice { get; set; }
        public double DiscountInPercent { get; set; }
        public double EndPrice { get; set; }
        

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}