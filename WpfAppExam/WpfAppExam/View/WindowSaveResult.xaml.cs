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
using System.Windows.Shapes;

namespace WpfAppExam
{
    /// <summary>
    /// Логика взаимодействия для WindowSaveResult.xaml
    /// </summary>
    public partial class WindowSaveResult : Window
    {
        public WindowSaveResult()
        {
            InitializeComponent();
            nametb.IsReadOnly = true;
        }
        public WindowSaveResult(int speed, int numberfails, int timeSec, DateTime dt)
        {
            InitializeComponent();
            speedtb.Text = ""+speed;
            failstb.Text = ""+numberfails;
            timeSectb.Text = ""+""+timeSec;
            dp.SelectedDate = dt;
        }
    }
}
