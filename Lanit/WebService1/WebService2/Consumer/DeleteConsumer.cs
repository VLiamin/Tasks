using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Models;
using WebService2.DAL;
using WebService2.Mappers.Interfaces;

namespace WebService2.Consumer
{
    public class DeleteConsumer : IConsumer<DeleteQuestion>
    {
        private readonly IUserRepository userRepository;
        private readonly IDeleteAnswerMapper deleteAnswerMapper;

        public DeleteConsumer(IUserRepository userRepository, IDeleteAnswerMapper deleteAnswerMapper)
        {
            this.userRepository = userRepository;
            this.deleteAnswerMapper = deleteAnswerMapper;
        }
        public async Task Consume(ConsumeContext<DeleteQuestion> context)
        {
            
            string result = userRepository.DeleteUser(context.Message.Id);
            
            await context.RespondAsync<DeleteAnswer>(deleteAnswerMapper.Map(result));
        }
    }
}
