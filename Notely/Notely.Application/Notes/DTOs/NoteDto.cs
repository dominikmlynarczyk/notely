using System;
using System.Collections.Generic;
using System.Text;
using Notely.SharedKernel;

namespace Notely.Application.Notes.DTOs
{
    public class NoteDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ContentPath { get; set; }
    }
}
