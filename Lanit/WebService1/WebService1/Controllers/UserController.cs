using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Models;

namespace WebService1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet("getUser")]
        public User GetUser([FromQuery] int Id, 
            [FromServices] IRequestClient<Question> requestClient)
        {
            _logger.LogInformation("get user '{id}'", Id);
            Response<User> response = requestClient.GetResponse<User>(
                new Question { Id = 1 }).Result;
            return response.Message;
        }
    }


}
