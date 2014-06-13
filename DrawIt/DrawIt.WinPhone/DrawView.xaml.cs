using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawIt.WinPhone
{
    // Original Source: http://www.geekchamp.com/tips/drawing-in-wp7-2-drawing-shapes-with-finger
    public partial class DrawView
    {
        public Brush CurrentBrush { get; set; }

        public float PenWidth { get; set; }
        private Point CurrentPoint;
        private Point PreviousPoint;

        public DrawView()
        {
            InitializeComponent();

            CurrentBrush = new SolidColorBrush(Colors.Black);
            PenWidth = 5.0f;

            ContentPanelCanvas.MouseMove += ContentPanelCanvas_MouseMove;
            ContentPanelCanvas.MouseLeftButtonDown += ContentPanelCanvas_MouseLeftButtonDown;
        }

        void ContentPanelCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentPoint = e.GetPosition(this);
            PreviousPoint = CurrentPoint;
        }

        void ContentPanelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            CurrentPoint = e.GetPosition(ContentPanelCanvas);

            var line = new Line
            {
                X1 = CurrentPoint.X,
                Y1 = CurrentPoint.Y,
                X2 = PreviousPoint.X,
                Y2 = PreviousPoint.Y,
                Stroke = CurrentBrush,
                StrokeThickness = PenWidth
            };

            ContentPanelCanvas.Children.Add(line);

            PreviousPoint = CurrentPoint;
        }
    }
}
