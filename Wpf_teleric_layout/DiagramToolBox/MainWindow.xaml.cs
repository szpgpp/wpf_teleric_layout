using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Primitives;

namespace DiagramToolBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainViewModel mvm = new MainViewModel();
            var x = mvm.Items[0].Shapes[0];
            var c = new RadDiagramShape();
            c.Width = 30;
            c.Height = 30;
            c.DataContext = x;
            this.xsp.Children.Add(c);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.toolbox.SelectedIndex = 1;
            this.toolbox.SelectedIndex = 0;
            this.toolbox.SizeChanged += (sender1, e1) => {
                var n = Convert.ToInt32(e1.NewSize.Width / 130);
                var x = this.FindChildByType<RadUniformGrid>();
                x.Columns = n;
                x.UpdateLayout();
            };
            this.toolbox.SelectionChanged+=(sender1,e1)=>
            {
                var n = Convert.ToInt32(this.toolbox.ActualWidth / 130);
                var x = this.FindChildByType<RadUniformGrid>();
                x.Columns = n;
                x.UpdateLayout();
            };
            //MainViewModel.Columns = "3";

            /*
            var x = this.FindChildByType<RadUniformGrid>();
            x.Columns = 3;
            var t = this.toolbox.SelectedIndex;
            this.toolbox.SelectedIndex = -1 ;
            this.toolbox.SelectedIndex = t;
            */
            //this.toolbox.UpdateLayout();
        }
    }
}
