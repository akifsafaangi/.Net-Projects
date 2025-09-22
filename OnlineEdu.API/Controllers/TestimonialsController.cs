using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DTO.DTOs.TestimonialDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(IGenericService<Testimonial> _testimonialService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _testimonialService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _testimonialService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDto testimonialDto)
        {
            var newValue = _mapper.Map<Testimonial>(testimonialDto);
            await _testimonialService.CreateAsync(newValue);
            return Ok("Testimonial Created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _testimonialService.DeleteAsync(id);
            return Ok("Testimonial Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTestimonialDto testimonialDto)
        {
            var newValue = _mapper.Map<Testimonial>(testimonialDto);
            await _testimonialService.UpdateAsync(newValue);
            return Ok("Testimonial Updated");
        }
    }
}
