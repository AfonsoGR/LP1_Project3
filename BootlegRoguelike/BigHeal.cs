namespace BootlegRoguelike
{
    public class BigHeal : Powerup
    {
        public BigHeal (Player player, RoomGenerator Room, int rndX, int rndY)
        {
            Position = new Position(rndX, rndY);
            Heal = 4;
            Type = Enums.PowerMin;
            this.player = player;
            this.Room = Room;
        }
    }
}