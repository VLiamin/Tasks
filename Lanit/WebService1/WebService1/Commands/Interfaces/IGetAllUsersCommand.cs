using Models.Answers;

namespace WebService1.Commands.Interfaces
{
    public interface IGetAllUsersCommand
    {
        GetAllAnswer Execute();
    }
}
