
using StoreService.Domain.Orders;

namespace StoreService.Domain.Users
{
    public partial class User : IEntity
    {
        #region Identifier
        public int Id { get; set; }

        #endregion
        
        #region Features
        
        public string Name { get; set; }

        #endregion
        
        #region Mangement
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        #endregion

        #region Relations

        public ICollection<Order> Orders { get; set; }

        #endregion

    }
}