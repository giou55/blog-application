﻿using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("This is a get request");
        }
    }
}
