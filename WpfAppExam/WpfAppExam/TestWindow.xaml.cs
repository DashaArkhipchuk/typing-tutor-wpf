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
using System.Windows.Shapes;

namespace WpfAppExam
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow()
        {
            InitializeComponent();
        }

        private void Polunytsya_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Геть з України, москаль некрасівий");
            DialogResult = false;
        }

        private void Palianytsia_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Слава Україні!");
            DialogResult = true;
        }
    }
}
