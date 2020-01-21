using System.Windows.Controls;

namespace Notely.UserControls
{
    public interface INotelyControl
    {
        UserControl ParentUserControl { get; set; }
    }
}