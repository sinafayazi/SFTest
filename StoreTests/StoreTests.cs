using System.Linq.Expressions;
using Communal.Application.Infrastructure.Errors;
using Communal.Application.Infrastructure.Operations;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using StoreService.Application.Errors;
using StoreService.Application.Handlers.Products;
using StoreService.Application.Interfaces;
using StoreService.Application.Models.Commands.Products;
using StoreService.Application.Models.Queries.Products;
using StoreService.Application.Models.Responses.Products;
using StoreService.Application.Validators.Products;
using StoreService.Domain.Products;

namespace StoreTests;

public class StoreTests
{
    [Fact]
        public void AddProductCommandHandler_Returns_Created()
        {
            // Arrange
            var fakeAddProductCommand = new AddProductCommand
            {
                Title = "fake-title",
                InventoryCount = 10,
                Price = 100,
                Discount = 10
            };
            
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup(x => x.Products
                    .ExistsAsync(
                        It.IsAny<Expression<Func<Product, bool>>>()))
                .Returns(Task.FromResult(false));

            mockUnitOfWork.Setup(x => x.Products
                .Add(
                    It.IsAny<Product>()));
                 
            // Act
            var addProductCommandHandler = new AddProductCommandHandler(mockUnitOfWork.Object);
            var result = addProductCommandHandler.Handle(fakeAddProductCommand, new CancellationToken()).GetAwaiter().GetResult();
            
            
            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<OperationResult>(result);
            Assert.Equal(OperationResultStatus.Created, result.Status);
        }
        
        [Fact]
        public void AddProductCommandHandler_Returns_Unprocessable()
        {
            // Arrange
            var fakeAddProductCommand = new AddProductCommand
            {
                Title = "fake-title",
                InventoryCount = 10,
                Price = 100,
                Discount = 10
            };
            
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup(x => x.Products
                    .ExistsAsync(
                        It.IsAny<Expression<Func<Product, bool>>>()))
                .Returns(Task.FromResult(true));

            // Act
            var addProductCommandHandler = new AddProductCommandHandler(mockUnitOfWork.Object);
            var result = addProductCommandHandler.Handle(fakeAddProductCommand, new CancellationToken()).GetAwaiter().GetResult();
            
            
            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<OperationResult>(result);
            Assert.Equal(OperationResultStatus.Unprocessable, result.Status);
        }
        
        [Fact]
        public void AddProductCommandValidator_Returns_True()
        {
            // Arrange
            var fakeAddProductCommand = new AddProductCommand
            {
                Title = "fake-title",
                InventoryCount = 10,
                Price = 100,
                Discount = 10
            };
            
            var validator = new AddProductCommandValidator();
            
            // Act
            var validation = validator.Validate(fakeAddProductCommand);
            var validationResult = validation.IsValid;
            // Assert
            Assert.NotNull(validation);
            Assert.True( validationResult);
            Assert.Empty(validation.Errors);
        }
        
        [Fact]
        public void AddProductCommandValidator_Returns_False_When_Title_Is_Empty()
        {
            // Arrange
            var fakeAddProductCommand = new AddProductCommand
            {
                Title = "",
                InventoryCount = 10,
                Price = 100,
                Discount = 10
            };
            
            var validator = new AddProductCommandValidator();
            
            // Act
            var validation = validator.Validate(fakeAddProductCommand);
            var validationResult = validation.IsValid;
            // Assert
            Assert.NotNull(validation);
            Assert.False(validationResult);
            Assert.NotEmpty(validation.Errors);
            Assert.Contains(validation.Errors, x => x.PropertyName == "Title");
            Assert.IsAssignableFrom<ErrorModel>(validation.Errors[0].CustomState);
            Assert.Contains(validation.Errors, x => ((ErrorModel)x.CustomState).Code == Errors.InvalidTitleValidationError.Code);
        }
        
        [Fact]
        public void AddProductCommandValidator_Returns_False_When_Title_Is_Too_Long()
        {
            // Arrange
            var fakeAddProductCommand = new AddProductCommand
            {
                Title = "qwertyuiop[asdfghjkl;zxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm",
                InventoryCount = 10,
                Price = 100,
                Discount = 10
            };
            
            var validator = new AddProductCommandValidator();
            
            // Act
            var validation = validator.Validate(fakeAddProductCommand);
            var validationResult = validation.IsValid;
            // Assert
            Assert.NotNull(validation);
            Assert.False(validationResult); 
            Assert.NotEmpty(validation.Errors);
            Assert.Contains(validation.Errors, x => x.PropertyName == "Title");
            Assert.IsAssignableFrom<ErrorModel>(validation.Errors[0].CustomState);
            Assert.Contains(validation.Errors, x => ((ErrorModel)x.CustomState).Code == Errors.InvalidTitleValidationError.Code);

        }
    
        [Fact]
        public void GetProductQueryHandler_Returns_Product_When_Is_Not_Chached()
        {
            // Arrange
            var fakeProduct = new Product
            {
                Id = 1,
                Title = "fake-title",
                InventoryCount = 10,
                Price = 100,
                Discount = 10
            };
            
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup(x => x.Products
                    .GetProductByIdAsync(
                        It.IsAny<int>()))
                .Returns(Task.FromResult(fakeProduct));
            
            var memoryCache = MockMemoryCacheService.GetMemoryCache_False(fakeProduct);
            
            
            // Act
            var getProductQueryHandler = new GetProductQueryHandler(mockUnitOfWork.Object, memoryCache);
            var result = getProductQueryHandler.Handle(new GetProductQuery()
            {
                ProductId = 1
            }, new CancellationToken()).GetAwaiter().GetResult();
            
            
            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<OperationResult>(result);
            Assert.IsAssignableFrom<ProductResponse>(result.Value);
            Assert.Equal(OperationResultStatus.Ok, result.Status);
            Assert.Equal(90, ((ProductResponse)result.Value).EndPrice);
        }
        
        [Fact]
        public void GetProductQueryHandler_Returns_Product_When_Is_Chached()
        {
            // Arrange
            var fakeProduct = new Product
            {
                Id = 1,
                Title = "fake-title",
                InventoryCount = 10,
                Price = 100,
                Discount = 10
            };
            
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup(x => x.Products
                    .GetProductByIdAsync(
                        It.IsAny<int>()))
                .Returns(Task.FromResult(fakeProduct));
            
            var memoryCache = MockMemoryCacheService.GetMemoryCache_True(fakeProduct);
            
            
            // Act
            var getProductQueryHandler = new GetProductQueryHandler(mockUnitOfWork.Object, memoryCache);
            var result = getProductQueryHandler.Handle(new GetProductQuery()
            {
                ProductId = 1
            }, new CancellationToken()).GetAwaiter().GetResult();
            
            
            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<OperationResult>(result);
            Assert.IsAssignableFrom<ProductResponse>(result.Value);
            Assert.Equal(OperationResultStatus.Ok, result.Status);
            Assert.Equal(90, ((ProductResponse)result.Value).EndPrice);
        }
        
}

public static class MockMemoryCacheService {
    public static IMemoryCache GetMemoryCache_False(object expectedValue) {
        var mockMemoryCache = new Mock<IMemoryCache>();
        mockMemoryCache
            .Setup(x => x.TryGetValue(It.IsAny<object>(), out expectedValue))
            .Returns(false);
        mockMemoryCache
            .Setup(x => x.CreateEntry(It.IsAny<object>()))
            .Returns(Mock.Of<ICacheEntry>);
        return mockMemoryCache.Object;
    }
    
    public static IMemoryCache GetMemoryCache_True(object expectedValue) {
        var mockMemoryCache = new Mock<IMemoryCache>();
        mockMemoryCache
            .Setup(x => x.TryGetValue(It.IsAny<object>(), out expectedValue))
            .Returns(true);
       
        return mockMemoryCache.Object;
    }
}