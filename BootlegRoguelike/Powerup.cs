namespace BootlegRoguelike
{
    /// <summary>
    /// This class will be the class base for the MedHeal, MiniHeal and BigHeal
    /// classes
    /// </summary>
    public class Powerup
    {
        /// <summary>
        /// Creates a variable of Player
        /// </summary>
        protected Player player;
        /// <summary>
        /// Gets and sets the powerups postions
        /// </summary>
        /// <value>Value Row and Column</value>
        public Position Position { get; protected set; }

        /// <summary>
        /// Creates a variable of RoomGenerator
        /// </summary>
        protected RoomGenerator Room;

        /// <summary>
        /// Creates a variable int
        /// </summary>
        protected int Heal;

        /// <summary>
        /// Gets and sets the type of pieces
        /// </summary>
        /// <value>Value Enums</value>
        public Enums Type { get; protected set; }

        /// <summary>
        /// Check if it is in the same position as heal and calls method Regen()
        /// </summary>
        public void CheckPlayer()
        {
            if(Room[Position] == Enums.Player)
                Regen();
        }

        /// <summary>
        /// Regenerates the player's HP 
        /// </summary>
        protected void Regen()
        {
            //if he picks up the powerup checks if the sum is bigger than Maxhp
            if((player.HP + Heal)> player.MaxHP)
                player.HP =  player.MaxHP;
            else
                player.HP += Heal;
        }
    }
}