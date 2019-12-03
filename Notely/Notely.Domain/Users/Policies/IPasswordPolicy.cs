namespace Notely.Domain.Users.Policies
{
    public interface IPasswordPolicy
    {
        bool IsPasswordValid(string password);
    }
}