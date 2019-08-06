using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Xml;

namespace WpfApp_LoadXml
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        XmlDocument xml1 = null;
        XmlDocument xml2 = null;
        XmlDocument xml3 = null;
        XmlDocument xml4 = null;
        XmlDocument xml5 = null;
        XmlDocument xml6 = null;
        XmlDocument xml7 = null;
        XmlDocument xml8 = null;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var release = true;
            var button1 = sender as Button;
            var index = Convert.ToInt32(button1.Tag);
            var path = @"E:\VS Forms\Wpf_teleric_layout_data\car.xml";

            new Thread(() =>
            {
                button1.Dispatcher.Invoke(() => button1.IsEnabled = false);

                switch (index)
                {
                    case 1: if (release && xml1 != null) { xml1.RemoveAll(); } xml1 = new XmlDocument(); XGC.ClearMemory(); xml1.Load(path); break;
                    case 2: if (release && xml2 != null) { xml2.RemoveAll(); } xml2 = new XmlDocument(); XGC.ClearMemory(); xml2.Load(path); break;
                    case 3: if (release && xml3 != null) { xml3.RemoveAll(); } xml3 = new XmlDocument(); XGC.ClearMemory(); xml3.Load(path); break;
                    case 4: if (release && xml4 != null) { xml4.RemoveAll(); } xml4 = new XmlDocument(); XGC.ClearMemory(); xml4.Load(path); break;
                    case 5: if (release && xml5 != null) { xml5.RemoveAll(); } xml5 = new XmlDocument(); XGC.ClearMemory(); xml5.Load(path); break;
                    case 6: if (release && xml6 != null) { xml6.RemoveAll(); } xml6 = new XmlDocument(); XGC.ClearMemory(); xml6.Load(path); break;
                    case 7: if (release && xml7 != null) { xml7.RemoveAll(); } xml7 = new XmlDocument(); XGC.ClearMemory(); xml7.Load(path); break;
                    case 8: if (release && xml8 != null) { xml8.RemoveAll(); } xml8 = new XmlDocument(); XGC.ClearMemory(); xml8.Load(path); break;
                }
                button1.Dispatcher.Invoke(() => button1.IsEnabled = true);
            }).Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            xml1.DocumentElement.SetAttribute("content", "Root");
            var xdp = new XmlDataProvider { Document = xml1 };
            this.RTV1.DataContext = xdp;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            xml1.DocumentElement.SetAttribute("content", "Root1");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            xml1.RemoveAll();
            xml1 = null;
        }
    }
}
