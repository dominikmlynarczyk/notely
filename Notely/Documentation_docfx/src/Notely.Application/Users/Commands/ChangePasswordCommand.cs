using Notely.SharedKernel;
using Notely.SharedKernel.Application;

namespace Notely.Application.Users.Commands
{
    public class ChangePasswordCommand : ICommand
    {
        public AggregateId UserId { get; }
        public string OldPassword { get; }
        public string NewPassword { get; }
        public string ConfirmPassword { get; }

        public ChangePasswordCommand(AggregateId userId, string oldPassword, string newPassword, string confirmPassword)
        {
            UserId = userId;
            OldPassword = oldPassword;
            NewPassword = newPassword;
            ConfirmPassword = confirmPassword;
        }
    }
}
