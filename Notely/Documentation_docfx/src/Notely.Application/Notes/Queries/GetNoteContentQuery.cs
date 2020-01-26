using Notely.SharedKernel.Application;

namespace Notely.Application.Notes.Queries
{
    public class GetNoteContentQuery : IQuery
    {
        public GetNoteContentQuery(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; }
    }
}
