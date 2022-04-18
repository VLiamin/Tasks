using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Models;
using WebService2.Mappers.Interfaces;

namespace WebService2.Mappers
{
    public class AddAnswerMapper : IAddAnswerMapper
    {
        public AddAnswer Map(string result)
        {
            AddAnswer addAnswer = new AddAnswer { Result = result };

            return addAnswer;
        }
    }
}
