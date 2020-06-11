using System;
using System.Collections.Generic;

namespace BootlegRoguelike
{
    /// <summary>
    /// Class used to generate and store the level data, contains the player
    /// enemies and the level layout. Only this class contains an istance of
    /// the Random class
    /// </summary>
    public class SceneManager
    {
        // Sotres a Random instance
        private readonly Random rnd;
        // The number of collumns
        private readonly int col;
        // The number of rows
        private readonly int row;

        // Instance of the level layout
        public RoomGenerator Room { get; }

        // Instance of the player
        public Player Player { get; private set; }

        // List containing all the enemies
        public List<Enemies> AllEnemies { get; private set; }

        // List of all the powerups
        public List<Powerup> PowerUps { get; private set; }

        /// <summary>
        /// Constructor of the scene
        /// </summary>
        /// <param name="row"> The wanted number of rows </param>
        /// <param name="col"> The wanted number of columns </param>
        public SceneManager(int row, int col)
        {
            // Sets the variables in this class to the ones given
            this.col = col;
            this.row = row;

            // Generates a new Random
            rnd = new Random();
            // Generates a new Level
            Room = new RoomGenerator();
        }

        /// <summary>
        /// Called to create a new level, player, enemies and powerups
        /// </summary>
        /// <param name="lvl"> The current level number </param>
        /// <param name="generatePlayer"> If it should reset the HP </param>
        public void GenerateNewScene(int lvl, bool generatePlayer = true)
        {
            // Creates a new List of Enemies
            AllEnemies = new List<Enemies>();
            // Creates a new List of PowerUps
            PowerUps = new List<Powerup>();

            // Auxaliary int set to -1
            int hp = -1;

            // Checks if it should reset the player
            if (!generatePlayer)
                // Sets the hp to the current players amount
                hp = Player.HP;

            // Generates a new room layout along with barriers
            CreateNewRoomStructure();
            // Generates a new Player
            CreateNewPlayer();
            // Generates both Minions and Bosses
            CreateNewEnemies(lvl);

            CreateNewPowerUps(lvl);

            // Checks if the HP is not at the -1 value
            if (hp != -1)
            {
                // Sets the new Players hp the same as the old player
                Player.HP = hp;
            }
        }

        /// <summary>
        /// Creates a new Player seding in the size of the Room and the level
        /// </summary>
        private void CreateNewPlayer()
        {
            // Assgins the Player variable the created player
            Player = new Player(row, col, Room);

            // Puts the player on the board
            Room[Player.Position] = Enums.Player;
        }

        //////////////////////////////////////////////////////////////////////
        //                                                                  //
        //                                                                  //
        //                 It probably requires changes                     //
        //                                                                  //
        //                                                                  //
        //////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Creates a new bosses and minions
        /// </summary>
        /// <param name="lvl"> The current level number </param>
        private void CreateNewEnemies(int lvl)
        {
            // The calculated max amount of enemies (logorithmic formula)
            int maxEnemies = (int)(11 * Math.Log(3.3 * lvl));

            // Doesn't allow the number of enemies to be higher than half the 
            // level
            maxEnemies = Math.Min(maxEnemies, ((row - 2) * (col - 2)) / 2);

            // Maximum amount of Minions
            int maxMinions = rnd.Next(maxEnemies);

            // Calculates the number of bosses being a random between 0 and
            // the remaining number of maxEemies
            int maxBosses = rnd.Next(Math.Abs(maxMinions - maxEnemies));

            /////////////////////////////////////////////////////////////////// <---------- Fucking awful, please refactor this mess!
            for (int n = 0; n < maxMinions; n++)
            {
                Position pos = new Position(rnd.Next(1, row - 1),
                    rnd.Next(1, col - 2));

                AllEnemies.Add(new Minion(Room, Player, pos));

                Room[pos] = Enums.Enemy;
            }

            for (int c = 0; c < maxBosses; c++)
            {
                Position pos = new Position(rnd.Next(1, row - 3),
                    rnd.Next(1, col - 2));

                AllEnemies.Add(new Minion(Room, Player, pos));

                Room[pos] = Enums.Boss;
            }
        }

        // Unsued ATM
        private void CreateNewPowerUps(int lvl)
        {
            //int maxPowerUps = (int)(-10 * Math.Log(0.01f * lvl));

            int maxSmallPower = (int)(-2 * Math.Log(0.01f * lvl));
            maxSmallPower = rnd.Next(0, maxSmallPower);

            int maxMedPower = (int)(-2.5f * Math.Log(0.02f * lvl));
            maxMedPower = rnd.Next(0, maxMedPower);

            int maxBigPower = (int)(-3 * Math.Log(0.03f * lvl));
            maxBigPower = rnd.Next(0, maxBigPower);

            for (int n = 0; n < maxSmallPower; n++)
            {
                Position pos = new Position(rnd.Next(1, row - 3),
                    rnd.Next(1, col - 2));

                PowerUps.Add(new MiniHeal(Player, Room, pos));

                Room[pos] = Enums.PowerMin;
            }
            for (int n = 0; n < maxMedPower; n++)
            {
                Position pos = new Position(rnd.Next(1, row - 3),
                    rnd.Next(1, col - 2));

                PowerUps.Add(new MedHeal(Player, Room, pos));

                Room[pos] = Enums.PowerMed;
            }
            for (int n = 0; n < maxBigPower; n++)
            {
                Position pos = new Position(rnd.Next(1, row - 3),
                    rnd.Next(1, col - 2));

                PowerUps.Add(new BigHeal(Player, Room, pos));

                Room[pos] = Enums.PowerMax;
            }

            if (maxBigPower == 0 && maxMedPower == 0 && maxBigPower == 0)
            {
                Position pos = new Position(rnd.Next(1, row - 3),
                       rnd.Next(1, col - 2));

                PowerUps.Add(new MiniHeal(Player, Room, pos));
            }
        }

        /// <summary>
        /// Creates the visual part of the level, including the exit and the 
        /// obstacles.
        /// </summary>
        private void CreateNewRoomStructure()
        {
            // Generates the outside bounds, exit
            Room.SetBoardToInitState(row, col, rnd.Next(1, col - 1));

            // Calculates the number of obstacles
            int nObstacles = rnd.Next(Math.Min(row, col) - 1);

            // Cycles for the number of Obstacles to be created
            for (int i = 0; i < nObstacles; i++)
            {
                // creates a new random position for that obstacle
                Position startPos =
                    new Position(rnd.Next(1, row - 2), rnd.Next(1, col - 2));

                // Places that obstacle on the board
                Room[startPos] = Enums.Block;
            }
        }
    }
}