using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notely.Infrastructure;

namespace Notely
{
    public class Session : ISession
    {
        private bool _isAuthenticated;
        public bool IsAuthenticated
        {
            get => _isAuthenticated;
            private set
            {
                _isAuthenticated = value;
                OnIsAuthenticatedChanged?.Invoke(_isAuthenticated);
            }
        }

        private Guid? _userId;
        private string _fullName;
        private string _userName;

        public Guid? UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                CheckIfAllIsCorrect();
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                CheckIfAllIsCorrect();
            }
        }

        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                CheckIfAllIsCorrect();
            } 
        }

        private void CheckIfAllIsCorrect()
        {
            if (!string.IsNullOrWhiteSpace(_fullName) && !string.IsNullOrWhiteSpace(_userName) && _userId.HasValue)
            {
                IsAuthenticated = true;
            }
            else if (string.IsNullOrWhiteSpace(_fullName) || string.IsNullOrWhiteSpace(_userName) || !_userId.HasValue)
            {
                IsAuthenticated = false;
            }
        }

        public event Action<bool> OnIsAuthenticatedChanged;
    }
}
