using System.Collections.Generic;
using System.Threading.Tasks;
using Notely.Application.Notes.DTOs;
using Notely.Application.Notes.Queries;
using Notely.SharedKernel.Application.Handlers;

namespace Notely.Application.Notes.Handlers
{
    public class GetNoteContentQueryHandler : IQueryHandler<GetNoteContentQuery, string>
    {
        private readonly INoteService _noteService;

        public GetNoteContentQueryHandler(INoteService noteService)
        {
            _noteService = noteService;
        }

        public async Task<string> Handle(GetNoteContentQuery query) => await _noteService.OpenNoteFile(query.FileName);
    }
    public class GetNotesForUserQueryHandler : IQueryHandler<GetNotesForUserQuery, IEnumerable<NoteDto>>
    {
        private readonly INoteService _noteService;

        public GetNotesForUserQueryHandler(INoteService noteService)
        {
            _noteService = noteService;
        }

        public async Task<IEnumerable<NoteDto>> Handle(GetNotesForUserQuery query) => await _noteService.GetNotesForUser(query.Name);
    }
}
