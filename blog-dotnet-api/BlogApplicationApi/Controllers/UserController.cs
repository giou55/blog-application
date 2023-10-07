﻿using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Types.Models.User;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/users")]
        public async Task<ActionResult<User[]>> Get()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }
    }
}
