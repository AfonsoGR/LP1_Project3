namespace BootlegRoguelike
{
    /// <summary>
    /// This class extends from Powerup class
    /// </summary>
    public class MiniHeal : Powerup
    {
        /// <summary>
        /// Constructor of Miniheal Powerup.
        /// </summary>
        /// <param name="player">Whom he regenerates.</param>
        /// <param name="Room">On which map</param>
        /// <param name="pos">The location of it</param>
        public MiniHeal (Player player, RoomGenerator Room, Position pos)
        {
            Position = pos;
            //Regeneration value.
            Heal = 4;
            Type = Enums.PowerMin;
            this.player = player;
            this.Room = Room;
        }
    }
}