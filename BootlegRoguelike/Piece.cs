namespace BootlegRoguelike
{
    /// <summary>
    /// Types of pieces that can exist
    /// </summary>
    public enum Piece
    {
        Player = '@',
        Boss = 'O',
        Enemy = 'o',
        Block = 'w',
        Empty = ' ',
        PowerMin = '.',
        PowerMed = ':',
        PowerMax = '!',
        Exit = 'E'
    }
}