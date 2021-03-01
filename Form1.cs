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

            // this shows the GUI board when the form opens
            showGUI();
        }

        // here we create the checker board object
        GImageArray GCheckerBoard;

        // this is the 2D array
        int[,] checkerBoard = new int[8, 8];

        //// this creates an infinate board to test
        //private int[,] infinateBoard()
        //{
        //    for (int row = 0; row <= 7; row++)
        //    {
        //        for (int col = 0; col <= 7; col++)
        //        {
        //            if ((col == 0) && (row == 0))
        //                checkerBoard[row, col] = 0;
        //            else
        //                if (col > 0)
        //                    if (checkerBoard[row, col - 1] == 1)
        //                        checkerBoard[row, col] = 0;
        //                    else
        //                        checkerBoard[row, col] = 1;
        //            if (row > 0)
        //                if (checkerBoard[row - 1, col] == 1)
        //                    checkerBoard[row, col] = 0;
        //                else
        //                    checkerBoard[row, col] = 1;
        //        }
        //    }
        //    return checkerBoard;
        //}

        private int[,] startingBoard()
        {
            for (int row = 0; row <= 7; row++)
            {
                for (int col = 0; col <= 7; col++)
                {
                    if (((row == 3) && (col == 3)) || ((row == 4) && (col == 4)))
                    {
                        // sets player one starting tokens 
                        // WHITE tokens
                        checkerBoard[row, col] = 1;
                    }
                    else if (((row == 3) && (col == 4)) || ((row == 4) && (col == 3)))
                    {
                        // sets player two staring tokens
                        // BLACK tokens
                        checkerBoard[row, col] = 0;
                    }
                    else
                    {
                        // sets all other game spaces to blank
                        checkerBoard[row, col] = 10;
                    }
                }
            }
            return checkerBoard;
        }

        private void Which_Element_Clicked(object sender, EventArgs e)
        {
            int row = GCheckerBoard.Get_Row(sender);
            int col = GCheckerBoard.Get_Row(sender);
        }

        private void showGUI()
        {
            string path = Directory.GetCurrentDirectory() + "\\images\\";

            startingBoard();

            GCheckerBoard = new GImageArray(this, checkerBoard, 50, 50, 100, 50, 0, path);
            GCheckerBoard.Which_Element_Clicked += new GImageArray.ImageClickedEventHandler(Which_Element_Clicked);
        }

        // this button outputs the array values into a text box
        private void button1_Click(object sender, EventArgs e)
        {
        //    infinateBoard();

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
