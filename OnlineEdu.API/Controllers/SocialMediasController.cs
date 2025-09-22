using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DTO.DTOs.SocialMediaDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController(IGenericService<SocialMedia> _socialMediaService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _socialMediaService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _socialMediaService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaDto socialMediaDto)
        {
            var newValue = _mapper.Map<SocialMedia>(socialMediaDto);
            await _socialMediaService.CreateAsync(newValue);
            return Ok("SocialMedia Created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _socialMediaService.DeleteAsync(id);
            return Ok("SocialMedia Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSocialMediaDto socialMediaDto)
        {
            var newValue = _mapper.Map<SocialMedia>(socialMediaDto);
            await _socialMediaService.UpdateAsync(newValue);
            return Ok("SocialMedia Updated");
        }
    }
}
