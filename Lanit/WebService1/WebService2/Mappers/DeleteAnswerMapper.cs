using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Models;
using WebService2.Mappers.Interfaces;

namespace WebService2.Mappers
{
    public class DeleteAnswerMapper : IDeleteAnswerMapper
    {
        public DeleteAnswer Map(string result)
        {
            DeleteAnswer deleteAnswer = new DeleteAnswer { Answer = result };

            return deleteAnswer;
        }
    }
}
