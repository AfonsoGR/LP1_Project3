namespace BootlegRoguelike
{
    public class MiniHeal : Powerup
    {
        public MiniHeal (Player player, RoomGenerator Room, int rndX, int rndY)
        {
            Position = new Position(rndX,rndY);
            Heal = 4;
            Type = Enums.PowerMin;
            this.player = player;
            this.Room = Room;
        }
    }
}