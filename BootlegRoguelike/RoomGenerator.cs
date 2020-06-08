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
        /// <param name="x"> The X on the array </param>
        /// <param name="y"> The Y on the array </param>
        /// <returns> The ColorChoice of the players </returns>
        public char this[int x, int y]
        {
            get => roomLayout[x, y];
            set => roomLayout[x, y] = value;
        }

        /// <summary>
        /// Generates the basic visual structure of the board
        /// </summary>
        public void SetBoardToInitState(int cols, int rows)
        {
            roomLayout = new char[rows, cols];

            // Checks the upper part of the board
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (x == 0 || x == cols -1 || y == 0 || y == rows -1)
                    {
                        roomLayout[x, y] = 'b';
                    }
                    else
                    {
                        roomLayout[x, y] = '.';
                    }
                }
            }
        }
    }
}

