using System.Collections.Generic;
namespace BootlegRoguelike
{
    public class Enemies
    {
        protected Position Position;
        protected Position Up; 
        protected Position Down;
        protected Position Left; 
        protected Position Right; 
        List <Position> checkingArea;
        protected  RoomGenerator Room;
        protected int attack; 
        protected Player player;
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

        protected void Movement(Player player)
        {
            int shortMov ;
            int[] valueMovs = new int[4] ;
            int i = 0; 
            int aux;
            Position min = new Position(0,0) ;  
            foreach(Position position in checkingArea)
            {
                //Checks if are blocked passages 
                if(Room[position] != Enums.Block)
                {
                    //Saves the positions
                    shortMov = (player.Position.Row - position.Row)+
                    (player.Position.Col - position.Col);
                    //Puts the shortMov in to a array  
                    valueMovs [i] = shortMov ;
                    //increment
                    i++;
                }
                
            }
            //Auxiliary variable
            aux = valueMovs [0];
            for(i=0; i< valueMovs[i]; i++)
            {
                if(valueMovs[i] < aux)
                {
                    min = checkingArea[i];
                }
            }
            
            Position = min;
            CheckPlayer();
        }

        protected void CheckPlayer()
        {
            //Goes throw all von Neumann positions 
            foreach(Position position in checkingArea)
            // Later maybe change to a switch case
            //    /Checks enum type
                if(Room[position] == Enums.Player)
            //calls  the method attack
                    Attack();
        }

        protected void Attack()
        {
            player.HP -= attack;
        }


    }
}