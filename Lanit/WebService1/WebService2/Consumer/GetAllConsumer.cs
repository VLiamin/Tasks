using MassTransit;
using Models.Answers;
using Models.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Models;
using WebService2.DAL;
using WebService2.Mappers.Interfaces;

namespace WebService2.Consumer
{
    public class GetAllConsumer : IConsumer<GetAllQuestion>
    {
        private readonly IUserRepository userRepository;
        private readonly IGetAllAnswerMapper getAllAnswerMapper;

        public GetAllConsumer(IUserRepository userRepository, IGetAllAnswerMapper getAllAnswerMapper)
        {
            this.userRepository = userRepository;
            this.getAllAnswerMapper = getAllAnswerMapper;
        }

        public async Task Consume(ConsumeContext<GetAllQuestion> context)
        {
            List<User> users = userRepository.GetAllUsers();
            await context.RespondAsync<GetAllAnswer>(getAllAnswerMapper.Map(users));
        }
    }
}
