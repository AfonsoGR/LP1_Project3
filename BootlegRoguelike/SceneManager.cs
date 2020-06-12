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

        /// <summary>
        /// Instance of the player
        /// </summary>
        public Player Player { get; private set; }

        /// <summary>
        /// List containing all the enemies
        /// </summary>
        public List<Enemies> AllEnemies { get; private set; }

        /// <summary>
        /// List of all the powerups
        /// </summary>
        public List<Powerup> AllPowerUps { get; private set; }

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
            // Creates a new List of AllPowerUps
            AllPowerUps = new List<Powerup>();

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
            // Generates all types of powerups
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
            Player = new Player(row, col, Room, rnd.Next(1, col - 1));

            // Puts the player on the board
            Room[Player.Position] = Piece.Player;
        }

        /// <summary>
        /// Creates a new bosses and minions
        /// </summary>
        /// <param name="lvl"> The current level number </param>
        private void CreateNewEnemies(int lvl)
        {
            // Linearly finds the maximum of minions
            int maxMinions = (int)(-0.1f * lvl + 6);
            // Linearly finds the maximum of bosses
            int maxBosses = (int)(0.5f * lvl);

            // Stops the number of minions to be more than half the level
            int clampedMaxMinions =
                Math.Min(maxMinions, (row - 1) * (col - 1) / 4);

            // Stops the number of Bosses to be more than half the level
            int clampedMaxBosses =
                Math.Min(maxBosses, (row - 1) * (col - 1) / 4);

            // Maximum amount of Minions
            maxMinions = rnd.Next(clampedMaxMinions);

            // Maximum amount of Minions
            maxBosses = rnd.Next(clampedMaxBosses);

            // Checks the maximum enemies total
            int maxEnemiesTotal = maxMinions + maxBosses;

            // Cycles through all the enemies
            for (int n = 0; n < maxEnemiesTotal; n++)
            {
                // Gets a new random position
                Position pos = GetRandomPosition();

                if (maxMinions > 0)
                {
                    // Adds the new minion to the list
                    AllEnemies.Add(new Minion(Room, Player, pos));

                    // Puts it on the board
                    Room[pos] = Piece.Enemy;

                    // Decrements one from maxMinions
                    maxMinions--;
                }
                else if (maxBosses > 0)
                {
                    // Adds the new Boss to the list
                    AllEnemies.Add(new Boss(Room, Player, pos));

                    // Puts it on the board
                    Room[pos] = Piece.Boss;

                    // Decrements one from maxBosses
                    maxBosses--;
                }
            }
        }

        /// <summary>
        /// Generates all the powerups for the level
        /// </summary>
        /// <param name="lvl"> The current level number </param>
        private void CreateNewPowerUps(int lvl)
        {
            // Logorithmic formula to find the max small power ups
            int maxSmallPower = (int)(-2 * Math.Log(0.01f * lvl));
            maxSmallPower = rnd.Next(1, maxSmallPower);

            // Logorithmic formula to find the max medium power ups
            int maxMedPower = (int)(-2.5f * Math.Log(0.02f * lvl));
            maxMedPower = rnd.Next(0, maxMedPower);

            // Logorithmic formula to find the max big powerups ups
            int maxBigPower = (int)(-3 * Math.Log(0.03f * lvl));
            maxBigPower = rnd.Next(0, maxBigPower);

            // Checks the maximum powerups total
            int maxPowerupTotal = maxSmallPower + maxMedPower + maxBigPower;

            // Cycles through all the powerups
            for (int n = 0; n < maxPowerupTotal; n++)
            {
                // Gets a new random position
                Position pos = GetRandomPosition();

                if (maxSmallPower > 0)
                {
                    // Adds the new powerup to the list
                    AllPowerUps.Add(new MiniHeal(Player, Room, pos));

                    // Puts it on the board
                    Room[pos] = Piece.PowerMin;

                    // Decrements maxSmallPower
                    maxSmallPower--;
                }
                else if (maxMedPower > 0)
                {
                    // Adds the new powerup to the list
                    AllPowerUps.Add(new MedHeal(Player, Room, pos));

                    // Puts it on the board
                    Room[pos] = Piece.PowerMed;

                    // Decrements maxMedPower
                    maxMedPower--;
                }
                else if (maxBigPower > 0)
                {
                    // Adds the new powerup to the list
                    AllPowerUps.Add(new BigHeal(Player, Room, pos));

                    // Puts it on the board
                    Room[pos] = Piece.PowerMax;

                    // Decrements maxBigPower
                    maxBigPower--;
                }
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
                Room[startPos] = Piece.Block;
            }
        }

        /// <summary>
        /// Generates a new position that is not coinciding with anything on
        /// the board
        /// </summary>
        /// <returns> A new random position </returns>
        private Position GetRandomPosition()
        {
            // Creates a new random position
            Position pos = new Position(rnd.Next(1, row + 1),
                rnd.Next(1, col + 1));

            // Cycles while that position is ocuppied
            while (Room[pos] != Piece.Empty)
            {
                // Sets pos to a new random one
                pos = new Position(rnd.Next(1, row + 1), rnd.Next(1, col + 1));
            }

            // Returns the found position
            return pos;
        }
    }
}