using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.DataWorker;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Brush custom_color;
        Random r = new Random();

        private bool _isRectDragInProg;
        private bool _isLineDragInProg;
        private bool _isLineProg;

        private Line _line;

        private readonly System.Timers.Timer _timer;

        public MainWindow()
        {
            InitializeComponent();
            _timer = new System.Timers.Timer(250);
            _timer.Elapsed += new ElapsedEventHandler(ShowSimulation);
        }

        private void AddImages(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < 3; i++)
            {
                Image first_crossroad = new Image();
                BitmapImage first_bitmap = new BitmapImage();

                first_bitmap.BeginInit();
                first_bitmap.UriSource = new Uri(System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"images\\traffic_0{i}.jpg"));
                first_bitmap.EndInit();
                first_crossroad.Source = first_bitmap;

                first_crossroad.MouseLeftButtonDown += image_MouseLeftButtonDown;
                first_crossroad.MouseLeftButtonUp += image_MouseLeftButtonUp;
                first_crossroad.MouseMove += image_MouseMove;

                Canvas.SetZIndex(first_crossroad, 0);
                TestCanvas.Children.Add(first_crossroad);
            }
        }

        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var canvas = (Image)sender;
            _isRectDragInProg = true;
            canvas.CaptureMouse();
        }


        private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var canvas = (Image)sender;
            _isRectDragInProg = false;
            canvas.ReleaseMouseCapture();
        }

        private void image_MouseMove(object sender, MouseEventArgs e)
        {
            var canvas = (Image)sender;

            // get the position of the mouse relative to the Canvas
            var mousePos = e.GetPosition(TestCanvas);

            // center the rect on the mouse
            double left = mousePos.X - canvas.ActualWidth/2;
            double top = mousePos.Y - canvas.ActualHeight/2;

            if (canvas != null && canvas.IsMouseCaptured)
            {
                Canvas.SetLeft(canvas, left);
                Canvas.SetTop(canvas, top);
            }
        }

        private void CreateCustomFigure()
        {
            List<StateRecord> current_state = new List<StateRecord>();
            current_state = DataHandler.GetData();
            
            int zero_circle = 5;
            int derivation = 50;
            int circle_size = 20;
            int small_square = 30;
            int big_square = 80;
            foreach (var item in current_state)
            {
                int zero_position = 0;
                Canvas figure_canvas = new Canvas();
                figure_canvas.Tag = item.GetMarker();

                Line line = new Line();
                line.Stroke = Brushes.LightSteelBlue;
                line.StrokeThickness = 8;

                line.X1 = 0;
                line.X2 = 150;

                line.Y1 = 0;
                line.Y2 = 150;

                line.MouseRightButtonDown += canvas_MouseRightButtonDown;
                line.MouseRightButtonUp += canvas_MouseRightButtonUp;
                
                figure_canvas.Children.Add(line);

                if (item.Traficligh_Type == 2)
                {
                    zero_position += small_square;
                    Ellipse left_circle = new Ellipse
                    {
                        Width = circle_size,
                        Height = circle_size,
                        Fill = Brushes.Black,
                        Stroke = Brushes.Black
                    };
                    Ellipse right_circle = new Ellipse
                    {
                        Width = circle_size,
                        Height = circle_size,
                        Fill = Brushes.Blue,
                        Stroke = Brushes.Black
                    };

                    // Create a rectangle geometry to add
                    Rectangle left_rectangle = new Rectangle
                    {
                        Width = small_square,
                        Height = small_square,
                        Fill = Brushes.GhostWhite,
                        StrokeThickness = 1,
                        Stroke = Brushes.Black
                    };
                    Rectangle right_rectangle = new Rectangle
                    {
                        Width = small_square,
                        Height = small_square,
                        Fill = Brushes.GhostWhite,
                        StrokeThickness = 1,
                        Stroke = Brushes.Black
                    };

                    left_circle.Tag = "Left";
                    right_circle.Tag = "Right";

                    Canvas.SetLeft(left_rectangle, 0);
                    Canvas.SetTop(left_rectangle, 50);
                    figure_canvas.Children.Add(left_rectangle);

                    Canvas.SetLeft(right_rectangle, small_square * 2);
                    Canvas.SetTop(right_rectangle, 50);
                    figure_canvas.Children.Add(right_rectangle);

                    Canvas.SetLeft(left_circle, zero_circle);
                    Canvas.SetTop(left_circle, small_square + zero_circle + circle_size);
                    figure_canvas.Children.Add(left_circle);

                    Canvas.SetLeft(right_circle, small_square * 2 + zero_circle);
                    Canvas.SetTop(right_circle, small_square + zero_circle + circle_size);
                    figure_canvas.Children.Add(right_circle);
                }

                Ellipse top_circle = new Ellipse
                {
                    Width = circle_size,
                    Height = circle_size,
                    Fill = Brushes.Red,
                    Stroke = Brushes.Black

                };
                Ellipse middle_circle = new Ellipse
                {
                    Width = circle_size,
                    Height = circle_size,
                    Fill = Brushes.Yellow,
                    Stroke = Brushes.Black
                };
                Ellipse bottom_circle = new Ellipse
                {
                    Width = circle_size,
                    Height = circle_size,
                    Fill = Brushes.Green,
                    Stroke = Brushes.Black
                };

                // Create a rectangle geometry to add
                Rectangle my_rectangle = new Rectangle
                {
                    Width = small_square,
                    Height = big_square,
                    Fill = Brushes.GhostWhite,
                    StrokeThickness = 1,
                    Stroke = Brushes.Black
                };


                TextBlock numbers = new TextBlock();
                numbers.Height = 20;
                numbers.Width = 30;
                numbers.Text = $"{item.GetMarker()}";
                numbers.TextAlignment = TextAlignment.Center;
                numbers.Background = Brushes.Black;
                numbers.Foreground = Brushes.White;

                top_circle.Tag = "Red";
                middle_circle.Tag = "Yellow";
                bottom_circle.Tag = "Green";


                Canvas.SetLeft(line, zero_position + 0.5 * small_square);
                Canvas.SetTop(line, big_square * 0.5);

                Canvas.SetLeft(my_rectangle, zero_position);
                figure_canvas.Children.Add(my_rectangle);

                Canvas.SetLeft(top_circle, zero_position + zero_circle);
                Canvas.SetTop(top_circle, 5);
                figure_canvas.Children.Add(top_circle);

                Canvas.SetLeft(middle_circle, zero_position + zero_circle);
                Canvas.SetTop(middle_circle, 30);
                figure_canvas.Children.Add(middle_circle);

                Canvas.SetLeft(bottom_circle, zero_position + zero_circle);
                Canvas.SetTop(bottom_circle, 55);
                figure_canvas.Children.Add(bottom_circle);

                Canvas.SetTop(numbers, 85);
                Canvas.SetLeft(numbers, zero_position);
                figure_canvas.Children.Add(numbers);

                Canvas.SetZIndex(figure_canvas, 1);
                Canvas.SetLeft(figure_canvas, derivation);
                Canvas.SetTop(figure_canvas, 20);

                figure_canvas.MouseLeftButtonDown += canvas_MouseLeftButtonDown;
                figure_canvas.MouseLeftButtonUp += canvas_MouseLeftButtonUp;
                
                figure_canvas.MouseMove += canvas_MouseMove;

                TestCanvas.Children.Add(figure_canvas);
                derivation += 30;
            }
        }
        private void canvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var line = (Line)sender;
            _isLineProg = true;
            _line = line;
            line.CaptureMouse();
        }


        private void canvas_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var line = (Line)sender;
            _isLineProg = false;
            line.ReleaseMouseCapture();
        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var canvas = (Canvas)sender;
            _isRectDragInProg = true;
            canvas.CaptureMouse();
        }


        private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var canvas = (Canvas)sender;
            _isRectDragInProg = false;
            canvas.ReleaseMouseCapture();
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            var canvas = (Canvas)sender;
            
            // get the position of the mouse relative to the Canvas
            var mousePos = e.GetPosition(TestCanvas);

            // center the rect on the mouse
            double left = mousePos.X;
            double top = mousePos.Y;

            if (canvas != null && canvas.IsMouseCaptured)
            {
                Canvas.SetLeft(canvas, left);
                Canvas.SetTop(canvas, top);
            }

            if (_line != null && _isLineProg)
            {
                var x = _line.TransformToVisual(TestCanvas);
                Point point_line = x.Transform(new Point(0, 0));
                _line.X2 = mousePos.X - point_line.X;
                _line.Y2 = mousePos.Y - point_line.Y;
            }
        }

        private async void ShowSimulation(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(ChangeState));
        }

        private void ChangeState()
        {
            List<StateRecord> current_state = new List<StateRecord>();
            current_state = DataHandler.GetData();

            IEnumerable<Canvas> all_traffic_lights = TestCanvas.Children.OfType<Canvas>();
            foreach (var item in current_state)
            {
                Canvas current = all_traffic_lights.First(x => x.Tag.ToString() == item.GetMarker());

                Ellipse red = current.Children.OfType<Ellipse>().First(x => x.Tag.ToString() == "Red");
                Ellipse yellow = current.Children.OfType<Ellipse>().First(x => x.Tag.ToString() == "Yellow");
                Ellipse green = current.Children.OfType<Ellipse>().First(x => x.Tag.ToString() == "Green");
                
                red.Fill = Brushes.Black;
                yellow.Fill = Brushes.Black;
                green.Fill = Brushes.Black;

                if (item.Traficligh_Type == 1)
                {
                    ColorParserRef(item.Traficligh_State, red, yellow, green);
                }

                if (item.Traficligh_Type == 2)
                {
                    Ellipse left = current.Children.OfType<Ellipse>().First(x => x.Tag.ToString() == "Left");
                    Ellipse right = current.Children.OfType<Ellipse>().First(x => x.Tag.ToString() == "Right");

                    List<int> state = item.Traficligh_State.ToString().Select(digit => int.Parse(digit.ToString())).ToList();

                    left.Fill = ColorParser(state[0]);
                    right.Fill = ColorParser(state[2]);

                    ColorParserRef(state[1], red, yellow, green);
                }
            }
        }

        private SolidColorBrush ColorParser(int color_int)
        {
            SolidColorBrush color = new SolidColorBrush();
            switch (color_int)
            {
                case 1:
                    color = Brushes.Red;
                    break;
                case 2:
                    color = Brushes.Yellow;
                    break;
                case 3:
                    color = Brushes.Green;
                    break;
                default:
                    break;
            }
            return color;
        }

        private void ColorParserRef(int color_int, Ellipse red, Ellipse yellow, Ellipse green)
        {
            switch (color_int)
            {
                case 1:
                    red.Fill = Brushes.Red;
                    break;
                case 2:
                    yellow.Fill = Brushes.Yellow;
                    break;
                case 3:
                    green.Fill = Brushes.Green;
                    break;
                default:
                    break;
            }
        }

        private void CreateTraffic(object sender, RoutedEventArgs e)
        {
            CreateCustomFigure();
        }

        private void PlayClick_Simulation(object sender, RoutedEventArgs e)
        {
            var enabled = _timer.Enabled;
            if (enabled)
            {
                _timer.Enabled = false;
            }
            else
            {
                _timer.Enabled = true;
            }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield return (T)Enumerable.Empty<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;
                if (ithChild is T t) yield return t;
                foreach (T childOfChild in FindVisualChildren<T>(ithChild)) yield return childOfChild;
            }
        }
        //    IEnumerable<Ellipse> circles = FindVisualChildren<Ellipse>(this).Where(x => x.Tag != null && x.Tag.ToString() == tagName);
    }
}
