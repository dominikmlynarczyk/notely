using Notely.SharedKernel;

namespace Notely.Domain.Notes.DataStructures
{
    public class NoteDataStructure
    {
        public AggregateId Id { get; }
        public string Name { get; }
        public string ContentPath { get; }
        public AggregateId UserId { get; }

        public NoteDataStructure(AggregateId id, string name, string contentPath, AggregateId userId)
        {
            Id = id;
            Name = name;
            ContentPath = contentPath;
            UserId = userId;
        }
    }
}
