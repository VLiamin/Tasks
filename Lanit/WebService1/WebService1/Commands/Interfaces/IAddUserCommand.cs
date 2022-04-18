using WebService1.Models;

namespace WebService1.Commands.Interfaces
{
    public interface IAddUserCommand
    {
        AddAnswer Execute(AddQuestion addQuestion);
    }
}
