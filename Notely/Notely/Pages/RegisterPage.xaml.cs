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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Notely.Application.Users;
using Notely.Application.Users.Commands;
using Notely.Domain.Users.DataStructures;
using Notely.SharedKernel.Application.Handlers;

namespace Notely.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private readonly ICommandDispatcher _commandDispatcher;
        public RegisterPage(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var command = new RegisterUserCommand(UserNameTextBox.Text, FirstNameTextBox.Text, SecondNameTextBox.Text,
                EmailTextBox.Text, PasswordPasswordBox.Password, ConfirmPasswordPasswordBox.Password);

            _commandDispatcher.Dispatch(command);
        }
    }
}
