using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Models;

namespace WebService2.Mappers.Interfaces
{
    public interface IDeleteAnswerMapper
    {
        DeleteAnswer Map(string result);
    }
}
