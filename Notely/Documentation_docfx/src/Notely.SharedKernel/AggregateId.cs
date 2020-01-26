using System;

namespace Notely.SharedKernel
{
    public struct AggregateId : IEquatable<AggregateId>
    {
        public AggregateId(Guid id)
        {
            Id = id;
        }

        public Guid Id;

        public bool Equals(AggregateId other)
        {
            return other.Id == Id;
        }
    }
}
