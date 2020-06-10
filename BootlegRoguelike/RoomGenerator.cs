namespace BootlegRoguelike
{
    /// <summary>
    /// Creates a room with the given size
    /// </summary>
    public class RoomGenerator
    {
        // A bi-dimensional array containing a ColorChoice
        private Enums[,] roomLayout;

        /// <summary>
        /// The width of the board
        /// </summary>
        public int SizeX => roomLayout.GetLength(0);

        /// <summary>
        /// The height of the board
        /// </summary>
        public int SizeY => roomLayout.GetLength(1);

        /// <summary>
        /// Where the exit of the level is located
        /// </summary>
        public Position Exit { get; private set; }

        /// <summary>
        /// Returns the value of the position or gives it a new value
        /// </summary>
        /// <param name="r"> The X on the array </param>
        /// <param name="c"> The Y on the array </param>
        /// <returns> The ColorChoice of the players </returns>
        public Enums this[Position pos]
        {
            get => roomLayout[pos.Row, pos.Col];
            set => roomLayout[pos.Row, pos.Col] = value;
        }

        /// <summary>
        /// Generates the basic visual structure of the board
        /// </summary>
        /// <param name="rows"> Number of rows </param>
        /// <param name="cols"> Number of collumns </param>
        /// <param name="rnd"> Random number (0 and cols -1) </param>
        public void SetBoardToInitState(int rows, int cols, int rnd)
        {
            // Creates a new array with the given dimensions
            roomLayout = new Enums[rows + 3, cols + 2];

            // Checks all the positions of the room
            for (int c = 0; c < cols + 2; c++)
            {
                for (int r = 0; r < rows + 2; r++)
                {
                    // Sees if it's the top, bottom or sides of the room
                    if (r == 0 || r == rows + 1 || c == 0 || c == cols + 1)
                    {
                        // Sets that position the char defined
                        roomLayout[r, c] = Enums.Block;
                    }
                    else
                    {
                        roomLayout[r, c] = Enums.Empty;
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
            roomLayout[rows - 1, rnd] = Enums.Empty;

            // Assigns the position of the exit
            Exit = new Position(rows, rnd);

            // Changes the visuals on the exit to a 'E'
            roomLayout[rows, rnd] = Enums.Exit;
            // Creates a wall on top of the exit
            roomLayout[rows, rnd + 1] = Enums.Block;
            // Creates a wall on the bottom of the exit
            roomLayout[rows, rnd - 1] = Enums.Block;
        }
    }
}