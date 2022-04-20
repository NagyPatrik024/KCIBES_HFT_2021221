using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KCIBES_HFT_2021221.WpfClient
{
    public class display : FrameworkElement
    {
        Size size;
        public Brush brush { get { return new ImageBrush(new BitmapImage(new Uri("Images/track.jpg", UriKind.RelativeOrAbsolute))); } }

        public void Resize(Size size)
        {
            this.size = size;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            drawingContext.DrawRectangle(brush, new Pen(Brushes.Black, 0), new Rect(0, 0, size.Width, size.Height));
        }
    }
}
