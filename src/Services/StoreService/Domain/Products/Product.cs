
namespace StoreService.Domain.Products
{
    public partial class Product : IEntity
    {
        #region Identifier
        public int Id { get; set; }

        #endregion
        
        #region Features
        
        public string Title { get; set; }
        public uint InventoryCount { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        

        #endregion
        
        #region Mangement
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        #endregion

        #region Relations
        

        #endregion

    }
}