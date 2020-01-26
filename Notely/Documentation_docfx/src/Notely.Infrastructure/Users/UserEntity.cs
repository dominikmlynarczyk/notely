using Notely.SharedKernel.Infrastructure;

namespace Notely.Infrastructure.Users
{
    public class UserEntity : BaseNotelyDbEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
