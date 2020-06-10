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
        private RoomGenerator Room;
        
        /// <summary>
        /// This creates the player.
        /// He's HP requires the number of <see cref="rows"/> and 
        /// <see cref="columns"/> . 
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="columns">Number of columns.</param>
        public Player (int rows, int columns, RoomGenerator Room)
        {
            HP = (rows*columns)/4;
            Position = new Position (1, columns -5);
            Type = Enums.Player;
            this.Room = Room;

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
                    if(Room[new Position (Position.Row,Position.Col-1)] != 
                    Enums.Block)
                    {
                        Position = new Position (Position.Row,Position.Col-1);
                        HP -= 1;
                    }
                    break;
                //Goes left.
                case 'A':
                    if(Room[new Position (Position.Row-1,Position.Col)] != 
                    Enums.Block)
                    {
                        Position = new Position (Position.Row-1,Position.Col);
                        HP -= 1;
                    }
                    break;
                //Goes down.
                case 'S':
                    if(Room[new Position (Position.Row,Position.Col+1)] !=
                    Enums.Block)
                    {
                        Position = new Position (Position.Row,Position.Col+1);
                        HP -= 1;
                    }
                    break;
                //Goes right.
                case 'D':
                    if(Room[new Position (Position.Row+1, Position.Col)] != 
                    Enums.Block)
                    {
                        Position = new Position (Position.Row+1, Position.Col);
                        HP -= 1;
                    }
                    break;
                //If he doesn't chose any legal choices.
                default:
                    break;
            }

        }
    }
}