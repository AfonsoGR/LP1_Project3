namespace BootlegRoguelike
{
    public class BigHeal : Powerup
    {
        public BigHeal (Player player, RoomGenerator Room)
        {
            Heal = 4;
            Type = Enums.PowerMin;
        }
    }
}