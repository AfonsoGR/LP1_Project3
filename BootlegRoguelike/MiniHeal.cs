namespace BootlegRoguelike
{
    public class MiniHeal : Powerup
    {
        public MiniHeal (Player player, RoomGenerator Room)
        {
            Heal = 4;
            this.player = player;
            this.Room = Room;
            Type = Enums.PowerMin;
        }
    }
}