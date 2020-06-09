namespace BootlegRoguelike
{
    public class Minion : Enemies
    {
        public Minion (RoomGenerator Room, Player player)
        {
            attack = 10;
            this.Room = Room;
            this.player = player;
        }
    }
}