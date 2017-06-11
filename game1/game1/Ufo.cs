using game1.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1
{
    class Ufo : CImageBase
    {
        private Rectangle _ufoHotSpot = new Rectangle();

        public Ufo()
            :base(Properties.Resources.Ufo)
        {
            _ufoHotSpot.X = Left + 20;
            _ufoHotSpot.Y = Top - 1;
            _ufoHotSpot.Width = 30;
            _ufoHotSpot.Height = 40;
        }
        

        public static object Resources { get; private set; }
        public int Left { get; internal set; }
        public int Top { get; internal set; }

        public void Update( int X, int Y)
        {
            Left = X;
            Top = Y;
            _ufoHotSpot.X = Left + 20;
            _ufoHotSpot.Y = Top - 1;
        }
        public bool Hit (int X, int Y)
        {
            Rectangle c = new Rectangle(X, Y, 1, 1);
            if(_ufoHotSpot.Contains(c))
            {
                return true;
            }
            return false;
        }

        internal void DrawImage(Graphics dc)
        {
            throw new NotImplementedException();
        }
    }
}
