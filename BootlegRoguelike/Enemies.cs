using System.Collections.Generic;
namespace BootlegRoguelike
{
    public class Enemies
    {
        private Position Position;
        private Position Up; 
        private Position Down;
        private Position Left; 
        private Position Right; 
        List <Position> checkingArea;
        public Enemies ()
        {
            // The position of the enemy will be random on the map
            Position = new Position (/*rndX, rndY*/);
            Up = new Position (Position.Row, Position.Col+1);
            Down = new Position (Position.Row, Position.Col-1);
            Left = new Position (Position.Row-1, Position.Col);
            Right = new Position (Position.Row+1, Position.Col+1);
            checkingArea = new List<Position> {Up,Down,Left,Right};
        }

        private void CheckPlayer()
        {
            ////Goes throw all von Neumann positions 
            //foreach(Position position in checkingArea)
            //    //Later maybe change to a switch case
            //    //Checks enum type
            //    if(GetType(position) == Player)
            //        //calls  the method attack
            //        Attack()
        }


    }
}