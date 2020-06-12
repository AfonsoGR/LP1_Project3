namespace BootlegRoguelike
{
    /// <summary>
    /// Creates a room with the given size
    /// </summary>
    public class RoomGenerator
    {
        // A bi-dimensional array containing a Enum
        private Piece[,] roomLayout;

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
        /// <param name="pos"> The position to be accessed </param>
        /// <returns> The Piece at that position </returns>
        public Piece this[Position pos]
        {
            get => roomLayout[pos.Row, pos.Col];
            set => roomLayout[pos.Row, pos.Col] = value;
        }

        /// <summary>
        /// Generates the basic visual structure of the board
        /// </summary>
        /// <param name="rows"> Number of rows </param>
        /// <param name="cols"> Number of columns </param>
        /// <param name="rnd"> Random number (0 and cols -1) </param>
        public void SetBoardToInitState(int rows, int cols, int rnd)
        {
            // Creates a new array with the given dimensions
            roomLayout = new Piece[rows + 3, cols + 2];

            // Checks all the positions of the room
            for (int c = 0; c < cols + 2; c++)
            {
                for (int r = 0; r < rows + 2; r++)
                {
                    // Sees if it's the top, bottom or sides of the room
                    if (r == 0 || r == rows + 1 || c == 0 || c == cols + 1)
                    {
                        // Sets that position the char defined
                        roomLayout[r, c] = Piece.Block;
                    }
                    else
                    {
                        // Otherwise sets the position as empty
                        roomLayout[r, c] = Piece.Empty;
                    }
                }
            }
            // Creates the exit of the room
            GenerateRoomExit(rows + 2, rnd);
        }

        /// <summary>
        /// Creates the visuals on the board for the exit
        /// </summary>
        /// <param name="rows"> Number of rows </param>
        /// <param name="rnd"> Random number </param>
        private void GenerateRoomExit(int rows, int rnd)
        {
            // Changes the position in front of the exit to a dot
            roomLayout[rows - 1, rnd] = Piece.Empty;
            // Changes the visuals on the exit to a 'E'
            roomLayout[rows, rnd] = Piece.Exit;
            // Creates a wall on top of the exit
            roomLayout[rows, rnd + 1] = Piece.Block;
            // Creates a wall on the bottom of the exit
            roomLayout[rows, rnd - 1] = Piece.Block;
        }
    }
}