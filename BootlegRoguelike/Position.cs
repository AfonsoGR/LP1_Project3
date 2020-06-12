namespace BootlegRoguelike
{
    /// <summary>
    /// This Creates positions
    /// </summary>
    public struct Position
    {
        /// <summary>
        /// Gets the row
        /// </summary>
        /// <value></value>
        public int Row {get; }

        /// <summary>
        /// Gets the column
        /// </summary>
        /// <value></value>
        public int Col {get; }

        /// <summary>
        /// Constructor of positions
        /// </summary>
        /// <param name="row">Row correspondent to the Room</param>
        /// <param name="col">Row correspondent to the Room</param>
        public Position (int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}