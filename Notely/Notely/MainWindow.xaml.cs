using System;
using System.Windows;
using Autofac;
using Notely.Application.Users.Commands;
using Notely.Infrastructure;
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
        private readonly IComponentContext _componentContext;
        public MainWindow(ICommandDispatcher commandDispatcher, ISession session, IComponentContext componentContext)
        {
            _commandDispatcher = commandDispatcher;
            _session = session;
            _componentContext = componentContext;
            InitializeComponent();
            LoggingControl.OnSigningInEvent += OnSigningInEventHandler;
            LoggingControl.OnSigningUpEvent += OnSigningUpEventHandler;
            _session.OnIsAuthenticatedChanged += OnIsAuthenticatedChangedEventHandler;
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

        private void OnSigningUpEventHandler(RegisterUserCommand command)
        {
            _commandDispatcher.Dispatch(command);
            LoggingControl.TabIndex = 0;
        }

        private void OnSigningInEventHandler((string username, string password) credentials)
        {
            var command = new LoginUserCommand(credentials.username, credentials.password);
            _commandDispatcher.Dispatch(command);
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
