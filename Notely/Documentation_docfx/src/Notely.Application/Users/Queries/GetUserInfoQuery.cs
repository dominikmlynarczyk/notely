using System;
using Notely.SharedKernel;
using Notely.SharedKernel.Application;

namespace Notely.Application.Users.Queries
{
    public class GetUserInfoQuery : IQuery
    {
        public GetUserInfoQuery(Guid userId)
        {
            UserId = new AggregateId(userId);
        }

        public AggregateId UserId { get; }
    }
}
