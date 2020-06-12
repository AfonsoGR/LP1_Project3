using System;
using System.Collections.Generic;

namespace BootlegRoguelike
{
    /// <summary>
    /// Creates a player whit HP,position and type.
    /// </summary>
    public class Player
    {
        //Creates a variable of RoomGenerator
        private RoomGenerator Room;

        /// <summary>
        /// Current HP of the player
        /// </summary>
        public int HP { get; set; }
        
        /// <summary>
        /// Current position of the player
        /// </summary>
        public Position Position { get; private set; }

        /// <summary>
        /// Type of Piece
        /// </summary>
        /// <value>Value Enum</value>
        public Piece Type { get; }

        /// <summary>
        /// The max Hp of the player
        /// </summary>
        /// <value>Value int</value>
        public int MaxHP { get; set; }

        /// <summary>
        /// This creates the player
        /// He's HP requires the number of <see cref="rows"/> and
        /// <see cref="columns"/> 
        /// </summary>
        /// <param name="rows">Number of rows</param>
        /// <param name="columns">Number of columns</param>
        /// <param name="Room">With Room is in</param>
        /// <param name="rnd">Random position</param>
        public Player(int rows, int columns, RoomGenerator Room, int rnd)
        {
            HP = (rows * columns) / 4;
            Position = new Position(1, rnd);
            Type = Piece.Player;
            this.Room = Room;
            MaxHP = HP;
        }

        /// <summary>
        /// Makes the move based on the player's  <see cref="choice"/> .
        /// </summary>
        /// <param name="choice">Player's choice.</param>
        public bool Movement()
        {
            ConsoleKey choice = ConsoleKey.NoName;

            while (choice != ConsoleKey.W && choice != ConsoleKey.A
                && choice != ConsoleKey.S && choice != ConsoleKey.D
                && choice != ConsoleKey.UpArrow
                && choice != ConsoleKey.DownArrow
                && choice != ConsoleKey.LeftArrow
                && choice != ConsoleKey.RightArrow
                && choice != ConsoleKey.Escape)
            {
                choice = Console.ReadKey(true).Key;
            }

            switch (choice)
            {
                //Goes up
                //Checks if there are any bosses, minions or blocks around
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                // Moves the player very move takes 1 Hp
                    CheckIfPlayerCanMove(
                        new Position(Position.Row, Position.Col - 1));

                    break;
                //Goes left
                //Checks if there are any bosses, minions or blocks around
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                // Moves the player very move takes 1 Hp
                    CheckIfPlayerCanMove(
                        new Position(Position.Row - 1, Position.Col));
                    break;
                //Goes down
                //Checks if there are any bosses, minions or blocks around
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                // Moves the player very move takes 1 Hp
                    CheckIfPlayerCanMove(
                        new Position(Position.Row, Position.Col + 1));
                    break;
                //Goes right
                //Checks if there are any bosses, minions or blocks around
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    // Moves the player very move takes 1 Hp
                    CheckIfPlayerCanMove(
                        new Position(Position.Row + 1, Position.Col));
                        
                    break;

                case ConsoleKey.Escape:
                    return true;
                //If he doesn't chose any legal choices.
                default:
                    break;
            }
            return false;
        }
        /// <summary>
        /// Checks if the player can move to the wanted position
        /// </summary>
        /// <param name="pos"></param>
        private void CheckIfPlayerCanMove(Position pos)
        {
            // Checks if that position is not a block, enemy or boss
            if (Room[pos] != Piece.Block && Room[pos] != Piece.Boss &&
                   Room[pos] != Piece.Enemy)
            {
                // Sets the position to the new one
                Position = pos;
                // Decrements HP by one
                HP -= 1;
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
            List<Position> pos = new List<Position>{
            new Position (Position.Row, Position.Col-1),
            new Position(Position.Row, Position.Col+1),
            new Position (Position.Row-1, Position.Col),
            new Position (Position.Row+1, Position.Col)
            };
            int deadEnds = 0;
            foreach (Position position in pos)
            {
                if (Room[position] == Piece.Block ||
                Room[position] == Piece.Enemy ||
                Room[position] == Piece.Boss)
                    //Increments if detects a block or enemy
                    deadEnds += 1;
            }
            //Conditions that see if player lost
            if (deadEnds == 4 || HP <= 0)
            {
                return true;
            }
            return false;
        }
    }
}