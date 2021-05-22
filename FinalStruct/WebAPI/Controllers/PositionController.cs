using Domain;
using Infrastructure.Abstractions.ServiceAbstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("pos/[action]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var positions = _positionService.GetAllPositions();
                return Ok(positions);
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
                var position = _positionService.GetPositionById(id);
                return Ok(position);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Product with ID={id} not found!");
            }
        }

        [HttpPost]
        public IActionResult Create(Position position)
        {
            try
            {
                if (position == null)
                {
                    return BadRequest();
                }
                _positionService.CreatePosition(position);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Position with ID={position.Id} not added!");
            }
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            try
            {
                _positionService.DeletePosition(id);
                Ok();
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError,
                    $"Position with ID={id} not found!");
            }

        }

        [HttpPut("{id:int}")]
        public void Update(int id, Position position)
        {
            try
            {
                _positionService.UpdatePosition(id, position);
                Ok();
            }
            catch (Exception)
            {
                StatusCode(StatusCodes.Status500InternalServerError,
                    $"Position with ID={id} not found!");
            }
        }
    }
}
