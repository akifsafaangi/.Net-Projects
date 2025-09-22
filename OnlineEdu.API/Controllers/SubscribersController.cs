using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DTO.DTOs.SubscriberDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController(IGenericService<Subscriber> _subscriberService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _subscriberService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _subscriberService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubscriberDto subscriberDto)
        {
            var newValue = _mapper.Map<Subscriber>(subscriberDto);
            await _subscriberService.CreateAsync(newValue);
            return Ok("Subscriber Created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _subscriberService.DeleteAsync(id);
            return Ok("Subscriber Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSubscriberDto subscriberDto)
        {
            var newValue = _mapper.Map<Subscriber>(subscriberDto);
            await _subscriberService.UpdateAsync(newValue);
            return Ok("Subscriber Updated");
        }
    }
}
