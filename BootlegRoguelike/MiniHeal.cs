namespace BootlegRoguelike
{
    public class MiniHeal : Powerup
    {
        public MiniHeal (Player player, RoomGenerator Room)
        {
            Heal = 4;
            Type = Enums.PowerMin;
        }
    }
}