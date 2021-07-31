using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Models.Answers;
using WebService1.Commands.Interfaces;
using WebService1.Models;

namespace WebService1
{
    public class GetUserCommand : IGetUserCommand
    {
        private readonly IRequestClient<GetQuestion> requestClient;

        public GetUserCommand([FromServices] IRequestClient<GetQuestion> requestClient)
        {
            this.requestClient = requestClient;
        }
        public GetAnswer Execute(int Id)
        {            
            Response<GetAnswer> response = requestClient.GetResponse<GetAnswer>(
                new GetQuestion { Id = Id }).Result;

            return response.Message;
        }
    }
}
