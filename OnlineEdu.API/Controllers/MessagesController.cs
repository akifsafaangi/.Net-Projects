using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DTO.DTOs.MessageDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(IGenericService<Message> _messageService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _messageService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _messageService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMessageDto messageDto)
        {
            var newValue = _mapper.Map<Message>(messageDto);
            await _messageService.CreateAsync(newValue);
            return Ok("Message Created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _messageService.DeleteAsync(id);
            return Ok("Message Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMessageDto messageDto)
        {
            var newValue = _mapper.Map<Message>(messageDto);
            await _messageService.UpdateAsync(newValue);
            return Ok("Message Updated");
        }
    }
}
