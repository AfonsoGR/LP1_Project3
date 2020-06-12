namespace BootlegRoguelike
{
    public class Powerup
    {
        protected Player player;
        protected RoomGenerator Room;
        protected int Heal;
        public Position Position { get; protected set; }
        public Piece Type { get; protected set; }

        public void CheckPlayer()
        {
            if (Room[Position] == Piece.Player)
                Regen();
        }

        protected void Regen()
        {
            if ((player.HP + Heal) > player.MaxHP)
                player.HP = player.MaxHP;
            else
                player.HP += Heal;
        }
    }
}