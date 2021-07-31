using MassTransit;
using Microsoft.AspNetCore.Mvc;
using WebService1.Commands.Interfaces;
using WebService1.Models;

namespace WebService1.Commands
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IRequestClient<DeleteQuestion> requestClient;

        public DeleteUserCommand([FromServices] IRequestClient<DeleteQuestion> requestClient)
        {
            this.requestClient = requestClient;
        }

        public DeleteAnswer Execute(int Id)
        {
            Response<DeleteAnswer> response = requestClient.GetResponse<DeleteAnswer>(
                new DeleteQuestion { Id = Id }).Result;
            return response.Message;
        }
    }
}
