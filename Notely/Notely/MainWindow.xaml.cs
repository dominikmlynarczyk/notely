using System;
using System.Collections.Generic;
using System.Windows;
using Notely.Application.Notes.Commands;
using Notely.Application.Notes.DTOs;
using Notely.Application.Notes.Queries;
using Notely.Application.Users.Commands;
using Notely.Infrastructure;
using Notely.SharedKernel;
using Notely.SharedKernel.Application.Handlers;
using Notely.Windows;

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
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            LoggingControl.OnSigningInEvent += OnSigningInEventHandler;
            LoggingControl.OnSigningUpEvent += OnSigningUpEventHandler;
            MainUserControl.OnSaveNote += SaveNote;
            MainUserControl.OnUpdateNote += UpdateNote;
            MainUserControl.OnOpenFile += OpenFile;
            MainUserControl.OnDataGridRefreshed += LoadNotes;
            MainUserControl.OnDeleteNote += DeleteNote;
            _session.OnIsAuthenticatedChanged += OnIsAuthenticatedChangedEventHandler;
        }

        private async void DeleteNote(DeleteNoteCommand command)
        {
            await _commandDispatcher.Dispatch(command);
        }

        private async void UpdateNote(UpdateNoteCommand command)
        {
            await _commandDispatcher.Dispatch(command);
        }

        private async void LoadNotes(string obj)
        {
            var elements =
                await _queryDispatcher.Dispatch<GetNotesForUserQuery, IEnumerable<NoteDto>>(
                    new GetNotesForUserQuery(obj));
            MainUserControl.SetNotes(elements);
        }

        private async void OpenFile(GetNoteContentQuery query)
        {
            var content = await _queryDispatcher.Dispatch<GetNoteContentQuery, string>(query);
            MainUserControl.MainMarkdownEditor.Text = content;
            MainUserControl.MainMarkdownEditor.Text += " ";
            MainUserControl.MainTabControl.SelectedItem = MainUserControl.EditTabItem;
        }

        private void SaveNote(CreateNoteCommand command)
        {
            _commandDispatcher.Dispatch(command);
                _noteId = command.Id;
        }

        private void OnIsAuthenticatedChangedEventHandler(bool isAuthenticated)
        {
            if (isAuthenticated)
            {
                LoggingControl.Visibility = Visibility.Hidden;
                MainUserControl.Visibility = Visibility.Visible;
                SignOutButton.Visibility = Visibility.Visible;
                UserInfoButton.Visibility = Visibility.Visible;
                NameLabel.Visibility = Visibility.Visible;
                NameLabel.Content = String.Format(NameLabel.Content.ToString(), string.IsNullOrWhiteSpace(_session.FullName) ? _session.UserName : _session.FullName);
                
            }
            else
            {

                LoggingControl.Visibility = Visibility.Visible;
                MainUserControl.Visibility = Visibility.Hidden;
                SignOutButton.Visibility = Visibility.Hidden;
                UserInfoButton.Visibility = Visibility.Hidden;
                NameLabel.Visibility = Visibility.Hidden;
                NameLabel.Content = "Hello, {0}";
            }
        }

        private async void OnSigningUpEventHandler(RegisterUserCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            LoggingControl.SigningTabControl.SelectedItem = LoggingControl.LoginTabItem;
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

        private void UserInfoButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new UserWindow(_commandDispatcher, _queryDispatcher, _session);
            window.Show();
        }

        private void LoggingControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
