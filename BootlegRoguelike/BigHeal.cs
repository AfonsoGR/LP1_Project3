namespace BootlegRoguelike
{
    public class BigHeal : Powerup
    {
        public BigHeal (Player player, RoomGenerator Room, Position pos)
        {
            Position = pos;
            Heal = 4;
            Type = Enums.PowerMax;
            this.player = player;
            this.Room = Room;
        }
    }
}