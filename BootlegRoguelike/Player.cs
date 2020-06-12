using System;
using System.Collections.Generic;

namespace BootlegRoguelike
{
    /// <summary>
    /// Creates a player whit HP,position and type.
    /// </summary>
    public class Player
    {
        public int HP { get; set; }
        public Position Position { get; private set; }
        public Piece Type { get; }
        private RoomGenerator Room;
        public int MaxHP { get; set; }

        /// <summary>
        /// This creates the player.
        /// He's HP requires the number of <see cref="rows"/> and
        /// <see cref="columns"/> .
        /// </summary>
        /// <param name="rows"> Number of rows </param>
        /// <param name="columns"> Number of columns </param>
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
                //Goes up.
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    CheckIfPlayerCanMove(
                        new Position(Position.Row, Position.Col - 1));

                    break;
                //Goes left.
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    CheckIfPlayerCanMove(
                        new Position(Position.Row - 1, Position.Col));
                    break;
                //Goes down.
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    CheckIfPlayerCanMove(
                        new Position(Position.Row, Position.Col + 1));
                    break;
                //Goes right.
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
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

        private void CheckIfPlayerCanMove(Position pos)
        {
            if (Room[pos] != Piece.Block && Room[pos] != Piece.Boss &&
                   Room[pos] != Piece.Enemy)
            {
                Position = pos;
                HP -= 1;
            }
        }

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
                    deadEnds += 1;
            }
            if (deadEnds == 4 || HP <= 0)
            {
                return true;
            }
            return false;
        }
    }
}