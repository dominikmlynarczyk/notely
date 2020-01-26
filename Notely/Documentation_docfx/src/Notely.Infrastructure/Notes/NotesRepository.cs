using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            using (var sw = new StreamWriter(filePath))
            {
                await sw.WriteAsync(content);
            }
        }

        public async Task<string> GetNoteContent(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }
            using (var sw = new StreamReader(filePath))
            {
                return await sw.ReadToEndAsync();
            }
        }

        public async Task<IEnumerable<Note>> GetNotesForUser(Guid sessionUserId, string queryName)
        {
            var elements = string.IsNullOrWhiteSpace(queryName)
                ? await Set.Where(x => x.UserId == sessionUserId && !x.IsArchived).ToListAsync()
                : await Set.Where(x => x.Name.Contains(queryName) && x.UserId == sessionUserId && !x.IsArchived).ToListAsync();
            return Mapper.Map<IEnumerable<Note>>(elements);
        }

        public void DeleteNoteFile(string filePath)
        {
            File.Delete(filePath);
        }
    }
}