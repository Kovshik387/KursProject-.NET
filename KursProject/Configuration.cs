using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProject
{
    public class Configuration
    {
        public static Pen SelectedPen = new(Color.SkyBlue)
        {
            Width = 5,
            EndCap = LineCap.ArrowAnchor,
        };

        public static Pen SelectedMiddle = new(Color.SkyBlue)
        {
            Width = 5,
            CustomEndCap = new AdjustableArrowCap(3, 4),
        };

        public static Pen selectedPen = new(Color.Black)
        {
            Width = 3,
        };

        public static Pen EdgePen = new(Color.DarkGray)
        {
            Width = 5,
            EndCap = LineCap.ArrowAnchor,
        };

        public static Pen MiddleEdgePen = new(Color.DarkGray)
        {
            Width = 6,
            //EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor,
            CustomEndCap = new AdjustableArrowCap(3, 4),
        };

        public static Font font = new Font("Times New Roman", 15);
        public static Brush brush = Brushes.Black;
        public static Brush insidebrush = Brushes.White;
        public static Brush SelectedBrush = Brushes.SkyBlue;
        public static Brush StartCycle = Brushes.RoyalBlue;
    }
}
