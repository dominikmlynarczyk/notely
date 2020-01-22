using Notely.Domain.Notes.DataStructures;

namespace Notely.Domain.Notes.Factories
{
    public interface INoteDomainFactory : IDomainFactory
    {
        Note Create(NoteDataStructure dataStructure);
    }
}
