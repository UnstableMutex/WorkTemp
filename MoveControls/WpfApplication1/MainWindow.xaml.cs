using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Thumb_OnDragDelta(object sender, DragDeltaEventArgs e)
        {

            var move = new Vector(e.HorizontalChange, e.VerticalChange);
            MoveOnCanvas(thumbTarget, move);
        }

        void MoveOnCanvas(UIElement control, Vector move)
        {
            Canvas.SetLeft(control, Canvas.GetLeft(control) + move.X);
            Canvas.SetTop(control, Canvas.GetTop(control) + move.Y);
        }

    
    }
}
