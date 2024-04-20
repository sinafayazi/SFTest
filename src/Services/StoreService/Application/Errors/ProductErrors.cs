using Communal.Application.Constants;
using Communal.Application.Infrastructure.Errors;

namespace StoreService.Application.Errors
{
    public static class ProductErrors
    {
        // Code ranges for Product Service is between 00001 and 00099
        public static ErrorModel ProductNotFoundError = new ErrorModel(
            code: 00001,
            title: "Product Service Error",
            (
                Language: Language.English,
                Message: "Product not found!!!"
            ));

        public static ErrorModel DuplicateTitleError = new ErrorModel(
            code: 00002,
            title: "Product Service Error",
            (
                Language: Language.English,
                Message: "Title is duplicate!!!"
            ));
        
        public static ErrorModel DuplicateProductError = new ErrorModel(
            code: 00003,
            title: "Product Service Error",
            (
                Language: Language.English,
                Message: "Product is duplicate!!!"
            ));
        public static ErrorModel UserNotFoundError = new ErrorModel(
            code: 00004,
            title: "User Service Error",
            (
                Language: Language.English,
                Message: "User not found!!!"
            ));
        
        public static ErrorModel ProductOutOfStockError = new ErrorModel(
            code: 00005,
            title: "Product Service Error",
            (
                Language: Language.English,
                Message: "Product out of stock!!!"
            ));
    }
}