using System;
using Notely.SharedKernel.Application;

namespace Notely.Application.Notes.Queries
{
    public class GetNotesForUserQuery : IQuery
    {
        public GetNotesForUserQuery(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}