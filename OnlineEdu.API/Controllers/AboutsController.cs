using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IGenericService<About> _aboutService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _aboutService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _aboutService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto aboutDto)
        {
            var newValue = _mapper.Map<About>(aboutDto);
            await _aboutService.CreateAsync(newValue);
            return Ok("About Created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _aboutService.DeleteAsync(id);
            return Ok("About Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutDto aboutDto)
        {
            var newValue = _mapper.Map<About>(aboutDto);
            await _aboutService.UpdateAsync(newValue);
            return Ok("About Updated");
        }
    }
}
