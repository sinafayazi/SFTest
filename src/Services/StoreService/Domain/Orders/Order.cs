
using StoreService.Domain.Products;
using StoreService.Domain.Users;

namespace StoreService.Domain.Orders
{
    public partial class Order : IEntity
    {
        #region Identifier
        public int Id { get; set; }

        #endregion
        
        #region Features

        #endregion
        
        #region Mangement
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        #endregion

        #region Relations

        public User Buyer { get; set; }
        public int BuyerId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
        

        #endregion

    }
}