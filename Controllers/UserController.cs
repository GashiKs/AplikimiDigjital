﻿using AplikimiDigjital.Models;
using AplikimiDigjital.Services.Interfaces;
using AplikimiDigjital.Validators;
using Microsoft.AspNetCore.Mvc;

namespace AplikimiDigjital.Controllers
{
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService; 
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUser")]
        public List<User> GetAllUsers()
        {
            var result = _userService.GetAllUsers();
            return result;
        }

        [HttpGet("GetUserById/{id}")]
        public User GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(User user)
        {
            UserValidator validator = new UserValidator();
            var validationResult = validator.Validate(user);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdUser = _userService.CreateUser(user);
            return Ok(createdUser);
        }

        [HttpPut("UpdateUser/{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            var validator = new UserValidator();
            var validationResult = validator.Validate(user);

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
                var oldUser = _userService.GetUserById(id);
                if (oldUser == null)
                {
                    return NotFound();
                }
                _userService.UpdateUser(user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var deletedUser = _userService.GetUserById(id);
                if (deletedUser == null)
                {
                    return NotFound();
                }
                _userService.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }
    }
}
