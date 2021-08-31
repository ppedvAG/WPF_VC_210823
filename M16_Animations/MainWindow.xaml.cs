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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M16_Animations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < Points.Count-1; i++)
            {
                Line line = new Line();

                line.Stroke = new SolidColorBrush(Colors.Black);
                line.StrokeThickness = 2;

                line.X1 = Points[i].X;
                line.Y1 = Points[i].Y;

                line.X2 = Points[i + 1].X;
                line.Y2 = Points[i + 1].Y;

                Cvs_Main.Children.Add(line);

            }
        }
        
        //Bsp-Daten für Graphen
        List<Point> Points = new List<Point>()
        {
            new Point(100, 200),
            new Point(150, 300),
            new Point(200, 200),
            new Point(400, 220),
            new Point(450, 200),
            new Point(500, 350)
        };
    }
}
