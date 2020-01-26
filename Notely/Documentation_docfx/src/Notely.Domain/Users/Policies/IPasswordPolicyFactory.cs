namespace Notely.Domain.Users.Policies
{
    public interface IPasswordPolicyFactory : IDomainFactory
    {
        IPasswordPolicy Create<TPolicy>() where TPolicy : IPasswordPolicy;
    }
}
