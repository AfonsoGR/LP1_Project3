namespace BootlegRoguelike
{
    /// <summary>
    /// This class extends from Powerup class
    /// </summary>
    public class BigHeal : Powerup
    {
        /// <summary>
        /// Constructor of Bigheal Powerup
        /// </summary>
        /// <param name="player">Whom he regenerates</param>
        /// <param name="Room">On which map</param>
        /// <param name="pos">The location of it</param>
        public BigHeal (Player player, RoomGenerator Room, Position pos)
        {
            Position = pos;
            //Regeneration value
            Heal = 16;
            Type = Enums.PowerMax;
            this.player = player;
            this.Room = Room;
        }
    }
}