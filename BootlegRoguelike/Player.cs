using System;
namespace BootlegRoguelike
{
    /// <summary>
    /// Creates a player whit HP,position and type.
    /// </summary>
    public class Player
    {
        public int HP { get; set; }
        public Position Position { get; private set; }
        public Enums Type {get; }
        
        /// <summary>
        /// This creates the player.
        /// He's HP requires the number of <see cref="rows"/> and 
        /// <see cref="columns"/> . 
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="columns">Number of columns.</param>
        public Player (int rows, int columns)
        {
            HP = (rows*columns)/4;
            Position = new Position (1, columns -5);
            Type = Enums.Player;

        }
        
        /// <summary>
        /// Makes the move based on the player's  <see cref="choice"/> .
        /// </summary>
        /// <param name="choice">Player's choice.</param>
        public void Movement(char choice)
        {
            switch(choice)
            {
                //Goes up.
                case 'W':
                    Position = new Position (Position.Row,Position.Col-1);
                    break;
                //Goes left.
                case 'A':
                    Position = new Position (Position.Row-1,Position.Col);
                    break;
                //Goes down.
                case 'S':
                    Position = new Position (Position.Row,Position.Col+1);
                    break;
                //Goes right.
                case 'D':
                    Position = new Position (Position.Row+1, Position.Col);
                    break;
                //If he doesn't chose any legal choices.
                default:
                    Console.WriteLine("não sei este comando");
                    break;
            }
        }
    }
}