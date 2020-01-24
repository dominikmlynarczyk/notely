using System.Threading.Tasks;
using Notely.Application.Notes.Commands;
using Notely.Domain.Notes.DataStructures;
using Notely.Infrastructure;
using Notely.SharedKernel;
using Notely.SharedKernel.Application.Handlers;

namespace Notely.Application.Notes.Handlers
{
    public class UpdateNoteCommandHandler : ICommandHandler<UpdateNoteCommand>
    {
        private readonly INoteService _noteService;
        private readonly ISession _session;

        public UpdateNoteCommandHandler(INoteService noteService, ISession session)
        {
            _noteService = noteService;
            _session = session;
        }

        public async Task Handle(UpdateNoteCommand command)
        {
            var dataStructure = new NoteDataStructure(command.Id, command.Name, command.ContentPath, new AggregateId(_session.UserId.Value));
            await _noteService.UpdateNote(dataStructure, command.Content);
        }
    }
}