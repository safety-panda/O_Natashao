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

            newGame();
        }

        // here we create the checker board object
        GImageArray GCheckerBoard;

        // this is the 2D array
        int[,] checkerBoard = new int[8, 8];

        // sets up players 
        // p1 | TRUE | white
        // p2 | FALSE | black
        bool currentPlayer;
        int playerToken;
        int opponentToken;

        private void showGUI()
        {
            string path = Directory.GetCurrentDirectory() + "\\images\\";


            //infinateBoard();

            //scoreCounter();

            GCheckerBoard = new GImageArray(this, checkerBoard, 50, 50, 100, 50, 0, path);
            GCheckerBoard.Which_Element_Clicked += new GImageArray.ImageClickedEventHandler(Which_Element_Clicked);
        }

        private void Which_Element_Clicked(object sender, EventArgs e)
        {
            int row = GCheckerBoard.Get_Row(sender);
            int col = GCheckerBoard.Get_Col(sender);

            if (availableSpace(row, col) == true)
            {
                if (nextToOpponent(row, col) == true)
                {
                    // this is a flank validator
                    // it checks the directional flanks
                    // if any of then are true the play can go ahead
                    bool flank = false;

                    bool flankN = checkNorth(row, col);
                    bool flankNE = checkNE(row, col);
                    bool flankE = checkEast(row, col);
                    bool flankSE = checkSE(row, col);
                    bool flankS = checkSouth(row, col);
                    bool flankSW = checkSW(row, col);
                    bool flankW = checkWest(row, col);
                    bool flankNW = checkNW(row, col);

                    if (flankN == true || flankNE == true || flankE == true || flankSE == true || flankS == true || flankSW == true || flankW == true || flankNW == true)
                        flank = true;

                    if (flank == true)
                    {
                        placeToken(row, col);
                        scoreCounter();
                        swapPlayer(currentPlayer);
                        GCheckerBoard.UpDateImages(checkerBoard);
                        flank = false;
                    }
                    else
                    {
                        MessageBox.Show("Nope - not there" + Environment.NewLine + "You must flank your opponent");
                    }
                }
                else
                {
                    MessageBox.Show("Nope - not there" + Environment.NewLine + "This space is not next to your opponent");
                }

            }
            else
            {
                MessageBox.Show("Nope - not there" + Environment.NewLine + "This space is not available");
            }
        }

        private bool currentPlayerSettings(bool player)
        {
            if (player == true)
            {
                currentPlayer = true;
                playerToken = 1;
                opponentToken = 0;
                p1ToPlayImage.Visible = true;
                p2ToPlayImage.Visible = false;
            }
            else if (player == false)
            {
                currentPlayer = false;
                playerToken = 0;
                opponentToken = 1;
                p1ToPlayImage.Visible = false;
                p2ToPlayImage.Visible = true;
            }
            return currentPlayer;
        }

        private void swapPlayer(bool justPlayed)
        {
            if (justPlayed == true)
            {
                currentPlayerSettings(false);
            }
            else if (justPlayed == false)
            {
                currentPlayerSettings(true);
            }
        }

        private void newGame()
        {
            currentPlayerSettings(true);
            startingBoard();
            scoreCounter();
            GCheckerBoard.UpDateImages(checkerBoard);
        }

        private void saveGame()
        {
            string applicatonPath = Directory.GetCurrentDirectory() + "\\";

            StreamWriter gameOutputStream = File.CreateText(applicatonPath + "MyFile.txt");

            // this function writes the checkerboard to a textbox
            currentBoard();

            // first the file saves the player names
            gameOutputStream.WriteLine(p1NameBox.Text);
            gameOutputStream.WriteLine(p2NameBox.Text);

            // then it saves whose go it is
            // this is a boolean so it it converted to string
            gameOutputStream.WriteLine(currentPlayer.ToString());

            // then it saves the array from the textbox
            gameOutputStream.Write(checkerBoardText.Text);

            // then the file is closed
            gameOutputStream.Close();
        }

        private void loadGame()
        {
            string lineOfText;
            string applicatonPath = Directory.GetCurrentDirectory() + "\\";
            string[] loadRow = new string[8];
            int rowIndex = 0;

            StreamReader gameInputStream = File.OpenText(applicatonPath + "MyFile.txt");

            //playerline.text.inputsteamreadline();
            //playertwo.text.input.readlien
            //current plau

            // when reading the file the player names are read first
            p1NameBox.Text = gameInputStream.ReadLine();
            p2NameBox.Text = gameInputStream.ReadLine();

            // reads whose turn it is
            // this variable is boolean to the string is converted
            currentPlayer = Convert.ToBoolean(gameInputStream.ReadLine());

            // finally the rest of the file reads to populate the checkerboard array
            lineOfText = gameInputStream.ReadLine();
            while (lineOfText != null)
            {
                // for loop populates the row list
                loadRow = lineOfText.Split(',');

                //for (int i = 0; i > 7; i++)
                //{
                //    loadRow.Add(lineOfText[i]);
                //}

                // loops through the list and adds values to the array
                for (int col = 0; col <= 7; col++)
                {
                    checkerBoard[rowIndex, col] = Convert.ToInt32(loadRow[col]);
                }


                // this moves the reader on to the next line of the array
                lineOfText = gameInputStream.ReadLine();

                // moves the row on to the next row for the next loop
                rowIndex++;
            }



            // closes the game load
            gameInputStream.Close();

            
            

            // set up the interface
            scoreCounter();
            currentPlayerSettings(currentPlayer);
            GCheckerBoard.UpDateImages(checkerBoard);
        }

        // this creates an infinate board to test
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

        // this function turns the array into lines of text to save
        private void currentBoard()
        {
            for (int row = 0; row <= 7; row++)
            {
                for (int col = 0; col <= 7; col++)
                {
                    if (checkerBoard[row, col] == 1)
                    {
                        if (col == 7)
                            checkerBoardText.AppendText("1," + Environment.NewLine);
                        else
                            checkerBoardText.AppendText("1,");
                    }
                    else if (checkerBoard[row, col] == 0)
                    {
                        if (col == 7)
                            checkerBoardText.AppendText("0," + Environment.NewLine);
                        else
                            checkerBoardText.AppendText("0,");
                    }
                    else if (checkerBoard[row, col] == 10)
                    {
                        if (col == 7)
                            checkerBoardText.AppendText("10," + Environment.NewLine);
                        else
                            checkerBoardText.AppendText("10,");
                    }
                    else
                    {
                        if (col == 7)
                            checkerBoardText.AppendText("?" + Environment.NewLine);
                        else
                            checkerBoardText.AppendText("?");
                    }
                }
            }

        }

        private void scoreCounter()
        {
            // sets the values to zero before counting
            int p1Tokens = 0, p2Tokens = 0, emptySquares = 0;

            for (int row = 0; row <= 7; row++)
            {
                for (int col = 0; col <= 7; col++)
                {
                    if (checkerBoard[row, col] == 1)
                    {
                        p1Tokens++;
                    }
                    else if (checkerBoard[row, col] == 0)
                    {
                        p2Tokens++;
                    }
                    else
                    {
                        emptySquares++;
                    }
                }
            }

            p1CountersLabel.Text = p1Tokens.ToString();
            p2CountersLabel.Text = p2Tokens.ToString();

        }


        // checks the selected space is marked with a '10'
        // which indicates the space is empty / available
        private bool availableSpace(int row, int col)
        {
            if (checkerBoard[row, col] == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // Uses the below directional checks to see if the selected space
        // is next to an opponent's token
        private bool nextToOpponent(int row, int col)
        {
            if ((oppN(row, col) == true) || (oppNE(row, col) == true) || (oppE(row, col) == true) || (oppSE(row, col) == true) || (oppS(row, col) == true) || (oppSW(row, col) == true) || (oppW(row, col) == true) || (oppNW(row, col) == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // Below are directional checks to see if the selected space
        // is next to an opponenets token
        // they all catch the exception thrown by board edge

        private bool oppN(int row, int col)
        {
            // this func checks if the tile above is the opponent
            try
            {
                if (checkerBoard[row - 1, col] == opponentToken)
                    return true;
                else
                    return false;
            }
            catch (IndexOutOfRangeException)
            {
                //if the above is out of the board it returns false
                return false;
            }
        }

        private bool oppNE(int row, int col)
        {
            // this func checks if the tile above/right is the opponent
            try
            {
                if (checkerBoard[row - 1, col + 1] == opponentToken)
                    return true;
                else
                    return false;
            }
            catch (IndexOutOfRangeException)
            {
                //if the above/right is out of the board it returns false
                return false;
            }
        }

        private bool oppE(int row, int col)
        {
            // this func checks if the tile to the right is the opponent
            try
            {
                if (checkerBoard[row, col + 1] == opponentToken)
                    return true;
                else
                    return false;
            }
            catch (IndexOutOfRangeException)
            {
                //if the right is out of the board it returns false
                return false;
            }
        }

        private bool oppSE(int row, int col)
        {
            // this func checks if the tile to the below/right is the opponent
            try
            {
                if (checkerBoard[row + 1, col + 1] == opponentToken)
                    return true;
                else
                    return false;
            }
            catch (IndexOutOfRangeException)
            {
                //if the below/right is out of the board it returns false
                return false;
            }
        }

        private bool oppS(int row, int col)
        {
            // this func checks if the tile below is the opponent
            try
            {
                if (checkerBoard[row + 1, col] == opponentToken)
                    return true;
                else
                    return false;
            }
            catch (IndexOutOfRangeException)
            {
                //if the below is out of the board it returns false
                return false;
            }
        }

        private bool oppSW(int row, int col)
        {
            // this func checks if the tile below/left is the opponent
            try
            {
                if (checkerBoard[row + 1, col - 1] == opponentToken)
                    return true;
                else
                    return false;
            }
            catch (IndexOutOfRangeException)
            {
                //if the below/left is out of the board it returns false
                return false;
            }
        }

        private bool oppW(int row, int col)
        {
            // this func checks if the tile to the left is the opponent
            try
            {
                if (checkerBoard[row, col - 1] == opponentToken)
                    return true;
                else
                    return false;
            }
            catch (IndexOutOfRangeException)
            {
                //if the left is out of the board it returns false
                return false;
            }
        }

        private bool oppNW(int row, int col)
        {
            // this func checks if the tile to the above/left is the opponent
            try
            {
                if (checkerBoard[row - 1, col - 1] == opponentToken)
                    return true;
                else
                    return false;
            }
            catch (IndexOutOfRangeException)
            {
                //if the above/left is out of the board it returns false
                return false;
            }
        }


        // here are directional checks for flanking
        // each function contains the logic to flip flanked tokens

        private bool checkNorth(int row, int col)
        {
            bool flankNorth;
            int newRow = row - 1;

            // lists for the tokens to flip
            List<int> listRow = new List<int>();
            List<int> listCol = new List<int>();

            // this loop checks to see if the next tile is within bounds 
            // and not the players token
            // then it make makes a list of the opponents tiles it passes
            // the else catches any non-flank and clears the lists
            while (newRow > -1)
            {
                // if the new tile is empty stop the loop and clear the lists
                if (checkerBoard[newRow, col] == 10)
                {
                    listRow.Clear();
                    listCol.Clear();
                    break;
                }

                // options for if it is the players token
                else if (checkerBoard[newRow, col] == playerToken)
                {
                    // if there is nothing in the list it is not a flank
                    if (listRow.Count == 0)
                    {
                        listRow.Clear();
                        listCol.Clear();
                        break;
                    }

                    // if there is items in the list it is a flank
                    // break the loop so the tiles can be flipped
                    else
                    {
                        break;
                    }
                }

                // options for if it is the opponenets token
                if (checkerBoard[newRow, col] == opponentToken)
                {
                    // if it is on the edge of the board it not a flank
                    if (newRow == 0)
                    {
                        listRow.Clear();
                        listCol.Clear();
                        break;
                    }

                    // if it is not on the edge add to list and keep looping
                    else
                    {
                        listRow.Add(newRow);
                        listCol.Add(col);
                        newRow--;
                    }
                }

            }

            // flip tiles if the list is not empty
            if (listRow.Count > 0)
            {
                for (int i = 0; i < listRow.Count; i++)
                {
                    placeToken(listRow[i], listCol[i]);
                }
                placeToken(row, col);
                flankNorth = true;
            }
            else
                flankNorth = false;

            return flankNorth;
        }

        private bool checkNE(int row, int col)
        {
            bool flankNE;
            int newRow = row - 1;
            int newCol = col + 1;

            // lists for the tokens to flip
            List<int> listRow = new List<int>();
            List<int> listCol = new List<int>();

            // this loop checks to see if the next tile is within bounds 
            // and not the players token
            // then it make makes a list of the opponents tiles it passes
            // the else catches any non-flank and clears the lists
            while ((newRow > -1) && (newCol < 8))
            {
                // if the new tile is empty stop the loop and clear the lists
                if (checkerBoard[newRow, newCol] == 10)
                {
                    listRow.Clear();
                    listCol.Clear();
                    break;
                }

                // options for if it is the players token
                else if (checkerBoard[newRow, newCol] == playerToken)
                {
                    // if there is nothing in the list it is not a flank
                    if (listRow.Count == 0)
                    {
                        listRow.Clear();
                        listCol.Clear();
                        break;
                    }

                    // if there is items in the list it is a flank
                    // break the loop so the tiles can be flipped
                    else
                    {
                        break;
                    }
                }

                // options for if it is the opponenets token
                if (checkerBoard[newRow, newCol] == opponentToken)
                {
                    // if it is on the edge of the board it not a flank
                    if ((newRow == 0) || (newCol == 7))
                    {
                        listRow.Clear();
                        listCol.Clear();
                        break;
                    }

                    // if it is not on the edge add to list and keep looping
                    else
                    {
                        listRow.Add(newRow);
                        listCol.Add(newCol);
                        newRow--;
                        newCol++;
                    }
                }

            }

            // flip tiles if the list is not empty
            if (listRow.Count > 0)
            {
                for (int i = 0; i < listRow.Count; i++)
                {
                    placeToken(listRow[i], listCol[i]);
                }
                placeToken(row, col);
                flankNE = true;
            }
            else
                flankNE = false;

            return flankNE;
        }

        private bool checkEast(int row, int col)
        {
            bool flankEast;
            int newCol = col + 1;

            // lists for the tokens to flip
            List<int> listRow = new List<int>();
            List<int> listCol = new List<int>();

            // this loop checks to see if the next tile is within bounds 
            // and not the players token
            // then it make makes a list of the opponents tiles it passes
            // the else catches any non-flank and clears the lists
            while (newCol < 8)
            {
                // if the new tile is empty stop the loop and clear the lists
                if (checkerBoard[row, newCol] == 10)
                {
                    listRow.Clear();
                    listCol.Clear();
                    break;
                }

                // options for if it is the players token
                else if (checkerBoard[row, newCol] == playerToken)
                {
                    // if there is nothing in the list it is not a flank
                    if (listRow.Count == 0)
                    {
                        listRow.Clear();
                        listCol.Clear();
                        break;
                    }

                    // if there is items in the list it is a flank
                    // break the loop so the tiles can be flipped
                    else
                    {
                        break;
                    }
                }

                // options for if it is the opponenets token
                if (checkerBoard[row, newCol] == opponentToken)
                {
                    // if it is on the edge of the board it not a flank
                    if (newCol == 7)
                    {
                        listRow.Clear();
                        listCol.Clear();
                        break;
                    }

                    // if it is not on the edge add to list and keep looping
                    else
                    {
                        listRow.Add(row);
                        listCol.Add(newCol);
                        newCol++;
                    }
                }

            }

            // if the list is not empty flip the tiles
            if (listRow.Count > 0)
            {
                for (int i = 0; i < listRow.Count; i++)
                {
                    placeToken(listRow[i], listCol[i]);
                }
                placeToken(row, col);
                flankEast = true;
            }
            else
                flankEast = false;

            return flankEast;
        }

        private bool checkSE(int row, int col)
        {
            bool flankSE;
            int newRow = row + 1;
            int newCol = col + 1;

            // lists for the tokens to flip
            List<int> listRow = new List<int>();
            List<int> listCol = new List<int>();

            // this loop checks to see if the next tile is within bounds 
            // and not the players token
            // then it make makes a list of the opponents tiles it passes
            // the else catches any non-flank and clears the lists
            while ((newRow < 8) && (newCol < 8))
            {
                // if the new tile is empty stop the loop and clear the lists
                if (checkerBoard[newRow, newCol] == 10)
                {
                    listRow.Clear();
                    listCol.Clear();
                    break;
                }

                // options for if it is the players token
                else if (checkerBoard[newRow, newCol] == playerToken)
                {
                    // if there is nothing in the list it is not a flank
                    if (listRow.Count == 0)
                    {
                        listRow.Clear();
                        listCol.Clear();
                        break;
                    }

                    // if there is items in the list it is a flank
                    // break the loop so the tiles can be flipped
                    else
                    {
                        break;
                    }
                }

                // options for if it is the opponenets token
                if (checkerBoard[newRow, newCol] == opponentToken)
                {
                    // if it is on the edge of the board it not a flank
                    if ((newRow == 7) || (newCol == 7))
                    {
                        listRow.Clear();
                        listCol.Clear();
                        break;
                    }

                    // if it is not on the edge add to list and keep looping
                    else
                    {
                        listRow.Add(newRow);
                        listCol.Add(newCol);
                        newRow++;
                        newCol++;
                    }
                }

            }


            if (listRow.Count > 0)
            {
                for (int i = 0; i < listRow.Count; i++)
                {
                    placeToken(listRow[i], listCol[i]);
                }
                placeToken(row, col);
                flankSE = true;
            }
            else
                flankSE = false;

            return flankSE;
        }

        private bool checkSouth(int row, int col)
        {
            bool flankSouth;
            int newRow = row + 1;

            // lists for the tokens to flip
            List<int> listRow = new List<int>();
            List<int> listCol = new List<int>();

            // this loop checks to see if the next tile is within bounds 
            // and not the players token
            // then it make makes a list of the opponents tiles it passes
            // the else catches any non-flank and clears the lists
            while (newRow < 8)
            {
                // if the new tile is empty stop the loop and clear the lists
                if (checkerBoard[newRow, col] == 10)
                {
                    listRow.Clear();
                    listCol.Clear();
                    break;
                }

                // options for if it is the players token
                else if (checkerBoard[newRow, col] == playerToken)
                {
                    // if there is nothing in the list it is not a flank
                    if (listRow.Count == 0)
                    {
                        listRow.Clear();
                        listCol.Clear();
                        break;
                    }

                    // if there is items in the list it is a flank
                    // break the loop so the tiles can be flipped
                    else
                    {
                        break;
                    }
                }

                // options for if it is the opponenets token
                if (checkerBoard[newRow, col] == opponentToken)
                {
                    // if it is on the edge of the board it not a flank
                    if (newRow == 7)
                    {
                        listRow.Clear();
                        listCol.Clear();
                        break;
                    }

                    // if it is not on the edge add to list and keep looping
                    else
                    {
                        listRow.Add(newRow);
                        listCol.Add(col);
                        newRow++;
                    }
                }

            }


            if (listRow.Count > 0)
            {
                for (int i = 0; i < listRow.Count; i++)
                {
                    placeToken(listRow[i], listCol[i]);
                }
                placeToken(row, col);
                flankSouth = true;
            }
            else
                flankSouth = false;

            return flankSouth;
        }


        private bool checkSW(int row, int col)
        {
            bool flankSW;
            int newRow = row + 1;
            int newCol = col - 1;

            // lists for the tokens to flip
            List<int> listRow = new List<int>();
            List<int> listCol = new List<int>();


            // this loop checks to see if the next tile is within bounds 
            // and not the players token
            // then it make makes a list of the opponents tiles it passes
            // the else catches any non-flank and clears the lists
            while ((newRow < 8) && (newCol > -1))
            {
                // if the new tile is empty stop the loop and clear the lists
                if (checkerBoard[newRow, newCol] == 10)
                {
                    listRow.Clear();
                    listCol.Clear();
                    break;
                }

                // options for if it is the players token
                else if (checkerBoard[newRow, newCol] == playerToken)
                {
                    // if there is nothing in the list it is not a flank
                    if (listRow.Count == 0)
                    {
                        listRow.Clear();
                        listCol.Clear();
                        break;
                    }

                    // if there is items in the list it is a flank
                    // break the loop so the tiles can be flipped
                    else
                    {
                        break;
                    }
                }

                // options for if it is the opponenets token
                if (checkerBoard[newRow, newCol] == opponentToken)
                {
                    // if it is on the edge of the board it not a flank
                    if ((newRow == 7) || (newCol == 0))
                    {
                        listRow.Clear();
                        listCol.Clear();
                        break;
                    }

                    // if it is not on the edge add to list and keep looping
                    else
                    {
                        listRow.Add(newRow);
                        listCol.Add(newCol);
                        newRow++;
                        newCol--;
                    }
                }

            }

            // if the list is not empty flip the tiles stored
            if (listRow.Count > 0)
            {
                for (int i = 0; i < listRow.Count; i++)
                {
                    placeToken(listRow[i], listCol[i]);
                }
                placeToken(row, col);
                flankSW = true;
            }
            else
                flankSW = false;

            return flankSW;
        }


        private bool checkWest(int row, int col)
        {
            bool flankWest;
            int newCol = col - 1;

            // lists for the tokens to flip
            List<int> listRow = new List<int>();
            List<int> listCol = new List<int>();

            // this loop checks to see if the next tile is within bounds 
            // and not the players token
            // then it make makes a list of the opponents tiles it passes
            // the else catches any non-flank and clears the lists
            while (newCol > -1)
            {
                // if the new tile is empty stop the loop and clear the lists
                if (checkerBoard[row, newCol] == 10)
                {
                    listRow.Clear();
                    listCol.Clear();
                    break;
                }

                // options for if it is the players token
                else if (checkerBoard[row, newCol] == playerToken)
                {
                    // if there is nothing in the list it is not a flank
                    if (listRow.Count == 0)
                    {
                        listRow.Clear();
                        listCol.Clear();
                        break;
                    }

                    // if there is items in the list it is a flank
                    // break the loop so the tiles can be flipped
                    else
                    {
                        break;
                    }
                }

                // options for if it is the opponenets token
                if (checkerBoard[row, newCol] == opponentToken)
                {
                    // if it is on the edge of the board it not a flank
                    if (newCol == 0)
                    {
                        listRow.Clear();
                        listCol.Clear();
                        break;
                    }

                    // if it is not on the edge add to list and keep looping
                    else
                    {
                        listRow.Add(row);
                        listCol.Add(newCol);
                        newCol--;
                    }
                }

            }

            // if the list isn't empty flip the tiles
            if (listRow.Count > 0)
            {
                for (int i = 0; i < listRow.Count; i++)
                {
                    placeToken(listRow[i], listCol[i]);
                }
                placeToken(row, col);
                flankWest = true;
            }
            else
                flankWest = false;

            return flankWest;
        }

        private bool checkNW(int row, int col)
        {
            bool flankNW;
            int newRow = row - 1;
            int newCol = col - 1;

            // lists for the tokens to flip
            List<int> listRow = new List<int>();
            List<int> listCol = new List<int>();


            // this loop checks to see if the next tile is within bounds 
            // and not the players token
            // then it make makes a list of the opponents tiles it passes
            // the else catches any non-flank and clears the lists
            while ((newRow > -1) && (newCol > -1))
            {
                // if the new tile is empty stop the loop and clear the lists
                if (checkerBoard[newRow, newCol] == 10)
                {
                    listRow.Clear();
                    listCol.Clear();
                    break;
                }

                // options for if it is the players token
                else if (checkerBoard[newRow, newCol] == playerToken)
                {
                    // if there is nothing in the list it is not a flank
                    if (listRow.Count == 0)
                    {
                        listRow.Clear();
                        listCol.Clear();
                        break;
                    }

                    // if there is items in the list it is a flank
                    // break the loop so the tiles can be flipped
                    else
                    {
                        break;
                    }
                }

                // options for if it is the opponenets token
                if (checkerBoard[newRow, newCol] == opponentToken)
                {
                    // if it is on the edge of the board it not a flank
                    if ((newRow == 0) || (newCol == 0))
                    {
                        listRow.Clear();
                        listCol.Clear();
                        break;
                    }

                    // if it is not on the edge add to list and keep looping
                    else
                    {
                        listRow.Add(newRow);
                        listCol.Add(newCol);
                        newRow--;
                        newCol--;
                    }
                }

            }

            // if the list is not empty flip the tiles 
            if (listRow.Count > 0)
            {
                for (int i = 0; i < listRow.Count; i++)
                {
                    placeToken(listRow[i], listCol[i]);
                }
                placeToken(row, col);
                flankNW = true;
            }
            else
                flankNW = false;

            return flankNW;
        }


        // fucntion to place player token in given space
        private void placeToken(int row, int col)
        {
            checkerBoard[row, col] = playerToken;

        }



        // this button outputs the array values into a text box
        private void button1_Click(object sender, EventArgs e)
        {
            //    infinateBoard();

            // currentBoard();

            //for (int row = 0; row <= 7; row++)
            //{
            //    for (int col = 0; col <= 7; col++)
            //    {
            //        if (checkerBoard[row, col] == 1)
            //        {
            //            if (col == 7)
            //                checkerBoardText.AppendText("1" + Environment.NewLine);
            //            else
            //                checkerBoardText.AppendText("1");
            //        }
            //        else if (checkerBoard[row, col] == 0)
            //        {
            //            if (col == 7)
            //                checkerBoardText.AppendText("0" + Environment.NewLine);
            //            else
            //                checkerBoardText.AppendText("0");
            //        }
            //        else if (checkerBoard[row, col] == 10)
            //        {
            //            if (col == 7)
            //                checkerBoardText.AppendText("X" + Environment.NewLine);
            //            else
            //                checkerBoardText.AppendText("X");
            //        }
            //        else
            //        {
            //            if (col == 7)
            //                checkerBoardText.AppendText("?" + Environment.NewLine);
            //            else
            //                checkerBoardText.AppendText("?");
            //        }
            //    }
            //}
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame();
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveGame();
        }

        private void restoreGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadGame();
        }
    }
}
