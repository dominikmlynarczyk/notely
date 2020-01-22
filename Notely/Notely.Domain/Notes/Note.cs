using System;
using Notely.SharedKernel;

namespace Notely.Domain.Notes
{
    public class Note : AggregateRoot
    {
        public string Name { get; private set; }
        public string ContentPath { get; private set; }
        public AggregateId UserId { get; private set; }

        private Note()
        {
        }

        public Note(AggregateId id, string name, string contentPath, AggregateId userId) : base(id)
        {
            SetName(name);
            SetContentPath(contentPath);
            UserId = userId;
        }

        public void Update(string name, string contentPath)
        {
            SetContentPath(contentPath);
            SetName(name);
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }

        private void SetContentPath(string contentPath)
        {
            if (string.IsNullOrWhiteSpace(contentPath))
            {
                throw new ArgumentNullException(nameof(contentPath));
            }

            ContentPath = contentPath;
        }
    }
}
