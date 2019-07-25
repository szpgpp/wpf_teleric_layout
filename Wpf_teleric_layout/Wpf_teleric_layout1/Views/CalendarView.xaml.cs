using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Wpf_teleric_layout1
{
    /// <summary>
    /// Interaction logic for CalendarView.xaml
    /// </summary>
    public partial class CalendarView : UserControl
    {
        public CalendarView()
        {
            InitializeComponent();
            IconSources.ChangeIconsSet(IconsSet.Modern);
        }
    }
}
