namespace BootlegRoguelike
{
    public class Boss : Enemies
    {

           
        public Boss (RoomGenerator Room, Player player)
        {
            attack = 10;
            this.Room = Room;
            this.player = player;
        }
    }
}