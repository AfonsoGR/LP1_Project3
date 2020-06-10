namespace BootlegRoguelike
{
    public class BigHeal : Powerup
    {
        public BigHeal (Player player, RoomGenerator Room)
        {
            Heal = 4;
            this.player = player;
            this.Room = Room;
            Type = Enums.PowerMin;
        }
    }
}