using System;
using System.Collections.Generic;
using System.Text;

namespace BootlegRoguelike
{
    /// <summary>
    /// Creates a board with the given size
    /// </summary>
    public class RoomGenerator
    {
        // A bi-dimensional array containing a ColorChoice
        private char[,] roomLayout;

        /// <summary>
        /// The width of the board
        /// </summary>
        public int SizeX => roomLayout.GetLength(0);

        /// <summary>
        /// The height of the board
        /// </summary>
        public int SizeY => roomLayout.GetLength(1);

        /// <summary>
        /// Returns the value of the position or gives it a new value
        /// </summary>
        /// <param name="r"> The X on the array </param>
        /// <param name="c"> The Y on the array </param>
        /// <returns> The ColorChoice of the players </returns>
        public char this[int r, int c]
        {
            get => roomLayout[r, c];
            set => roomLayout[r, c] = value;
        }

        /// <summary>
        /// Generates the basic visual structure of the board
        /// </summary>
        public void SetBoardToInitState(int rows, int cols, int rnd)
        {
            roomLayout = new char[rows +1, cols];

            // Checks the upper part of the board
            for (int c = 0; c < cols; c++)
            {
                for (int r = 0; r < rows; r++)
                {
                    if (r == 0 || r == rows - 1 || c == 0 || c == cols - 1)
                    {
                        char tmp = r == 0 || r == rows - 1 ? '|' : '-';

                        roomLayout[r, c] = tmp;
                    }
                    else
                    {
                        roomLayout[r, c] = '.';
                    }
                }
            }
            GenerateRoomExit(rows, rnd);
        }
        private void GenerateRoomExit(int rows, int rnd)
        {
            roomLayout[rows -1,rnd] = '.';

            roomLayout[rows ,rnd] = 'E';
            roomLayout[rows ,rnd + 1] = '-';
            roomLayout[rows ,rnd - 1] = '-';

        }
    }
}

