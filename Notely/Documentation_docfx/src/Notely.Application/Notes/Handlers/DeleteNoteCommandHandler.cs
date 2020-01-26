using System.Threading.Tasks;
using Notely.Application.Notes.Commands;
using Notely.SharedKernel.Application.Handlers;

namespace Notely.Application.Notes.Handlers
{
    public class DeleteNoteCommandHandler : ICommandHandler<DeleteNoteCommand>
    {
        private readonly INoteService _noteService;

        public DeleteNoteCommandHandler(INoteService noteService)
        {
            _noteService = noteService;
        }

        public async Task Handle(DeleteNoteCommand command)
        {
            await _noteService.DeleteNote(command.Id);
        }
    }
}