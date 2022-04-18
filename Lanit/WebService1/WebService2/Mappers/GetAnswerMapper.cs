using Models.Answers;
using WebService1.Models;
using WebService2.Mappers.Interfaces;

namespace WebService2.Mappers
{
    public class GetAnswerMapper : IGetAnswerMapper
    {
        public GetAnswer Map(User user)
        {
            string result = "Id = " + user.Id + " Name = " + user.Name;
            return new GetAnswer { Result = result };
        }
    }
}
