#define My_Debug

using Gra.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gra
{
    public partial class Form1 : Form
    {
#if My_Debug
        int _cursX = 0;
        int _cursY = 0;
#endif
        CUfo _ufo;
        CWybuch _wybuch;
        CBord _bord;
        CRamka _ramka;

        public Form1()
        {
            InitializeComponent();
            //zakres obszaru
            Bitmap b = new Bitmap(Resources.Cel);
            this.Cursor = CustomCursor.CreateCursor(b, b.Height / 2, b.Width / 2);

            _ramka = new CRamka() { Left = 0, Top = 0 };
            _bord = new CBord() { Left = 340, Top = 10 };
            _ufo = new CUfo() { Left = 10, Top = 200 };
            _wybuch = new CWybuch() ;
        }

        private void timerGra_Tick(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;

            _bord.DrawImage(dc);
            _ramka.DrawImage(dc);

#if My_Debug
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font _font = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextRenderer.DrawText(dc, "X=" + _cursX.ToString() + ":" + "Y=" + _cursY.ToString(), _font,
            new Rectangle(0,0,120,20), SystemColors.ControlText, flags);
#endif
            _ufo.DrawImage(dc);

            base.OnPaint(e);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
#if My_Debug
            _cursX = e.X;
            _cursY = e.Y;
#endif
            Refresh(); //this.Refresh();
        }
    }
}
