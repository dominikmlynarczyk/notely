using System;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using Notely.Application.Notes.Commands;
using Notely.Application.Notes.Queries;
using Notely.Application.Users.Commands;
using Notely.Infrastructure;
using Notely.SharedKernel;
using Notely.SharedKernel.Application.Handlers;
using Notely.UserControls;

namespace Notely
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ISession _session;
        private readonly IQueryDispatcher _queryDispatcher;
        private AggregateId? _noteId;
        public MainWindow(ICommandDispatcher commandDispatcher, ISession session, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _session = session;
            _queryDispatcher = queryDispatcher;
            InitializeComponent();
            LoggingControl.OnSigningInEvent += OnSigningInEventHandler;
            LoggingControl.OnSigningUpEvent += OnSigningUpEventHandler;
            MainUserControl.OnSaveFile += SaveFile;
            MainUserControl.OnOpenFile += OpenFile;
            _session.OnIsAuthenticatedChanged += OnIsAuthenticatedChangedEventHandler;
        }

        private async void OpenFile(GetNoteContentQuery query)
        {
            var content = await _queryDispatcher.Dispatch<GetNoteContentQuery, string>(query);
            MainUserControl.MainMarkdownEditor.Text = content;
            MainUserControl.MainTabControl.SelectedItem = MainUserControl.EditTabItem;
        }

        private void SaveFile(CreateNoteCommand command)
        {
            if (!_noteId.HasValue)
            {

                _commandDispatcher.Dispatch(command);
                _noteId = command.Id;
            }
        }

        private void OnIsAuthenticatedChangedEventHandler(bool isAuthenticated)
        {
            if (isAuthenticated)
            {
                LoggingControl.Visibility = Visibility.Hidden;
                MainUserControl.Visibility = Visibility.Visible;
                SignOutButton.Visibility = Visibility.Visible;
                NameLabel.Visibility = Visibility.Visible;
                NameLabel.Content = String.Format(NameLabel.Content.ToString(), string.IsNullOrWhiteSpace(_session.FullName) ? _session.UserName : _session.FullName);
            }
            else
            {

                LoggingControl.Visibility = Visibility.Visible;
                MainUserControl.Visibility = Visibility.Hidden;
                SignOutButton.Visibility = Visibility.Hidden;
                NameLabel.Visibility = Visibility.Hidden;
            }
        }

        private async void OnSigningUpEventHandler(RegisterUserCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            LoggingControl.TabIndex = 0;
        }

        private async void OnSigningInEventHandler((string username, string password) credentials)
        {
            var command = new LoginUserCommand(credentials.username, credentials.password);
            await _commandDispatcher.Dispatch(command);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void ClearSession()
        {
            _session.UserName = null;
            _session.FullName = null;
            _session.UserId = null;
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            ClearSession();
        }
    }
}
