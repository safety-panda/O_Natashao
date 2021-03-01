using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using GUIImageArray;

namespace O_Natashao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            showGUI();
        }

        GImageArray GCheckerBoard;

        int[,] checkerBoard = new int[8, 8];


        private int[,] infinateBoard()
        {
            for (int row = 0; row <= 7; row++)
            {
                for (int col = 0; col <= 7; col++)
                {
                    if ((col == 0) && (row == 0))
                        checkerBoard[row, col] = 0;
                    else
                        if (col > 0)
                            if (checkerBoard[row, col - 1] == 1)
                                checkerBoard[row, col] = 0;
                            else
                                checkerBoard[row, col] = 1;
                    if (row > 0)
                        if (checkerBoard[row - 1, col] == 1)
                            checkerBoard[row, col] = 0;
                        else
                            checkerBoard[row, col] = 1;
                }
            }
            return checkerBoard;
        }

        private void showGUI()
        {
            string path = Directory.GetCurrentDirectory() + "\\images\\";
            infinateBoard();

            GCheckerBoard = new GImageArray(this, checkerBoard, 50, 50, 50, 50, 0, path);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            infinateBoard();

            for (int row = 0; row <= 7; row++)
            {
                for (int col = 0; col <= 7; col++)
                {
                    if (checkerBoard[row, col] == 1)
                    {
                        if (col == 7)
                            checkerBoardText.AppendText("1" + Environment.NewLine);
                        else
                            checkerBoardText.AppendText("1");
                    }
                    else
                    { 
                        if (col == 7)
                            checkerBoardText.AppendText("0" + Environment.NewLine);
                        else
                            checkerBoardText.AppendText("0");
                    }
                }
            }
        }
    }
}
