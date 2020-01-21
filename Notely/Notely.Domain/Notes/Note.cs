using Notely.SharedKernel;

namespace Notely.Domain.Notes
{
    public class Note : AggregateRoot
    {
        public string Name { get; private set; }
        public string Content { get; private set; }
        public string ContentPath { get; private set; }

    }
}
