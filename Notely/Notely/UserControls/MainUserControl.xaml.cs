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
using Microsoft.Win32;
using Notely.Application.Notes.Commands;
using Notely.Application.Notes.Queries;

namespace Notely.UserControls
{
    /// <summary>
    /// Interaction logic for MainUserControl.xaml
    /// </summary>
    public partial class MainUserControl : UserControl
    {
        public Action<CreateNoteCommand> OnSaveFile;
        public Action<GetNoteContentQuery> OnOpenFile;
        public MainUserControl()
        {
            InitializeComponent();
            MainMarkdownEditor.AutoUpdateInterval = 1;
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var contentPath = "";
            var dialog = new SaveFileDialog {DefaultExt = "md"};
            if (dialog.ShowDialog() == true)
            {
                var command = new CreateNoteCommand("newTest", dialog.FileName, MainMarkdownEditor.Text);
                OnSaveFile?.Invoke(command);
            }
            else
            {
                MessageBox.Show("You have to set filename");
            }
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { DefaultExt = "md" };
            if (dialog.ShowDialog() == true)
            {
                var query = new GetNoteContentQuery(dialog.FileName);
                OnOpenFile?.Invoke(query);
            }
            else
            {
                MessageBox.Show("You have to choose file");
            }
        }
    }
}
