namespace BootlegRoguelike
{
    public class Powerup
    {
        protected Player player;
        public Position Position { get; protected set; }
        protected RoomGenerator Room;
        protected int Heal;
        public Enums Type { get; protected set; }

        public void CheckPlayer()
        {
            if(Room[Position] == Enums.Player)
                Regen();
        }

        protected void Regen()
        {
            if((player.HP + Heal)> player.MaxHP)
                player.HP =  player.MaxHP;
            else
                player.HP += Heal;
        }
    }
}