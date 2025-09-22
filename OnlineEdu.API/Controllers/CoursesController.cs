using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(IGenericService<Course> _courseService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _courseService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _courseService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseDto CourseDto)
        {
            var newValue = _mapper.Map<Course>(CourseDto);
            await _courseService.CreateAsync(newValue);
            return Ok("Course Created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseService.DeleteAsync(id);
            return Ok("Course Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCourseDto courseDto)
        {
            var newValue = _mapper.Map<Course>(courseDto);
            await _courseService.UpdateAsync(newValue);
            return Ok("Course Updated");
        }
    }
}
