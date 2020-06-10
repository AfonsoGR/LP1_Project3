namespace BootlegRoguelike
{
    public class MedHeal : Powerup
    {
        public MedHeal (Player player, RoomGenerator Room)
        {
            Heal = 8;
            this.player = player;
            this.Room = Room;
            Type = Enums.PowerMin;
        }
    }
}