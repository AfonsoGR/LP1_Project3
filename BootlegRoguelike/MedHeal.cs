namespace BootlegRoguelike
{
    /// <summary>
    /// This class extends from Powerup class
    /// </summary>
    public class MedHeal : Powerup
    {
        /// <summary>
        /// Constructor of Medheal Powerup
        /// </summary>
        /// <param name="player">Whom he regenerates</param>
        /// <param name="Room">On which map</param>
        /// <param name="pos">The location of it</param>
        public MedHeal(Player player, RoomGenerator Room, Position pos)
        {
            Position = pos;
            //Regeneration value
            Heal = 8;
            Type = Enums.PowerMed;
            this.player = player;
            this.Room = Room;
        }
    }
}