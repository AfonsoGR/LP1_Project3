namespace BootlegRoguelike
{
    public class MedHeal : Powerup
    {
        public MedHeal(Player player, RoomGenerator Room, Position pos)
        {
            Position = pos;
            Heal = 8;
            Type = Enums.PowerMed;
            this.player = player;
            this.Room = Room;
        }
    }
}