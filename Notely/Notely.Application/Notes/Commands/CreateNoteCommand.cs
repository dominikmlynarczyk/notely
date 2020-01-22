using System;
using System.Collections.Generic;
using System.Text;
using Notely.SharedKernel;
using Notely.SharedKernel.Application;

namespace Notely.Application.Notes.Commands
{
    public class CreateNoteCommand : ICommand
    {
        public AggregateId Id { get;}
        public string Name { get;}
        public string ContentPath { get; }
        public string Content { get; }

        public CreateNoteCommand(string name, string contentPath, string content)
        {
            Id = new AggregateId(Guid.NewGuid());
            Name = name;
            ContentPath = contentPath;
            Content = content;
        }
    }
}
