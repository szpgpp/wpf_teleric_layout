using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            {
                MainViewModel mvm = new MainViewModel();
                var x = mvm.Items[0].Shapes[0];
                var c = new RadDiagramShape();
                c.Width = 30;
                c.Height = 30;
                c.DataContext = x;
                this.xsp.Children.Add(c);
            }
            if(false){
                this.toolbox.SizeChanged += (sender1, e1) =>
                {
                    var n = Convert.ToInt32(e1.NewSize.Width / 130);
                    var x = this.FindChildByType<RadUniformGrid>();
                    var i = this.toolbox.SelectedIndex;
                    if (x != null)
                    {
                        x.Columns = n;
                        x.UpdateLayout();
                    }
                    else
                    {
                        /*
                        MainViewModel.Columns = n.ToString();
                        var t = this.toolbox.ItemTemplate;
                        this.toolbox.DataContext = this.toolbox.DataContext;
                        this.toolbox.ItemsSource = this.toolbox.ItemsSource;
                        */
                        var selectItem = this.toolbox.SelectedItem as MyGallery;
                        selectItem.Columns = n.ToString();
                    }
                };
                this.toolbox.SelectionChanged += (sender1, e1) =>
                {
                    var n = Convert.ToInt32(this.toolbox.ActualWidth / 130);
                    var x = this.FindChildByType<RadUniformGrid>();
                    if (x != null)
                    {
                        x.Columns = n;
                        x.UpdateLayout();
                    }
                    else
                    {
                        /*
                        MainViewModel.Columns = n.ToString();
                        this.toolbox.DataContext = this.toolbox.DataContext;
                        */
                        var selectItem = this.toolbox.SelectedItem as MyGallery;
                        selectItem.Columns = n.ToString();
                    }
                };
                this.toolbox.SelectedIndex = 1;
                this.toolbox.SelectedIndex = 0;
            }
            if (true)
            {
                this.toolbox.SizeChanged += (sender1, e1) =>
                {
                    this.ChangeColumnByResize();
                };
                this.toolbox.SelectionChanged += (sender1, e1) =>
                {
                    this.ChangeColumnByResize();
                };
            }

        }
        private void ChangeColumnByResize()
        {
            var n = Convert.ToInt32(this.toolbox.ActualWidth / 130);
            this.setRadiamToolBoxColumns(n);
        }
        private void setRadiamToolBoxColumns(int col)
        {
            //
            if (this.toolbox == null) return;
            if (this.toolbox.DataContext == null) return;

            //
            var model = this.toolbox.DataContext as MainViewModel;
            foreach (var item in model.Items)
            {
                var item_g = item as MyGallery;
                item_g.Columns = col.ToString();
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {

            var m = this.toolbox.DataContext as MainViewModel;
            foreach (var item in m.Items)
            {
                var item1 = item as MyGallery;
                item1.Columns = "2";
            }

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
