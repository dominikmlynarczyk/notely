using System;

namespace Notely.SharedKernel
{
    public abstract class AggregateRoot
    {
        public AggregateId Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime ModifiedDate { get; private set; }
        public bool IsArchived { get; private set; }

        protected AggregateRoot()
        {

        }
        protected AggregateRoot(AggregateId id)
        {
            Id = id;
            CreatedDate = DateTime.UtcNow;
            ModifiedDate = DateTime.UtcNow;
            IsArchived = false;
        }

        public virtual void Archive()
        {
            IsArchived = true;
        }
    }
}
