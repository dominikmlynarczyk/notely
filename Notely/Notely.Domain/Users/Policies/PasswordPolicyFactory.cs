using System;

namespace Notely.Domain.Users.Policies
{
    public class PasswordPolicyFactory : IPasswordPolicyFactory
    {
        public IPasswordPolicy Create<TPolicy>() where TPolicy : IPasswordPolicy
        {
            var policy = (TPolicy) Activator.CreateInstance<TPolicy>();
            return policy;
        }
    }
}