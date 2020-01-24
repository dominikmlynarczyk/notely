using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Notely.Application.Users.Commands;
using Notely.Infrastructure;
using Notely.SharedKernel;
using Notely.SharedKernel.Application.Handlers;

namespace Notely.Windows
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ISession _session;
        public ChangePasswordWindow(ISession session, ICommandDispatcher commandDispatcher)
        {
            _session = session;
            _commandDispatcher = commandDispatcher;
            InitializeComponent();
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            var command = new ChangePasswordCommand(new AggregateId(_session.UserId.Value), OldPasswordBox.Password, NewPasswordBox.Password, ConfirmPasswordBox.Password);
            _commandDispatcher.Dispatch(command);
            if (MessageBox.Show(Notely.Properties.Resources.SavedSuccessfully, Notely.Properties.Resources.Success) == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_session.IsAuthenticated)
            {
                this.Close();
            }
        }
    }
}
