using System;

namespace Notely.SharedKernel
{
    public struct AggregateId : IEquatable<AggregateId>
    {
        public Guid Id { get; private set; }

        public AggregateId(Guid id)
        {
            Id = id;
        }

        public bool Equals(AggregateId other)
        {
            return other.Id == Id;
        }
    }
}
