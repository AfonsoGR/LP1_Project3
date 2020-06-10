using System;
using System.Collections.Generic;
namespace BootlegRoguelike
{
    /// <summary>
    /// This class will be the class base for the classes Boos and Minion.
    /// </summary>
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

        /// <summary>
        /// Constructor of enemies.
        /// </summary>
        public Enemies ()
        {
            // The position of the enemy will be random on the map.
            Position = new Position (/*rndX, rndY*/);
            Up = new Position (Position.Row, Position.Col+1);
            Down = new Position (Position.Row, Position.Col-1);
            Left = new Position (Position.Row-1, Position.Col);
            Right = new Position (Position.Row+1, Position.Col+1);
            checkingArea = new List<Position> {Up,Down,Left,Right};
        }

        /// <summary>
        ///This method sees if there are any () around the enemy, if none exist,
        ///it will compare the player's position with that of the enemy and
        ///insert it into an array and will save the valid positions in another
        ///array.
        /// 
        /// The second part will see what is the smallest value and will save
        /// the corresponding position, then make the move.
        /// </summary>
        /// <param name="player">Will be used to get player position.</param>
        protected void Movement(Player player)
        {
            int shortMov ;
            int[] valueMovs = new int[4] ;
            int i = 0; 
            int aux;
            Position min = new Position(0,0) ;
            List <Position> moves = new List<Position>(); 
            foreach(Position position in checkingArea)
            {
                //Checks if are blocked passages 
                if(Room[position] != Enums.Block)
                {
                    //Saves the positions.
                    shortMov = Math.Abs(player.Position.Row - position.Row)+
                    Math.Abs(player.Position.Col - position.Col);
                    //Puts the shortMov in to a array.  
                    valueMovs [i] = shortMov ;
                    moves [i] = position;
                    //increments.
                    i++;
                    
                }
                
            }
            
            //Auxiliary variable.
            aux = valueMovs [0];
            for(i=0; i< valueMovs[i]; i++)
            {
                if(valueMovs[i] < aux)
                {
                    min = moves[i];
                    aux = valueMovs[i];
                }
            }
            
            Position = min;
            CheckPlayer();
        }

        /// <summary>
        /// See's if there are eny player in von Naumann positions, if it exist
        /// call's method Attack().
        /// </summary>
        protected void CheckPlayer()
        {
            //Goes throw all von Neumann positions. 
            foreach(Position position in checkingArea)
            //Sees enum type equals to block.
                if(Room[position] == Enums.Player)
            //calls  the method attack.
                    Attack();
        }

        /// <summary>
        /// This method takes the player's life equal to the enemy's damage.
        /// </summary>
        protected void Attack()
        {
            player.HP -= attack;
        }


    }
}