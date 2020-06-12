using System;
using System.Collections.Generic;
namespace BootlegRoguelike
{
    /// <summary>
    /// Creates a player whit HP,position and type
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Gets and sets the player's HP
        /// </summary>
        /// <value>Value int</value>
        public int HP { get; set; }

        /// <summary>
        /// Gets and sets the player's position
        /// </summary>
        /// <value>Value Rows and columns</value>
        public Position Position { get; private set; }

        /// <summary>
        /// Type of Piece
        /// </summary>
        /// <value>Value Enum</value>
        public Enums Type {get; }

        //Creates a variable of RoomGenerator
        private RoomGenerator Room;

        /// <summary>
        /// The max Hp of the player
        /// </summary>
        /// <value>Value int</value>
        public int MaxHP{ get; set;}
        
        /// <summary>
        /// This creates the player
        /// He's HP requires the number of <see cref="rows"/> and 
        /// <see cref="columns"/> 
        /// </summary>
        /// <param name="rows">Number of rows</param>
        /// <param name="columns">Number of columns</param>
        /// <param name="Room">With Room is in</param>
        /// <param name="rnd">Random position</param>
        public Player (int rows, int columns, RoomGenerator Room, int rnd)
        {
            HP = (rows*columns)/4;
            Position = new Position (1, rnd);
            Type = Enums.Player;
            this.Room = Room;
            MaxHP = HP;

        }
        
        /// <summary>
        /// Makes the move based on the player's  <see cref="choice"/>, can't
        /// move where is a boss, minion or block
        /// </summary>
        /// <param name="choice">Player's choice.</param>
        public void Movement(ConsoleKey choice)
        {
            switch(choice)
            {
                //Goes up
                //Checks if there are any bosses, minions or blocks around
                case ConsoleKey.W: case ConsoleKey.UpArrow:
                    if(Room[new Position (Position.Row,Position.Col-1)]!= 
                    Enums.Block &&
                    Room[new Position (Position.Row,Position.Col-1)]!= 
                    Enums.Boss &&
                    Room[new Position (Position.Row,Position.Col-1)]!=
                    Enums.Enemy)
                    {
                        //moves the player
                        Position = new Position (Position.Row,Position.Col-1);
                        //Every move takes 1 Hp
                        HP -= 1;
                        
                    }
                    break;
                //Goes left
                //Checks if there are any bosses, minions or blocks around
                case ConsoleKey.A: case ConsoleKey.LeftArrow:
                    if(Room[new Position (Position.Row-1,Position.Col)]!= 
                    Enums.Block && 
                    Room[new Position (Position.Row-1,Position.Col)]!= 
                    Enums.Boss && 
                    Room[new Position (Position.Row-1,Position.Col)]!= 
                    Enums.Enemy)
                    {
                        //moves the player
                        Position = new Position (Position.Row-1,Position.Col);
                        //Every move takes 1 Hp
                        HP -= 1;
                        
                    }
                    break;
                //Goes down
                //Checks if there are any bosses, minions or blocks around
                case ConsoleKey.S :case ConsoleKey.DownArrow:
                    if(Room[new Position (Position.Row,Position.Col+1)]!=
                    Enums.Block &&
                    Room[new Position (Position.Row,Position.Col+1)]!=
                    Enums.Boss &&
                    Room[new Position (Position.Row,Position.Col+1)]!=
                    Enums.Enemy)
                    {
                        //moves the player
                        Position = new Position (Position.Row,Position.Col+1);
                        //Every move takes 1 Hp
                        HP -= 1;
                        
                    }
                    break;
                //Goes right
                //Checks if there are any bosses, minions or blocks around
                case ConsoleKey.D:case ConsoleKey.RightArrow:
                    if(Room[new Position (Position.Row+1, Position.Col)] != 
                    Enums.Block &&
                    Room[new Position (Position.Row+1, Position.Col)] != 
                    Enums.Boss &&
                    Room[new Position (Position.Row+1, Position.Col)] != 
                    Enums.Enemy)
                    {
                        //moves the player
                        Position = new Position (Position.Row+1, Position.Col);
                        //Every move takes 1 Hp
                        HP -= 1;
                        
                    }
                    break;
                //If he doesn't chose any legal choices.
                default:
                    break;
            }

        }
        /// <summary>
        /// Checks if player is cornered or is HP equals to zero
        /// Returns true if one of the occurrences above happens
        /// Returns false if none happens 
        /// </summary>
        /// <returns></returns>
        public bool Gameover()
        {
            //List of von Neumann positions
            List<Position> pos = new List<Position>{
            new Position (Position.Row, Position.Col-1),
            new Position(Position.Row, Position.Col+1),
            new Position (Position.Row-1, Position.Col),
            new Position (Position.Row+1, Position.Col)
            };
            //counter to dead ends
            int deadEnds = 0;
            //Checks if in any von Neumann position is a block or enemy
            foreach (Position position in pos)
            {
                if(Room[position] == Enums.Block ||
                Room[position] == Enums.Enemy||
                Room[position] == Enums.Boss)
                    //Increments if detects a block or enemy
                    deadEnds += 1;
            }
            //Conditions that see if player lost
            if(deadEnds == 4 || HP <= 0)
            {
                return true;
            }
            return false;

        }
    }
}