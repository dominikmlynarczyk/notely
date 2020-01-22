using System;
using Notely.Domain.Users;
using Notely.Infrastructure.Users;
using Notely.SharedKernel.Infrastructure;

namespace Notely.Infrastructure.Notes
{
    public class NoteEntity : BaseNotelyDbEntity
    {
        public string Name { get; set; }
        public string ContentPath { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
