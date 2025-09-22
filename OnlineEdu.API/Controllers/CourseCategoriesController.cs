using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DTO.DTOs.CourseCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoriesController(IGenericService<CourseCategory> _courseCategoryService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _courseCategoryService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _courseCategoryService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseCategoryDto CourseDto)
        {
            var newValue = _mapper.Map<CourseCategory>(CourseDto);
            await _courseCategoryService.CreateAsync(newValue);
            return Ok("Course Category Created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseCategoryService.DeleteAsync(id);
            return Ok("Course Category Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCourseCategoryDto courseDto)
        {
            var newValue = _mapper.Map<CourseCategory>(courseDto);
            await _courseCategoryService.UpdateAsync(newValue);
            return Ok("Course Category Updated");
        }
    }
}
