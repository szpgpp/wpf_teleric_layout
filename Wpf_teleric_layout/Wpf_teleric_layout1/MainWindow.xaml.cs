using Telerik.Windows.Controls;

namespace Wpf_teleric_layout1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RadRibbonWindow
    {
        static MainWindow()
        {
            StyleManager.ApplicationTheme = new Office2013Theme();
            RadRibbonWindow.IsWindowsThemeEnabled = false;
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
