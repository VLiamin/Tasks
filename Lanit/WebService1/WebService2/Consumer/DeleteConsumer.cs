using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Models;
using WebService2.DAL;

namespace WebService2.Consumer
{
    public class DeleteConsumer : IConsumer<DeleteQuestion>
    {
        private readonly IUserRepository userRepository;
        public DeleteConsumer(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task Consume(ConsumeContext<DeleteQuestion> context)
        {
            
            string result = userRepository.DeleteUser(context.Message.Id);
            DeleteAnswer deleteAnswer = new DeleteAnswer { Answer = result };
            await context.RespondAsync<DeleteAnswer>(deleteAnswer);
        }
    }
}
