using MassTransit;
using Microsoft.AspNetCore.Mvc;
using WebService1.Commands.Interfaces;
using WebService1.Models;

namespace WebService1.Commands
{
    public class AddUserCommand : IAddUserCommand
    {
        private readonly IRequestClient<AddQuestion> requestClient;

        public AddUserCommand([FromServices] IRequestClient<AddQuestion> requestClient)
        {
            this.requestClient = requestClient;
        }

        public AddAnswer Execute(AddQuestion addQuestion)
        {
            Response<AddAnswer> response = requestClient.GetResponse<AddAnswer>(
                   new AddQuestion { Name = addQuestion.Name }).Result;

            return response.Message;
        }
    }
}
