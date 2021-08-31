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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrawLine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Tuples
        public List<Tuple<int, int>> Coords { get; set; } = new List<Tuple<int, int>>
        {
            new Tuple<int, int>(0,0),
            new Tuple<int, int>(100,100),
            new Tuple<int, int>(200,100),
            new Tuple<int, int>(400,200),
            new Tuple<int, int>(700,300)
        };

        // Named Tuples
        //public List<(int X, int Y)> CoordsNamed = new List<(int X, int Y)>
        //    {
        //        (0, 0),
        //        (100, 100)
        //    };

        List<Point> Points = new List<Point>();
        Storyboard sb;

        public MainWindow()
        {
            InitializeComponent();

            //DrawSimpleLine();

            Points.Add(new Point(100, 200));
            Points.Add(new Point(500, 300));
            Points.Add(new Point(200, 200));
            Points.Add(new Point(400, 220));
            Points.Add(new Point(450, 200));
            Points.Add(new Point(500, 350));

            InitAnimation();

            sb.Begin(this);
        }

        private void InitAnimation()
        {
            sb = new Storyboard();

            for (int i = 0; i < Points.Count - 1; i++)
            {
                // neue linie im aktuellen segment
                var line = new Line();

                line.Stroke = Brushes.Black;
                line.StrokeThickness = 2;

                // daten aus liste
                Point startPoint = Points[i];
                Point endPoint = Points[i + 1];

                // setzen der startpunkte = endpunkte => zeichnen der liste
                line.X1 = startPoint.X;
                line.Y1 = startPoint.Y;
                line.X2 = startPoint.X;
                line.Y2 = startPoint.Y;
                Cvs_Main.Children.Add(line);

                // Initialisieren der Animationen mit Dauer von 1 Sekunde für jedes Segment
                var doubleAnimationX = new DoubleAnimation(endPoint.X, new Duration(TimeSpan.FromMilliseconds(1000)));
                var doubleAnimationY = new DoubleAnimation(endPoint.Y, new Duration(TimeSpan.FromMilliseconds(1000)));

                doubleAnimationX.BeginTime = TimeSpan.FromMilliseconds(i * 1010);
                doubleAnimationY.BeginTime = TimeSpan.FromMilliseconds(i * 1010);

                sb.Children.Add(doubleAnimationX);
                sb.Children.Add(doubleAnimationY);

                // Ziele für Animation setzen
                Storyboard.SetTarget(doubleAnimationX, line);
                Storyboard.SetTarget(doubleAnimationY, line);
                Storyboard.SetTargetProperty(doubleAnimationX, new PropertyPath(Line.X2Property));
                Storyboard.SetTargetProperty(doubleAnimationY, new PropertyPath(Line.Y2Property));
            }
        }

        private void DrawSimpleLine()
        {
            //foreach (var coord in CoordsNamed)
            //{
            //    Line line = new Line();
            //    line.Stroke = new SolidColorBrush(Colors.Black);
            //    line.StrokeThickness = 2;

            //    line.X1 = coord.X;
            //}

            for (int i = 0; i < Coords.Count - 1; i++)
            {
                Line line = new Line();
                line.Stroke = new SolidColorBrush(Colors.Black);
                line.StrokeThickness = 2;
                line.X1 = Coords[i].Item1;
                line.Y1 = Coords[i].Item2;
                line.X2 = Coords[i + 1].Item1;
                line.Y2 = Coords[i + 1].Item2;

                Cvs_Main.Children.Add(line);
            }
        }
    }
}
