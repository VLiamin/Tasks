using MassTransit;
using Models.Answers;
using System;
using System.Threading.Tasks;
using WebService1.Models;
using WebService2.DAL;
using WebService2.Mappers.Interfaces;

namespace WebService2.Consumer
{
    public class GetConsumer : IConsumer<GetQuestion>
    {
        private readonly IUserRepository userRepository;
        private readonly IGetAnswerMapper getAnswerMapper;

        public GetConsumer(IUserRepository userRepository, IGetAnswerMapper getAnswerMapper)
        {
            this.userRepository = userRepository;
            this.getAnswerMapper = getAnswerMapper;
        }

        public async Task Consume(ConsumeContext<GetQuestion> context)
        {
            User user = userRepository.GetUser(context.Message.Id);
            await context.RespondAsync<GetAnswer>(getAnswerMapper.Map(user));
        }
    }
}
