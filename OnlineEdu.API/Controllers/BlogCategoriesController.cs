using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DTO.DTOs.BlogCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoriesController(IGenericService<BlogCategory> _blogCategoryService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _blogCategoryService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _blogCategoryService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCategoryDto BlogDto)
        {
            var newValue = _mapper.Map<BlogCategory>(BlogDto);
            await _blogCategoryService.CreateAsync(newValue);
            return Ok("Blog Category Created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogCategoryService.DeleteAsync(id);
            return Ok("Blog Category Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogCategoryDto blogDto)
        {
            var newValue = _mapper.Map<BlogCategory>(blogDto);
            await _blogCategoryService.UpdateAsync(newValue);
            return Ok("Blog Category Updated");
        }
    }
}
