namespace BootlegRoguelike
{
    public class Powerup
    {
        protected Player player;
        protected Position Position;
        protected RoomGenerator Room;
        protected int Heal;
        protected Enums Type;

        protected void CheckPlayer()
        {
            if(Room[Position] == Enums.Player)
                Regen();
        }

        protected void Regen()
        {
            player.HP +=  Heal;
        }
    }
}