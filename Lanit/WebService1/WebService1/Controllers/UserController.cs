using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Answers;
using Models.Questions;
using WebService1.Commands.Interfaces;
using WebService1.Models;

namespace WebService1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IGetUserCommand getUserCommand;
        private readonly IDeleteUserCommand deleteUserCommand;
        private readonly IAddUserCommand addUserCommand;
        private readonly IGetAllUsersCommand getAllUsersCommand;

        public UserController(ILogger<UserController> logger, IGetUserCommand getUserCommand,
            IDeleteUserCommand deleteUserCommand, IAddUserCommand addUserCommand,
            IGetAllUsersCommand getAllUsersCommand)
        {
            _logger = logger;
            this.getUserCommand = getUserCommand;
            this.deleteUserCommand = deleteUserCommand;
            this.addUserCommand = addUserCommand;
            this.getAllUsersCommand = getAllUsersCommand;
        }

        [HttpGet("getUser")]
        public GetAnswer GetUser([FromQuery] int Id)
        {
            _logger.LogInformation("get user '{id}'", Id);

            return getUserCommand.Execute(Id);
        }

        [HttpDelete("deleteUser")]
        public DeleteAnswer DeleteUser([FromQuery] int Id,
            [FromServices] IRequestClient<DeleteQuestion> requestClient)
        {
            _logger.LogInformation("delete user '{id}'", Id);
            
            return deleteUserCommand.Execute(Id);
        }

        [HttpPost("addUser")]
        public AddAnswer AddUser([FromBody] AddQuestion addQuestion,
            [FromServices] IRequestClient<AddQuestion> requestClient)
        {
            _logger.LogInformation("get user '{user}'", addQuestion);
            
            return addUserCommand.Execute(addQuestion);
        }

        [HttpGet("getAllUsers")]
        public GetAllAnswer GetAllUsers([FromServices] IRequestClient<GetAllQuestion> requestClient)
        {
            _logger.LogInformation("get user '{id}'");
            
            return getAllUsersCommand.Execute();
        }
    }
}
