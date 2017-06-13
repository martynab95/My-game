using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gra2
{
    public partial class Form1 : Form
    {
        #region Fields

        private int _row;
        private int _col;

        private int _startX;
        private int _startY;

        private int _elementSize;
        private int[,] _gameMatrix;

        #endregion

        public Form1()
        {
            InitializeComponent();

            InitializeGame();

            DrawAGra(0, 0, 1);



        }

        private void InitializeGame()
        {
            _row = 16; 
            _col = 6;
            _startX = 50;
            _startY = 50;
            _elementSize = 15;

            _gameMatrix = new int[_row, _col];
            ResetGameBoard();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawGameBoard(e.Graphics);
        }
        private void DrawGameBoard(Graphics g)
        {
            for (int i = 0; i< _row; i++)
            {
                for(int j=0; j< _col; j++)
                {
                    g.DrawRectangle(new Pen(Brushes.Pink), _startX + j * _elementSize, _startY + i * _elementSize, _elementSize, _elementSize);
                    if (_gameMatrix[i,j]==1)
                    {
                        g.FillRectangle(Brushes.BlueViolet, _startX + j * _elementSize, _startY + i * _elementSize, _elementSize, _elementSize);
         
                    }
                    if (_gameMatrix[i, j] == 2)
                    {
                        g.FillRectangle(Brushes.Red, _startX + j * _elementSize, _startY + i * _elementSize, _elementSize, _elementSize);
                    }
                    }
            }
        }
        #region Functions
        private void ResetGameBoard()
        {
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _col; j++)
                {
                    _gameMatrix[i, j] = 0;
                }
            }
        }
        private void DrawAGra(int x, int y, int value)
        {
            _gameMatrix[0, 1] = value;
        }
        #endregion
    }
}
