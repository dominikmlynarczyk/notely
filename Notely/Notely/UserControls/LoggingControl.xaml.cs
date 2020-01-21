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
using Notely.Application.Users.Commands;

namespace Notely.UserControls
{
    /// <summary>
    /// Interaction logic for LoggingControl.xaml
    /// </summary>
    public partial class LoggingControl : UserControl
    {
        public LoggingControl()
        {
            InitializeComponent();
        }

        public event Action<(string username, string password)> OnSigningInEvent;
        public event Action<RegisterUserCommand> OnSigningUpEvent;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnSigningInEvent?.Invoke((LoginUserNameTextBox.Text, LoginPasswordTextBox.Password));
        }

        private void RegisterButton_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            var command = new RegisterUserCommand(RegisterUserNameTextBox.Text, RegisterFirstNameTextBox.Text, 
                RegisterSecondNameTextBox.Text, RegisterEmailTextBox.Text, RegisterPasswordTextBox.Password,
                RegisterConfirmPasswordTextBox.Password);

            OnSigningUpEvent?.Invoke(command);
        }
    }
}
