using Notely.SharedKernel;
using Notely.SharedKernel.Application;

namespace Notely.Application.Notes.Commands
{
    public class DeleteNoteCommand : ICommand
    {
        public AggregateId Id { get;}

        public DeleteNoteCommand(AggregateId id)
        {
            Id = id;
        }
    }
}