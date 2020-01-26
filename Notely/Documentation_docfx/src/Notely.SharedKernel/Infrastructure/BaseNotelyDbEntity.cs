using System;

namespace Notely.SharedKernel.Infrastructure
{
    public class BaseNotelyDbEntity : BaseDbEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsArchived { get; set; }
    }
}