using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Notely.Application.Notes.DTOs;
using Notely.Domain.Notes;
using Notely.Domain.Notes.DataStructures;
using Notely.SharedKernel;

namespace Notely.Application.Notes
{
    public interface INoteService : IService
    {
        Task AddNote(NoteDataStructure dataStructure, string content);
        Task<string> OpenNoteFile(string contentPath);
        Task<IEnumerable<NoteDto>> GetNotesForUser(string queryName);
        Task UpdateNote(NoteDataStructure dataStructure, string content);   
        Task DeleteNote(AggregateId id);   
    }
}
