using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.BannerDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IGenericService<Banner> _bannerService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _bannerService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _bannerService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerDto bannerDto)
        {
            var newValue = _mapper.Map<Banner>(bannerDto);
            await _bannerService.CreateAsync(newValue);
            return Ok("Banner Created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bannerService.DeleteAsync(id);
            return Ok("Banner Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBannerDto bannerDto)
        {
            var newValue = _mapper.Map<Banner>(bannerDto);
            await _bannerService.UpdateAsync(newValue);
            return Ok("Banner Updated");
        }
    }
}
