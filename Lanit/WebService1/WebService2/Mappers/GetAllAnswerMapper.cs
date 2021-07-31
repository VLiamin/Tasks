using Models.Answers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService1.Models;
using WebService2.Mappers.Interfaces;

namespace WebService2.Mappers
{
    public class GetAllAnswerMapper : IGetAllAnswerMapper
    {
        public GetAllAnswer Map(List<User> users)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (User user in users)
            {
                stringBuilder.Append("Id  = " + user.Id + " Name = " + user.Name + " ");
            }

            return new GetAllAnswer { Result = stringBuilder.ToString() };
        }
    }
}
