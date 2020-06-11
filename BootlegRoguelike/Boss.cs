namespace BootlegRoguelike
{
    /// <summary>
    ///  This class extends from the class Enemies.
    /// </summary>
    public class Boss : Enemies
    {
        /// <summary>
        /// Constructor of the Boss enemy.
        /// </summary>
        /// <param name="Room">The room where he's in it.</param>
        /// <param name="player">PLayer that he needs to attack.</param>
        public Boss (RoomGenerator Room, Player player, Position pos)
        {
            SetupEnemy(pos);

            //Damage of this enemy. 
            attack = 10;
            this.Room = Room;
            this.player = player;
            type = Enums.Boss;
        }
    }
}