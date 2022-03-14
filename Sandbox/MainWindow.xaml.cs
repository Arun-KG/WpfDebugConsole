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
using WPFDebugger;

#if DEBUG

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
            DebugConsole.StartProfile("Total");

            DebugConsole.Trace("Test message");
            DebugConsole.NewLine();

            DebugConsole.StartProfile("10000 prime number calculator");
            //DebugConsole.Info("fsdfdsfdsfdsfd sdfdsf");
            //DebugConsole.Warn("WARNING dfsfdfds");
            //DebugConsole.Error("sdfdsf");
            FindPrimeNumber(10000);
            DebugConsole.StopProfile();

            DebugConsole.StartProfile("100 prime number calculator");
            FindPrimeNumber(100);
            DebugConsole.StopProfile();

            DebugConsole.Critical("hdhbf sdfbshbdsfs sdbf shdfb sbdfh bsdhfb sdfb hsbfhsbfsdhfbsdhfbdsfhsdbfdsfbdsfb hsbdf sdbf hsdbf hsdbf shdfb sd");

            DebugConsole.StopProfile();
        }

        public long FindPrimeNumber(int n)
        {
            int count = 0;
            long a = 2;
            while (count < n)
            {
                long b = 2;
                int prime = 1;// to check if found a prime
                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                {
                    count++;
                }
                a++;
            }
            return (--a);
        }
    }
}
