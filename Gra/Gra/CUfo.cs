using Gra.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    class CUfo : CImageBase
    {
        private Rectangle _ufoHotSpot = new Rectangle();

        public CUfo()
            : base(Resources.Ufo)
        {
            _ufoHotSpot.X = Left + 20;
            _ufoHotSpot.Y = Top - 1;
            _ufoHotSpot.Width = 30;
            _ufoHotSpot.Height = 40;
        }
       

        public void Update(int X, int Y)
        {
            Left = X;
            Top = Y;
            _ufoHotSpot.X = Left + 20;
            _ufoHotSpot.Y = Top - 1;
        }
        public bool Hit(int X, int Y)
        {
            Rectangle c = new Rectangle(X, Y, 1, 1);

            if(_ufoHotSpot.Contains(c))
            {
                return true;
            }
            return false;
        }
    }
}
