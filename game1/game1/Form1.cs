#define My_Debug
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game1
{
    public partial class Form1 : Form
    {
        int _cursX = 0;
        int _cursY = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;

            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font _font = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextRenderer.DrawText(e.Graphics, "X=" + _cursX.ToString() + ":" + "Y=" + _cursY.ToString(), _font, 
                new Rectangle(0, 0, 120, 20), SystemColors.ControlText, flags);

            base.OnPaint(e);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            _cursX = e.X;
            _cursY = e.Y;

            this.Refresh();
        }
    }
}
