using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Notely.Application.Notes.Commands;
using Notely.Application.Notes.DTOs;
using Notely.Application.Notes.Queries;
using Notely.SharedKernel;
using Notely.SharedKernel.Exceptions;

namespace Notely.UserControls
{
    /// <summary>
    /// Interaction logic for MainUserControl.xaml
    /// </summary>
    public partial class MainUserControl : UserControl
    {
        public Action<CreateNoteCommand> OnSaveNote;
        public Action<UpdateNoteCommand> OnUpdateNote;
        public Action<GetNoteContentQuery> OnOpenFile;
        public Action<DeleteNoteCommand> OnDeleteNote;
        public Action<string> OnDataGridRefreshed;
        public List<NoteDto> Notes;
        private Guid? _noteId;
        private string _notePath;
        public MainUserControl()
        {
            InitializeComponent();
            MainMarkdownEditor.AutoUpdateInterval = 1;
        }

        public void SetNotes(IEnumerable<NoteDto> elements)
        {
            Notes = elements.ToList();
            NotesDataGrid.ItemsSource = null;
            NotesDataGrid.ItemsSource = Notes;
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var fileName = _notePath;
            if (string.IsNullOrWhiteSpace(fileName) && !_noteId.HasValue)
            {
                var dialog = new SaveFileDialog {DefaultExt = "md", Filter = "Md file (*.md)|*.md", FileName = EditNameTextBox.Text };
                if (dialog.ShowDialog() == true)
                {
                    fileName = dialog.FileName;
                }
                else
                {
                    MessageBox.Show(Notely.Properties.Resources.FilePathNotSet);
                }
                var command = new CreateNoteCommand(EditNameTextBox.Text, fileName, MainMarkdownEditor.Text);
                OnSaveNote?.Invoke(command);
                SetNoteInfo(command.Id, fileName);
            }
            else
            {
                var command = new UpdateNoteCommand(new AggregateId(_noteId.Value), EditNameTextBox.Text, fileName, MainMarkdownEditor.Text);
                OnUpdateNote?.Invoke(command);
                SetNoteInfo(command.Id, fileName);
            }
            MessageBox.Show(Notely.Properties.Resources.SavedSuccessfully, Notely.Properties.Resources.Success, MessageBoxButton.OK);
            OnDataGridRefreshed?.Invoke(NameTextBox.Text);
        }

        private void SetNoteInfo(AggregateId commandId, string fileName)
        {
            _noteId = commandId.Id;
            _notePath = fileName;
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { DefaultExt = "md", Filter = "Md file (*.md)|*.md"};
            if (dialog.ShowDialog() == true)
            {
                var query = new GetNoteContentQuery(dialog.FileName);
                OnOpenFile?.Invoke(query);
            }
            else
            {
                MessageBox.Show(Notely.Properties.Resources.FileNotSet);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            NotesDataGrid.DataContext = Notes;
            OnDataGridRefreshed?.Invoke(NameTextBox.Text);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var noteId = ((Button)sender).Tag.ToString();

            var note = Notes.SingleOrDefault(x => x.Id == new Guid(noteId));
            if (note == null)
            {
                throw new BusinessLogicException(Notely.Properties.Resources.NoteNotFoundMessage);
            }
            OnOpenFile?.Invoke(new GetNoteContentQuery(note.ContentPath));
            _notePath = note.ContentPath;
            _noteId = note.Id;
            EditNameTextBox.Text = note.Name;
        }

        private void NameTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            OnDataGridRefreshed?.Invoke(NameTextBox.Text);
        }

        private void MainTabControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            NotesDataGrid.DataContext = Notes;
            OnDataGridRefreshed?.Invoke(NameTextBox.Text);
        }

        private void DeleteButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var noteId = ((Button)sender).Tag.ToString();

            var note = Notes.SingleOrDefault(x => x.Id == new Guid(noteId));
            if (note == null)
            {
                throw new BusinessLogicException(Notely.Properties.Resources.FileNotSet);
            }
            OnDeleteNote?.Invoke(new DeleteNoteCommand(new AggregateId(note.Id)));
            OnDataGridRefreshed?.Invoke(NameTextBox.Text);
        }

        private void NewNoteButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainMarkdownEditor.Text = string.Empty;
            MainMarkdownEditor.Text += " ";
            _noteId = null;
            _notePath = null;
            EditNameTextBox.Text = string.Empty;
            MainTabControl.SelectedItem = EditTabItem;
        }
    }
}
