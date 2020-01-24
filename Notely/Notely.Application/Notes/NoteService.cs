using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Notely.Application.Notes.DTOs;
using Notely.Domain.Notes;
using Notely.Domain.Notes.DataStructures;
using Notely.Domain.Notes.Factories;
using Notely.Infrastructure;
using Notely.Infrastructure.Notes;
using Notely.SharedKernel;
using Notely.SharedKernel.Exceptions;

namespace Notely.Application.Notes
{
    public class NoteService : INoteService
    {
        private readonly ISession _session;
        private readonly INotesRepository _notesRepository;
        private readonly INoteDomainFactory _noteDomainFactory;

        public NoteService(INotesRepository notesRepository, INoteDomainFactory noteDomainFactory, ISession session)
        {
            _notesRepository = notesRepository;
            _noteDomainFactory = noteDomainFactory;
            _session = session;
        }

        public async Task AddNote(NoteDataStructure dataStructure, string content)
        {
            var note = await _notesRepository.Get(x => x.Id == dataStructure.Id.Id);
            if (note != null)
            {
                throw new BusinessLogicException("Note already exists");
            }

            note = _noteDomainFactory.Create(dataStructure);
            await _notesRepository.Add(note);
            await _notesRepository.SaveNoteFile(dataStructure.ContentPath, content);
        }

        public async Task<string> OpenNoteFile(string contentPath) =>
            await _notesRepository.GetNoteContent(contentPath);

        public async Task<IEnumerable<NoteDto>> GetNotesForUser(string queryName)
        {
            if (!_session.IsAuthenticated)
            {
                return new List<NoteDto>();
            }
            var elements = await _notesRepository.GetNotesForUser(_session.UserId.Value, queryName);
            return elements.Select(x => new NoteDto
            {
                Id = x.Id.Id,
                ContentPath = x.ContentPath,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate,
                Name = x.Name
            });
        }

        public async Task UpdateNote(NoteDataStructure dataStructure, string content)
        {
            var note = await GetNoteOrThrow(dataStructure.Id);
            note.Update(dataStructure.Name, dataStructure.ContentPath);
            await _notesRepository.Update(note);
            await _notesRepository.SaveNoteFile(note.ContentPath, content);
        }

        public async Task DeleteNote(AggregateId id)
        {
            var note = await GetNoteOrThrow(id);
            note.Archive();
            await _notesRepository.Update(note);
            _notesRepository.DeleteNoteFile(note.ContentPath);
        }

        private Task<Note> GetNoteOrThrow(AggregateId id)
        {
            var note = _notesRepository.Get(x => x.Id == id.Id && !x.IsArchived);
            if (note == null)
            {
                throw new BusinessLogicException("Note not found");
            }

            return note;
        }
    }
}