using Models.Answers;

namespace WebService1.Commands.Interfaces
{
    public interface IGetUserCommand
    {
        GetAnswer Execute(int Id);
    }
}
