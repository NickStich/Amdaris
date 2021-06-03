using Domain.ThirdParty;
using Infrastructure.Services.ServiceAbstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("tpp/[action]")]
    public class ThirdPartyPersonController : ControllerBase
    {
        private readonly IThirdPartyPersonService _thirdPartyPersonService;

        public ThirdPartyPersonController(IThirdPartyPersonService thirdPartyPersonService)
        {
            _thirdPartyPersonService = thirdPartyPersonService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            try
            {
                var tppersons = _thirdPartyPersonService.GetThirdPartyPersons();
                return Ok(tppersons);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error accesing database");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var tpperson = _thirdPartyPersonService.GetThirdPartyPersonById(id);
                return Ok(tpperson);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Third Party Person with ID={id} not found!");
            }
        }

        [HttpPost]
        public IActionResult Create(ThirdPartyPerson tpperson)
        {
            try
            {
                if (tpperson == null)
                {
                    return BadRequest();
                }
                _thirdPartyPersonService.AddThirdPartyPerson(tpperson);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Third Party Person with ID={tpperson.Id} not added!");
            }
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            try
            {
                _thirdPartyPersonService.DeleteThirdPartyPerson(id);
                Ok();
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError,
                    $"Third Party Person with ID={id} not found!");
            }

        }

        [HttpPut("{id:int}")]
        public void Update(int id, ThirdPartyPerson tpperson)
        {
            try
            {
                _thirdPartyPersonService.UpdateThirdPartyPerson(id,tpperson);
                Ok();
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError,
                    $"Third Party Person with ID={id} not found!");
            }
        }

        [HttpGet]
        public IActionResult GetType()
        {
            try
            {
                var tppType = _thirdPartyPersonService.GetPersonsType();
                return Ok(tppType);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error accesing database");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                var tppByName = _thirdPartyPersonService.FindPersonByName(name);
                return Ok(tppByName);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error accesing database");
            }
        }

        [HttpGet("{type:int}")]
        public IActionResult GetByType(int type)
        {
            try
            {
                var tpperson = _thirdPartyPersonService.GetThirdPartyPersonsByType((ThirdPartyType)type);
                return Ok(tpperson);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Third Party Person with ID={type} not found!");
            }
        }
    }
}
