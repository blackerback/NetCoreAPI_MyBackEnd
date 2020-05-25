using Microsoft.AspNetCore.Mvc;
using Moq;
using MyBackEnd.API.Controllers;
using MyBackEnd.Bussiness.Abstract;
using MyBackEnd.Core.Utilities.Results;
using MyBackEnd.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace MyBackEnd.API_Test
{
    public class ProductControllerApiTest
    {
        private readonly Mock<IProductService> _mockRep;
        private readonly ProductsController _productsController;
        private List<Product> _products;

        public ProductControllerApiTest()
        {
            _mockRep = new Mock<IProductService>();
            _productsController = new ProductsController(_mockRep.Object);
            _products = new List<Product>()
            {
                new Product{CategoryId=1,ProductId=1,ProductName="Test Product",QuantityPerUnit="One Box",UnitPrice=10000,UnitsInStock=20}
            };
        }

        [Fact]
        public void GetList_ActionExecute_ReturnOkResultWithProduct()
        {
            _mockRep.Setup(x => x.GetList()).Returns(new SuccessDataResult<List<Product>>(_products, ""));

            var result = _productsController.GetList();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnProduct = Assert.IsAssignableFrom<List<Product>>(okResult.Value);

            Assert.Equal<int>(1, returnProduct.ToList().Count);
        }

        [Fact]
        public void GetList_ActionExecute_ReturnBadResult()
        {
            _mockRep.Setup(x => x.GetList()).Returns(new ErrorDataResult<List<Product>>(_products, ""));

            var result = _productsController.GetList();
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnProduct = Assert.IsAssignableFrom<string>(badResult.Value);
        }

        [Theory]
        [InlineData(1)]
        public void GetById_IdIsValid_ReturnOkResult(int productId)
        {
            _mockRep.Setup(x => x.GetById(productId)).Returns(new SuccessDataResult<Product>(_products.First(), ""));

            var result = _productsController.GetById(1);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnProduct = Assert.IsAssignableFrom<Product>(okResult.Value);
            Assert.Equal(productId, _products.FirstOrDefault(i => i.ProductId == productId).ProductId);
        }

        [Theory]
        [InlineData(0)]
        public void GetById_IdIsInvalid_ReturnBadResult(int id)
        {
            _mockRep.Setup(x => x.GetById(id)).Returns(new ErrorDataResult<Product>(null, ""));

            var result = _productsController.GetById(id);
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnProduct = Assert.IsAssignableFrom<string>(badResult.Value);
        }

        [Fact]
        public void UpdateProduct_EntityIsNull_ReturnBadResult()
        {
            _mockRep.Setup(x => x.Update(null)).Returns(new ErrorResult(""));
            var result = _productsController.UpdateProduct(null);
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnProduct = Assert.IsAssignableFrom<string>(badResult.Value);
        }

        [Fact]
        public void UpdateProduct_UpdateSucess_ReturnOkResult()
        {
            _mockRep.Setup(x => x.Update(_products.FirstOrDefault())).Returns(new SuccessResult(""));
            var result = _productsController.UpdateProduct(_products.FirstOrDefault());
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnProduct = Assert.IsAssignableFrom<string>(okResult.Value);
        }

        [Fact]
        public void AddProduct_EntityIsNull_ReturnBadResult()
        {
            _mockRep.Setup(x => x.Add(null)).Returns(new ErrorResult(""));
            var result = _productsController.AddProduct(null);
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnProduct = Assert.IsAssignableFrom<string>(badResult.Value);
        }

        [Fact]
        public void AddProduct_AddSucess_ReturnOkResult()
        {
            _mockRep.Setup(x => x.Add(_products.FirstOrDefault())).Returns(new SuccessResult(""));

            var result = _productsController.AddProduct(_products.FirstOrDefault());
            _mockRep.Verify(x => x.Add(_products.FirstOrDefault()), Times.Once);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnProduct = Assert.IsAssignableFrom<string>(okResult.Value);
        }

        [Fact]
        public void DeleteProduct_DeleteSucess_ReturnOkResult()
        {
            _mockRep.Setup(x => x.Delete(_products.FirstOrDefault())).Returns(new SuccessResult(""));

            var result = _productsController.DeleteProduct(_products.FirstOrDefault());
            _mockRep.Verify(x => x.Delete(_products.FirstOrDefault()), Times.Once);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnProduct = Assert.IsAssignableFrom<string>(okResult.Value);
        }

        [Fact]
        public void DeleteProduct_DeleteError_ReturnBadResult()
        {
            _mockRep.Setup(x => x.Delete(null)).Returns(new ErrorResult(""));

            var result = _productsController.DeleteProduct(null);
            _mockRep.Verify(x => x.Delete(_products.FirstOrDefault()), Times.Never);
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnProduct = Assert.IsAssignableFrom<string>(badResult.Value);
        }

    }
}
