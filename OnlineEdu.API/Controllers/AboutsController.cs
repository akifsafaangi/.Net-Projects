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
        public IActionResult Get()
        {
            var values = _aboutService.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _aboutService.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create(CreateAboutDto aboutDto)
        {
            var newValue = _mapper.Map<About>(aboutDto);
            _aboutService.Create(newValue);
            return Ok("About Created");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //id check
            _aboutService.Delete(id);
            return Ok("About Deleted");
        }

        [HttpPut]
        public IActionResult Update(UpdateAboutDto aboutDto)
        {
            var newValue = _mapper.Map<About>(aboutDto);
            _aboutService.Update(newValue);
            return Ok("About Updated");
        }
    }
}
