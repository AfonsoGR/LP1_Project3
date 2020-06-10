namespace BootlegRoguelike
{
    public class MedHeal : Powerup
    {
        public MedHeal(Player player, RoomGenerator Room, int rndX, int rndY)
        {
            Position = new Position(rndX, rndY);
            Heal = 8;
            this.player = player;
            this.Room = Room;
            Type = Enums.PowerMin;
            this.player = player;
            this.Room = Room;
        }
    }
}