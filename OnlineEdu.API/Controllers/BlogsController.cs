using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DTO.DTOs.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IGenericService<Blog> _blogService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _blogService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _blogService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogDto BlogDto)
        {
            var newValue = _mapper.Map<Blog>(BlogDto);
            await _blogService.CreateAsync(newValue);
            return Ok("Blog Created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.DeleteAsync(id);
            return Ok("Blog Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogDto blogDto)
        {
            var newValue = _mapper.Map<Blog>(blogDto);
            await _blogService.UpdateAsync(newValue);
            return Ok("Blog Updated");
        }
    }
}
