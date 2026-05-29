using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace POEChatBotApplication
{
    public partial class SplashScreen : Window
    {
        private DispatcherTimer _timer;
        private double _progressAngle = 0;

        public SplashScreen()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(20);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _progressAngle += 3;
            if (_progressAngle >= 360)
            {
                _timer.Stop();
                MainWindow main = new MainWindow(); // or your actual main window
                main.Show();
                this.Close();
                return;
            }

            double radians = (_progressAngle - 90) * Math.PI / 180.0;
            double x = 100 + 90 * Math.Cos(radians);
            double y = 100 + 90 * Math.Sin(radians);

            ProgressArcSegment.Point = new Point(x, y);
            ProgressArcSegment.IsLargeArc = _progressAngle >= 180;
        }
    }
}
