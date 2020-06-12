using System;
using System.Collections.Generic;
namespace BootlegRoguelike
{
    /// <summary>
    /// This class will be the class base for the classes Boss and Minion
    /// </summary>
    public class Enemies  
    {
        /// <summary>
        /// Makes and gets the position of enemy
        /// </summary>
        public Position Position { get; protected set; }

        /// <summary>
        /// Get and sets the type of enemy
        /// </summary>
        public Piece Type { get; protected set; }

        /// <summary>
        /// List of von Neumann positions
        /// </summary>
        List <Position> checkingArea;

        /// <summary>
        /// Creates a variable of RoomGenerator
        /// </summary>
        protected  RoomGenerator Room;

        /// <summary>
        /// Creates a variable int
        /// </summary>
        protected int attack; 

        /// <summary>
        /// Creates a variable of Player
        /// </summary>
        protected Player player;


        protected void SetupEnemy(Position pos)
        {
            // The position of the enemy will be random on the map
            Position = pos;
        }

        /// <summary>
        /// It sees if there is a player around the enemy if it has
        /// attacks and does not move
        /// If there is no player nearby, he sees the nearest path, moves and
        /// sees again if the player is not around, if there is , attacks
        /// </summary>
        public void Movement()
        {
            //If passage is blocked increments 1
            int j = 0; 
            
            //Auxiliary variable
            int aux;

            //Used to see if enemy already attacked
            bool attack = false;

            //Will be the next position of the enemy
            Position min = new Position(Position.Row,Position.Col);

            //Adds the value of acceptable moves
            List<int> valueMovs = new List<int>();

            //Adds the acceptable von Neumann positions
            List <Position> moves = new List<Position>();

            //Updates the von Neumann
            Update();

            //Checks for each von Neumann position
            foreach(Position position in checkingArea)
            {
                //if there is any player on the position calls method attack()
                if(Room[position] == Piece.Player)
                {
                    Attack();
                    //sets attact to true
                    attack = true;
                }
                else
                {
                    //Checks if are blocked passages, Bosses, enemies
                    if (Room[position] != Piece.Block &&
                    Room[position] != Piece.Boss &&
                    Room[position] != Piece.Enemy &&
                    Room[position] != Piece.Player)
                    {
                        //Saves the distance from von Neumann position to 
                        //player
                        valueMovs.Add(
                        Math.Abs(player.Position.Row - position.Row)+
                        Math.Abs(player.Position.Col - position.Col));
                        //Savesthe positions  
                        moves.Add(position);
                    }
                    else
                    {
                        //Increments J
                        j++;
                    }
                }
            }
            //if attack diferent of true it means that he didn't attack yet 
            if(!attack)
            {
                //if J = 4 means all passages are blocked and he can't move
                if(j != 4)
                {
                    aux = valueMovs [0];
                    //Checks what is the lowest value on all distances
                    for(int i=0; i< valueMovs.Count   ; i++)
                    {
                        if(valueMovs[i] <= aux)
                        {
                            min = moves[i];
                            aux = valueMovs[i];
                        }
                    }
                    
                }
                //Makes the move
                Position = new Position(min.Row,min.Col);
                //Updates the von Neumann Positions
                Update();
                //See's if player is around
                CheckPlayer();
            }
            
        }

        /// <summary>
        /// See's if there is any player in von Naumann positions, if it exist
        /// call's method Attack()
        /// </summary>
        protected void CheckPlayer()
        {
            //Goes throw all von Neumann positions
            foreach (Position position in checkingArea)
                //Sees enum type equals to block.
                if (Room[position] == Piece.Player)
                    //calls  the method attack
                    Attack();
        }

        /// <summary>
        /// This method takes the player's life equal to the enemy's damage
        /// </summary>
        protected void Attack()
        {
            player.HP -= attack;
        }

        /// <summary>
        /// Updates the Von Neumann Positions
        /// </summary>
        protected void Update()
        {
            checkingArea = new List<Position> {
            new Position (Position.Row, Position.Col-1),
            new Position(Position.Row, Position.Col+1),
            new Position (Position.Row-1, Position.Col),
            new Position (Position.Row+1, Position.Col)};
        }
    }
}