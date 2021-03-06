﻿using LanguageRecognition.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace LanguageRecognition.View
{
    /// <summary>
    /// Interaction logic for PrepareWindow.xaml
    /// </summary>
    public partial class PrepareWindow : Window
    {
        public PrepareWindow(PrepareWindowViewModel prepareWindowViewModel)
        {
            InitializeComponent();
            this.DataContext = prepareWindowViewModel;
        }

        //described in RecognizeWindow.xaml.cs
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}
