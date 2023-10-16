using AplikimiDigjital.Models;
using AplikimiDigjital.Services.Interfaces;
using AplikimiDigjital.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AplikimiDigjital.Controllers
{
    [Route("api/[controller]")]
    public class AplikimiController:ControllerBase
    {
        private readonly IAplikimiService _aplikimiService;

        public AplikimiController(IAplikimiService aplikimiService)
        {
            _aplikimiService = aplikimiService;
        }

        [HttpGet("GetAllAplikimet")]
        public List<Aplikimi> GetAllAplikimet()
        {
            var result = _aplikimiService.GetAllAplikim();
            return result;
        }

        [HttpGet("GetAplikimiById/{id}")]
        public Aplikimi GetAplikimiById(int id)
        {
            var aplikimi = _aplikimiService.GetAplikimiById(id);
            return aplikimi;
        }

        [HttpPost("CreateAplikimi")]
        public IActionResult CreateAplikimi(Aplikimi aplikimi)
        {
            var validator = new AplikimiValidator();
            var validationResult = validator.Validate(aplikimi);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdAplikimi = _aplikimiService.CreateAplikimi(aplikimi);
            return Ok(createdAplikimi);
        }

        [HttpPut("UpdateAplikimi/{id}")]
        public IActionResult UpdateAplikimi(int id, Aplikimi aplikimi)
        {
            var validator = new AplikimiValidator();
            var validationResult = validator.Validate(aplikimi);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            try
            {
                var oldAplikimi = _aplikimiService.GetAplikimiById(id);
                if (oldAplikimi == null)
                {
                    return NotFound();
                }
                _aplikimiService.UpdateAplikimi(aplikimi);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }
        }

        [HttpDelete("DeleteAplikimi/{id}")]
        public IActionResult DeleteAplikimi(int id)
        {
            try
            {
                var deletedAplikimi = _aplikimiService.GetAplikimiById(id);
                if (deletedAplikimi == null)
                {
                    return NotFound();
                }
                _aplikimiService.DeleteAplikim(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }
    }
}
