using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Models;

namespace WebService2.Consumer
{
    public class GetConsumer : IConsumer<Question>
    {
        public async Task Consume(ConsumeContext<Question> context)
        {
            await context.RespondAsync<User>(new User { Id = 1, Name = "Vova"});
        }
    }
}
