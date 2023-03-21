using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MileStone4_CRUD_Using_MongoDb.Commands;
using MileStone4_CRUD_Using_MongoDb.Controllers;
using MileStone4_CRUD_Using_MongoDb.Models;
using MileStone4_CRUD_Using_MongoDb.Query;
using Moq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Products_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IMediator> _mediatorMock;
        private ProductController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new ProductController(_mediatorMock.Object);
        }

        [TestMethod]
        public async Task GetAllProducts_ShouldReturnOkWithProductsList()
        {
            // Arrange
            var products = new List<Product>
        {
            new Product { Id = "", productName = "Product 1", productCategory = "Electronics", productQuantity = 10, productCost = 10 },
            new Product { Id = "", productName = "Product 2", productCategory = "Fashion", productQuantity = 5, productCost = 20 }
        };
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetAllProductsQuery>(), default)).ReturnsAsync(products);

            // Act
            var result = await _controller.GetAllProducts();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            var resultValue = okResult.Value as List<Product>;
            Assert.IsNotNull(resultValue);
            CollectionAssert.AreEqual(products, resultValue);
        }

        [TestMethod]
        public async Task AddNewProduct_ShouldReturnStatusCode201()
        {
            // Arrange
            var product = new Product { Id = "", productName = "Product 1", productCategory = "Description 1", productQuantity = 10, productCost = 10 };

            // Act
            var result = await _controller.CreateProduct(product);

            // Assert
            var statusCodeResult = result as StatusCodeResult;
            Assert.IsNotNull(statusCodeResult);
            Assert.AreEqual(201, statusCodeResult.StatusCode);
            _mediatorMock.Verify(x => x.Send(It.IsAny<AddProductCommand>(), default), Times.Once);
        }
    }

    
}