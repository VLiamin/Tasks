using MassTransit;
using System;
using System.Threading.Tasks;
using WebService1.Models;
using WebService2.DAL;

namespace WebService2.Consumer
{
    public class GetConsumer : IConsumer<Question>
    {
        private readonly IUserRepository userRepository;
        public GetConsumer(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task Consume(ConsumeContext<Question> context)
        {
            User user = userRepository.GetUser(context.Message.Id);
            await context.RespondAsync<User>(user);
        }
    }
}
