﻿using SpurGearMechanismCreator.Calculations;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SpurGearMechanismCreator
{
    public partial class MainWindow : Window
    {
        public Point OriginPoint { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            OriginPoint = new Point(0, 0);
            DataContext = this;
            CollapsibleColumn.ElementStyle = this.FindResource("CollapsibleColumnStyle") as Style;
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            CalculationsResultsData Data = DimensionCalculations.Calculate(
                double.Parse(ModuleTextBox.Text),
                int.Parse(Z1TextBox.Text),
                int.Parse(Z2TextBox.Text),
                double.Parse(X1TextBox.Text),
                double.Parse(X2TextBox.Text));

            DataTable.ItemsSource = TableCalculations.GetTableData(Data);
            TranslateTransformObject.X = Data.ActionPosition.X;
            TranslateTransformObject.Y = Data.ActionPosition.Y;

            foreach (UIElement Element in Data.GearGeometry)
			{
                GearCanvas.Children.Add(Element);
            }
        }
    }
}