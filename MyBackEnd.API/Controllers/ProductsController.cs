using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBackEnd.Bussiness.Abstract;
using MyBackEnd.Entities.Concrete;

namespace MyBackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _productService.GetList();
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetListByCategory(categoryId);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [HttpGet("get")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddProduct(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
                return Ok(result.Message);
            else
                return BadRequest(result.Message);
        }

        [HttpPost("transaction")]
        public IActionResult TransactionProduct(Product product)
        {
            var result = _productService.TransactionalOperation(product);
            if (result.Success)
                return Ok(result.Message);
            else
                return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult UpdateProduct(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
                return Ok(result.Message);
            else
                return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult DeleteProduct(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
                return Ok(result.Message);
            else
                return BadRequest(result.Message);
        }

    }
}