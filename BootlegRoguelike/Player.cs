using System;
namespace BootlegRoguelike
{
    public class Player
    {
        private int  HP ;
        private Position Position;
        public Enums Type {get; }
        public Player (int rows, int columns)
        {
            HP = (rows*columns)/4;
            Position = new Position (1, columns);
            Type = Enums.Player;

        }

        public void Movement(char choice)
        {
            switch(choice)
            {
                case 'W':
                    Position = new Position (Position.Row,Position.Col+1);
                    break;
                case 'A':
                    Position = new Position (Position.Row-1,Position.Col);
                    break;
                case 'S':
                    Position = new Position (Position.Row,Position.Col-1);
                    break;
                case 'D':
                    Position = new Position (Position.Row+1, Position.Col);
                    break;
                default:
                    Console.WriteLine("não sei este comando");
                    break;
            }
        }
    }
}