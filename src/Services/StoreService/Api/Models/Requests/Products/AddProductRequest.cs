namespace StoreService.Api.Models.Requests.Products
{
    public class AddProductRequest
    {
        public string Title { get; set; }
        public uint InventoryCount { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
    }
}
