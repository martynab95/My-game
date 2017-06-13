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

        private int _startX;//ptk poczatkowy tablicy
        private int _startY;

        private int _elementSize;
        private int[,] _gameMatrix;

        private int _carX; //pozycja auta w czasie
        private int _carY;

        private Random _random;
        private int _myCarPostition;

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

            _carX = _carY = 0;

            _gameMatrix = new int[_row, _col];
            ResetGameBoard();

            _random = new Random();
            _myCarPostition = 0;
        
            DrawAGra(  12, _myCarPostition, 2);
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
                    g.DrawRectangle(new Pen(Brushes.BlueViolet), _startX + j * _elementSize, _startY + i * _elementSize, _elementSize, _elementSize);
                    if (_gameMatrix[i,j]==1)
                    {
                        g.FillRectangle(Brushes.Pink, _startX + j * _elementSize, _startY + i * _elementSize, _elementSize, _elementSize);
         
                    }
                    if (_gameMatrix[i, j] == 2)
                    {
                        g.FillRectangle(Brushes.Silver, _startX + j * _elementSize, _startY + i * _elementSize, _elementSize, _elementSize);
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
            DrawAPoint(x, y + 1, value);
            DrawAPoint(x+1,y+1, value);
            DrawAPoint(x + 2, y + 1, value);
            DrawAPoint(x +3, y + 1, value);
            DrawAPoint(x +1, y , value);
            DrawAPoint(x + 1, y + 2, value);
            DrawAPoint(x + 3, y, value);
            DrawAPoint(x + 3, y + 2, value);
            
        }

        private void DrawAPoint(int x, int y, int value)
        {
            if(x < _row && x >= 0 && y< _col && y >= 0)
            {
                _gameMatrix[x, y] = value;
            }
        }
        #endregion

        private void tmrGra_Tick(object sender, EventArgs e)
        {
            ResetGameBoard();
            DrawAGra(12, _myCarPostition, 2);
            DrawAGra(_carX, _carY, 1);
            Invalidate();

            _carX++;
            if( _carX == _row)
            {
                _carX = 0;
                _carY = _random.Next() % 2 == 0 ? 0 : 3;
            }
            CheckGame();
        }
        private void CheckGame()
        {
            if(_carX+3> 12 && _carY == _myCarPostition)
            {
                tmrGra.Enabled = false;
            }
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Left && _myCarPostition==3)
            {
                _myCarPostition = 0;
            }
            else if(e.KeyCode==Keys.Right && _myCarPostition == 0)
            {
                _myCarPostition = 3;
            }
        }
    }
}
