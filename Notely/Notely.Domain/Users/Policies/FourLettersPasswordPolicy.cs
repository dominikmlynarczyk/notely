using System.Text.RegularExpressions;

namespace Notely.Domain.Users.Policies
{
    public class FourLettersPasswordPolicy : IPasswordPolicy
    {
        private Regex Expression => new Regex("^.{4,}$");

        public bool IsPasswordValid(string password)
            => Expression.IsMatch(password);
    }
}