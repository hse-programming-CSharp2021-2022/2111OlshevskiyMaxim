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

namespace Homework11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Polyline polyline = new() { Stroke = Brushes.Black, StrokeThickness = 2, Points = new() };

        public MainWindow()
        {
            InitializeComponent();
            canvas.Children.Add(polyline);
        }

        private void sliderH_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) =>
            polyline.Points.Add(new(sliderH.Value, sliderV.Maximum - sliderV.Value));

        private void sliderV_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) =>
            polyline.Points.Add(new(sliderH.Value, sliderV.Maximum - sliderV.Value));

        private void button_Click(object sender, RoutedEventArgs e) => polyline.Points.Clear();
    }
}
