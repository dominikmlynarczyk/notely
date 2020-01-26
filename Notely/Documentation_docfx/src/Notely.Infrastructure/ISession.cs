using System;

namespace Notely.Infrastructure
{
    public interface ISession
    {
        bool IsAuthenticated { get; }
        Guid? UserId { get; set; }
        string UserName { get; set; }
        string FullName { get; set; }
        event Action<bool> OnIsAuthenticatedChanged;
    }
}