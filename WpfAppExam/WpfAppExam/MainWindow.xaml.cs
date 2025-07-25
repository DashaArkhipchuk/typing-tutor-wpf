﻿using System;
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
using System.Windows.Threading;
using WpfAppExam;

namespace WpfApp_dz2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int tempTimer = 0;
        Random randChar = new Random();
        string allKeysString = "QWERTYUIOPASDFGHJKLZXCVBNM~!@#$%^&*()_+{}|:\"<>?1234567890[],./\\`-=;'qwertyuiopasdfghjklzxcvbnm";
        bool flagCapsLock = true;
        bool flagBackspase = true;
        bool mesStop = true;
        DispatcherTimer timer = null;
        int avgSpeed = 0;
        int count = 0;



        public int Fails
        {
            get { return (int)GetValue(FailsProperty); }
            set { SetValue(FailsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Fails.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FailsProperty =
            DependencyProperty.Register("Fails", typeof(int), typeof(MainWindow), new PropertyMetadata(0));


        public int Speed
        {
            get { return (int)GetValue(SpeedProperty); }
            set { SetValue(SpeedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Speed.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SpeedProperty =
            DependencyProperty.Register("Speed", typeof(int), typeof(MainWindow), new PropertyMetadata(0));

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            TestWindow test=new TestWindow();
            test.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (test.ShowDialog()==false)
            {
                this.Close();
            }
        }
        private void CapitalLetters()
        {
            this.Q.Content = "Q";
            this.W.Content = "W";
            this.E.Content = "E";
            this.R.Content = "R";
            this.T.Content = "T";
            this.Y.Content = "Y";
            this.U.Content = "U";
            this.I.Content = "I";
            this.O.Content = "O";
            this.P.Content = "P";
            this.A.Content = "A";
            this.S.Content = "S";
            this.D.Content = "D";
            this.F.Content = "F";
            this.G.Content = "G";
            this.H.Content = "H";
            this.J.Content = "J";
            this.K.Content = "K";
            this.L.Content = "L";
            this.Z.Content = "Z";
            this.X.Content = "X";
            this.C.Content = "C";
            this.V.Content = "V";
            this.B.Content = "B";
            this.N.Content = "N";
            this.M.Content = "M";

        }
        private void LoverLetters()
        {
            this.Q.Content = "q";
            this.W.Content = "w";
            this.E.Content = "e";
            this.R.Content = "r";
            this.T.Content = "t";
            this.Y.Content = "y";
            this.U.Content = "u";
            this.I.Content = "i";
            this.O.Content = "o";
            this.P.Content = "p";
            this.A.Content = "a";
            this.S.Content = "s";
            this.D.Content = "d";
            this.F.Content = "f";
            this.G.Content = "g";
            this.H.Content = "h";
            this.J.Content = "j";
            this.K.Content = "k";
            this.L.Content = "l";
            this.Z.Content = "z";
            this.X.Content = "x";
            this.C.Content = "c";
            this.V.Content = "v";
            this.B.Content = "b";
            this.N.Content = "n";
            this.M.Content = "m";

        }
        private void CapitalSymbol()
        {
            this.Oem3.Content = "~";
            this.D1.Content = "!";
            this.D2.Content = "@";
            this.D3.Content = "#";
            this.D4.Content = "$";
            this.D5.Content = "%";
            this.D6.Content = "^";
            this.D7.Content = "&";
            this.D8.Content = "*";
            this.D9.Content = "(";
            this.D0.Content = ")";
            this.OemMinus.Content = "_";
            this.OemPlus.Content = "+";
            this.OemOpenBrackets.Content = "{";
            this.Oem6.Content = "}";
            this.Oem5.Content = "|";
            this.Oem1.Content = ":";
            this.OemQuotes.Content = "\"";
            this.OemComma.Content = "<";
            this.OemPeriod.Content = ">";
            this.OemQuestion.Content = "?";
        }
        private void LoverSymbol()
        {
            this.Oem3.Content = "`";
            this.D1.Content = "1";
            this.D2.Content = "2";
            this.D3.Content = "3";
            this.D4.Content = "4";
            this.D5.Content = "5";
            this.D6.Content = "6";
            this.D7.Content = "7";
            this.D8.Content = "8";
            this.D9.Content = "9";
            this.D0.Content = "0";
            this.OemMinus.Content = "-";
            this.OemPlus.Content = "=";
            this.OemOpenBrackets.Content = "[";
            this.Oem6.Content = "]";
            this.Oem5.Content = "\\";
            this.Oem1.Content = ";";
            this.OemQuotes.Content = "'";
            this.OemComma.Content = ",";
            this.OemPeriod.Content = ".";
            this.OemQuestion.Content = "/";
        }
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (UIElement it in (this.Content as Grid).Children)
            {
                if (it is Grid)
                {
                    foreach (var item in (it as Grid).Children)
                    {
                        if (item is Button)
                        {
                            if ((item as Button).Name == e.Key.ToString())
                            {
                                (item as Button).Opacity = 0.5;
                                if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                {
                                    CapitalSymbol();
                                    if (flagCapsLock)
                                    {
                                        CapitalLetters();
                                    }
                                    else
                                    {
                                        LoverLetters();
                                    }
                                }
                                else if (e.Key.ToString() == "Capital")
                                {
                                    if (flagCapsLock)
                                    {
                                        CapitalLetters();
                                        flagCapsLock = false;
                                    }
                                    else
                                    {
                                        LoverLetters();
                                        flagCapsLock = true;
                                    }
                                }
                                else if (e.Key.ToString() == "Back")
                                {
                                    flagBackspase = false;
                                }
                                else
                                {
                                    flagBackspase = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Win_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            lineUser.Focus();
            foreach (UIElement it in (this.Content as Grid).Children)
            {
                if (it is Grid)
                {
                    foreach (var item in (it as Grid).Children)
                    {
                        if (item is Button)
                        {

                            if ((item as Button).Name == e.Key.ToString())
                            {
                                (item as Button).Opacity = 1;
                                if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                {
                                    LoverSymbol();
                                    if (!flagCapsLock)
                                    {
                                        CapitalLetters();
                                    }
                                    else
                                    {
                                        LoverLetters();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (!mesStop)
            {
                int res = (int)avgSpeed / count;
                MessageBox.Show($"Task completed.\n Number of symbols {linePrograms.Text.Length}.\n Number of fails {Fails}.\nTo finish the task press button \"Stop\"", "Task Completed", MessageBoxButton.OK);
                if (MessageBox.Show($"Do you want to save the result?", "Task Completed", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    WindowSaveResult w = new WindowSaveResult(res, Fails, tempTimer, DateTime.Now);
                    w.Show();
                }

                mesStop = true;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Start.IsEnabled = false;
            SliderDifficulty.IsEnabled = false;
            CaseSensitive.IsEnabled = false;
            Stop.IsEnabled = true;
            tempTimer = 0;
            timer.Start();
            CollectString(Convert.ToInt32(Difficulty.Content), allKeysString, !(bool)CaseSensitive.IsChecked);
            lineUser.IsReadOnly = false;
            lineUser.IsEnabled = true;
            lineUser.Focus();
            ResultsButton.IsEnabled = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tempTimer++;
            SpeedSet();
        }

        private void CollectString(int countChar, string baceString, bool flagSensitive)
        {
            string chars = "";
            int sensitive = (flagSensitive) ? 47 : 0;
            for (int i = 0; i < countChar; i++)
            {
                chars += baceString[randChar.Next(sensitive, baceString.Length)];
            }
            chars += " ";
            int countString = (flagSensitive) ? 75 : 70;
            for (int i = 0; i < countString; i++)
            {
                linePrograms.Text += chars[randChar.Next(0, chars.Length)];
            }
        }
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Start.IsEnabled = true;
            SliderDifficulty.IsEnabled = true;
            CaseSensitive.IsEnabled = true;
            Stop.IsEnabled = false;
            lineUser.Text = "";
            linePrograms.Text = "";
            Speed = 0;
            Fails = 0;
            lineUser.IsReadOnly = true;
            lineUser.IsEnabled = false;
            timer.Stop();
            tempTimer = 0;
            ResultsButton.IsEnabled = true;
        }
        private void lineUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            string strProgram = linePrograms.Text.Substring(0, lineUser.Text.Length);
            string strUser=CaseSensitive.IsChecked==true?lineUser.Text:lineUser.Text.ToLower();
            if (CaseSensitive.IsChecked == false)
            {
                strProgram.ToLower();
                lineUser.Text.ToLower();
            }
            if (strUser.Equals(strProgram))
            {
                if (flagBackspase)
                {
                    SpeedSet();
                }
                lineUser.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                if (flagBackspase)
                {
                    SpeedSet();
                    Fails++;
                }
                lineUser.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (lineUser.Text.Length == linePrograms.Text.Length)
            {
                timer.Stop();
                SpeedSet();
                lineUser.IsReadOnly = true;
                mesStop = false;
            }
        }
        private void CaseSensitive_Checked_1(object sender, RoutedEventArgs e)
        {
            SliderDifficulty.Maximum = 94;
        }
        private void CaseSensitive_Unchecked(object sender, RoutedEventArgs e)
        {
            SliderDifficulty.Maximum = 47;
        }
        void SpeedSet()
        {
            count++;
            avgSpeed += Speed;
            Speed = (int)Math.Round(((double)lineUser.Text.Length / tempTimer) * 60);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowSaveResult w = new WindowSaveResult();
            w.Show();
        }
    }
}