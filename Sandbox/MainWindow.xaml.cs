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

#if DEBUG
using Sandbox.src;
#endif

namespace Sandbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            DebugConsole.InitDebugConsole();
            InitializeComponent();

            
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DebugConsole.Trace("Test message");
            DebugConsole.Info("fsdfdsfdsfdsfd sdfdsf");
            DebugConsole.Warn("WARNING dfsfdfds");
            DebugConsole.Error("sdfdsf");
            DebugConsole.Critical("hdhbf sdfbshbdsfs sdbf shdfb sbdfh bsdhfb sdfb hsbfhsbfsdhfbsdhfbdsfhsdbfdsfbdsfb hsbdf sdbf hsdbf hsdbf shdfb sd");
        }
    }
}
