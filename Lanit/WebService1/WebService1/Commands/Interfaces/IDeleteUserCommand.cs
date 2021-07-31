using WebService1.Models;

namespace WebService1.Commands.Interfaces
{
    public interface IDeleteUserCommand
    {
        DeleteAnswer Execute(int Id);
    }
}
