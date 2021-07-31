using MassTransit;
using System.Threading.Tasks;
using WebService1.Models;
using WebService2.DAL;
using WebService2.Mappers.Interfaces;

namespace WebService2.Consumer
{
    public class AddConsumer : IConsumer<AddQuestion>
    {
        private readonly IUserRepository userRepository;
        private readonly IAddAnswerMapper addAnswerMapper;

        public AddConsumer(IUserRepository userRepository, IAddAnswerMapper addAnswerMapper)
        {
            this.userRepository = userRepository;
            this.addAnswerMapper = addAnswerMapper;
        }

        public async Task Consume(ConsumeContext<AddQuestion> context)
        {
            User user = new User { Name = context.Message.Name };
            
            await context.RespondAsync<AddAnswer>(addAnswerMapper.Map(userRepository.AddUser(user)));
        }
    }
}
