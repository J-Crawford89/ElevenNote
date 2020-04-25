using ElevenNote.Data;
using ElevenNote.Models.Categories;
using ElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        private CategoryService _categoryService;
        [HttpPost]
        public IHttpActionResult Create([FromBody] CategoryCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _categoryService = new CategoryService();
            _categoryService.CreateCategory(model);
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult List()
        {
            _categoryService = new CategoryService();
            return Ok(_categoryService.GetCategories());
        }
        public IHttpActionResult Get(int id)
        {
            _categoryService = new CategoryService();
            var categoryToGet = _categoryService.GetCategoryById(id);
            return Ok(categoryToGet);
        }
        [HttpPut]
        public IHttpActionResult Put(CategoryEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _categoryService = new CategoryService();
            _categoryService.UpdateCategory(model);
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(CategoryDelete model)
        {
            _categoryService = new CategoryService();
            _categoryService.DeleteCategory(model);
            return Ok();
        }
    }
}
