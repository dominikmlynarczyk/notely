using System.Threading.Tasks;
using Notely.Domain.Notes;
using Notely.Domain.Notes.DataStructures;
using Notely.Domain.Notes.Factories;
using Notely.Infrastructure.Notes;
using Notely.SharedKernel.Exceptions;

namespace Notely.Application.Notes
{
    public interface INoteService : IService
    {
        Task AddNote(NoteDataStructure dataStructure, string content);
        Task<string> OpenNoteFile(string contentPath);
    }

    public class NoteService : INoteService
    {
        private readonly INotesRepository _notesRepository;
        private readonly INoteDomainFactory _noteDomainFactory;

        public NoteService(INotesRepository notesRepository, INoteDomainFactory noteDomainFactory)
        {
            _notesRepository = notesRepository;
            _noteDomainFactory = noteDomainFactory;
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
    }
}
