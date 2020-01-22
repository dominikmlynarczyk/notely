using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Notely.Domain.Notes;
using Notely.SharedKernel.Infrastructure.Repositories;

namespace Notely.Infrastructure.Notes
{
    public class NotesRepository : GenericEfRepository<Note, NoteEntity>, INotesRepository
    {
        public NotesRepository(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task SaveNoteFile(string filePath, string content)
        {
            if (File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }
            using (var sw = new StreamWriter(filePath))
            {
                await sw.WriteAsync(content);
            }
        }

        public async Task<string> GetNoteContent(string filePath)
        {

            using (var sw = new StreamReader(filePath))
            {
                return await sw.ReadToEndAsync();
            }
        }
    }
}