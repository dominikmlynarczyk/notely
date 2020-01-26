using Notely.SharedKernel;
using Notely.SharedKernel.Application;

namespace Notely.Application.Notes.Commands
{
    public class UpdateNoteCommand : ICommand
    {
        public AggregateId Id { get;}
        public string Name { get;}
        public string ContentPath { get; }
        public string Content { get; }

        public UpdateNoteCommand(AggregateId id, string name, string contentPath, string content)
        {
            Id = id;
            Name = name;
            ContentPath = contentPath;
            Content = content;
        }
    }
}