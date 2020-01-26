using Notely.Domain.Notes.DataStructures;

namespace Notely.Domain.Notes.Factories
{
    public class NoteDomainFactory : INoteDomainFactory
    {
        public Note Create(NoteDataStructure dataStructure) 
            => new Note(dataStructure.Id, dataStructure.Name, dataStructure.ContentPath, dataStructure.UserId);
    }
}