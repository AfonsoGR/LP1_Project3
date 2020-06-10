namespace BootlegRoguelike
{
    public class MedHeal : Powerup
    {
        public MedHeal (Player player, RoomGenerator Room)
        {
            Heal = 8;
            Type = Enums.PowerMin;
        }
    }
}