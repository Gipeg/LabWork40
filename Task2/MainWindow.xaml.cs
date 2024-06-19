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

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DrawChristmasTree();
        }
        private void DrawChristmasTree()
        {
            Polygon tree = new Polygon()
            {
                Fill = Brushes.Green,
                Stroke = Brushes.Brown,
                StrokeThickness = 2
            };
            tree.Points.Add(new Point(400, 50));
            tree.Points.Add(new Point(300, 150));
            tree.Points.Add(new Point(500, 150));
            canvas.Children.Add(tree);

            Rectangle trunk = new Rectangle()
            {
                Fill = Brushes.Brown,
                Width = 40,
                Height = 60,
                Margin = new Thickness(380, 200, 0, 0)
            };
            canvas.Children.Add(trunk);
        }

        private void OnCanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Random random = new Random();

            // Random color
            byte[] rgb = new byte[3];
            random.NextBytes(rgb);
            Color color = Color.FromRgb(rgb[0], rgb[1], rgb[2]);

            // Random size and radius
            int size = random.Next(20, 50);
            int radius = size / 2;

            // Create and position the ellipse (circle)
            Ellipse ellipse = new Ellipse()
            {
                Fill = new SolidColorBrush(color),
                Width = size,
                Height = size
            };
            Canvas.SetLeft(ellipse, e.GetPosition(canvas).X - radius);
            Canvas.SetTop(ellipse, e.GetPosition(canvas).Y - radius);

            canvas.Children.Add(ellipse);
        }
    }
}
