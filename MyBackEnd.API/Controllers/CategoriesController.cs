using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBackEnd.Bussiness.Abstract;
using MyBackEnd.Entities.Concrete;

namespace MyBackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _categoryService.GetList();
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [HttpGet("get")]
        public IActionResult GetById(int categoryId)
        {
            var result = _categoryService.GetById(categoryId);
            if (result.Success)
                return Ok(result.Data);
            else
                return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult AddProduct(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.Success)
                return Ok(result.Message);
            else
                return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult UpdateProduct(Category category)
        {
            var result = _categoryService.Update(category);
            if (result.Success)
                return Ok(result.Message);
            else
                return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult DeleteProduct(Category category)
        {
            var result = _categoryService.Delete(category);
            if (result.Success)
                return Ok(result.Message);
            else
                return BadRequest(result.Message);
        }
    }
}