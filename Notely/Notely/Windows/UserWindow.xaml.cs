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
using Notely.Application.Users.DTOs;
using Notely.Application.Users.Queries;
using Notely.Infrastructure;
using Notely.SharedKernel.Application.Handlers;

namespace Notely.Windows
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ISession _session;

        public UserDto SelectedUserDto;

        public UserWindow(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, ISession session)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _session = session;
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_session.UserId.HasValue)
            {
                Close();
                return;
            }
            SelectedUserDto = await _queryDispatcher.Dispatch<GetUserInfoQuery, UserDto>(new GetUserInfoQuery(_session.UserId.Value));
            SetTextBoxesValues();
        }

        private void SetTextBoxesValues()
        {
            UserNameTextBox.Text = SelectedUserDto.UserName;
            FirstNameTextBox.Text = SelectedUserDto.FirstName;
            SecondNameTextBox.Text = SelectedUserDto.SecondName;
            EmailTextBox.Text = SelectedUserDto.Email;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            SetTextBoxesReadOnly(false);
        }

        private void SetTextBoxesReadOnly(bool isReadOnly)
        {
            UserNameTextBox.IsReadOnly = isReadOnly;
            FirstNameTextBox.IsReadOnly = isReadOnly;
            SecondNameTextBox.IsReadOnly = isReadOnly;
            EmailTextBox.IsReadOnly = isReadOnly;
            SaveButton.Visibility = isReadOnly ? Visibility.Hidden : Visibility.Visible;
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var command = new UpdateUserCommand(SelectedUserDto.Id, UserNameTextBox.Text, FirstNameTextBox.Text, SecondNameTextBox.Text,
                EmailTextBox.Text);
            _commandDispatcher.Dispatch(command);
            SetTextBoxesReadOnly(true);
        }
    }
}
