namespace BootlegRoguelike
{
    public class MiniHeal : Powerup
    {
        public MiniHeal (Player player, RoomGenerator Room, Position pos)
        {
            Position = pos;
            Heal = 4;
            Type = Enums.PowerMin;
            this.player = player;
            this.Room = Room;
        }
    }
}