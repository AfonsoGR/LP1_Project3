namespace BootlegRoguelike
{
    /// <summary>
    /// This class extends from the class Enemies.
    /// </summary>
    public class Minion : Enemies
    {
        /// <summary>
        /// Constructor of the Minion enemy
        /// </summary>
        /// <param name="Room">The room where he's in it</param>
        /// <param name="player">PLayer that he needs to attack</param>
        public Minion(RoomGenerator Room, Player player, Position pos)
        {
            SetupEnemy(pos);
            //Damage of this enemy
            attack = 5;
            this.Room = Room;
            this.player = player;
            Type = Piece.Enemy;
        }
    }
}