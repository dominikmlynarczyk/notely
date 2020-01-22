using System.Threading.Tasks;
using Notely.Domain.Notes;
using Notely.SharedKernel.Infrastructure.Repositories;

namespace Notely.Infrastructure.Notes
{
    public interface INotesRepository : IGenericRepository<Note, NoteEntity>, IRepository
    {
        Task SaveNoteFile(string filePath, string content);
        Task<string> GetNoteContent(string filePath);
    }
}
