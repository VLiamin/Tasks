using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Models.Answers;
using Models.Questions;
using WebService1.Commands.Interfaces;

namespace WebService1.Commands
{
    public class GetAllUsersCommand : IGetAllUsersCommand
    {
        private readonly IRequestClient<GetAllQuestion> requestClient;

        public GetAllUsersCommand([FromServices] IRequestClient<GetAllQuestion> requestClient)
        {
            this.requestClient = requestClient;
        }

        public GetAllAnswer Execute()
        {
            Response<GetAllAnswer> response = requestClient.GetResponse<GetAllAnswer>(
                new GetAllQuestion()).Result;

            return response.Message;
        }
    }
}
