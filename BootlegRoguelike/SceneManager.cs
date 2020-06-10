using System;
using System.Collections.Generic;

namespace BootlegRoguelike
{
    public class SceneManager
    {
        private readonly Random rnd;
        private readonly int col;
        private readonly int row;

        public RoomGenerator Room { get; }
        
        public Player Player { get; private set; }
        public List<Enemies> AllEnemies { get; private set; }
        public List<Powerup> PowerUps { get; private set; }

        public SceneManager(int row, int col)
        {
            this.col = col;
            this.row = row;

            rnd = new Random();
            Room = new RoomGenerator();
        }
        public void GenerateNewScene(int lvl, bool generatePlayer = true)
        {
            AllEnemies = new List<Enemies>();

            int hp = -1;

            if (!generatePlayer)
                hp = Player.HP;

            CreateNewRoomStructure();
            CreateNewPlayer();
            CreateNewEnemies(lvl);

            if (hp != -1)
            {
                Player.HP = hp;
            }
        }
        private void CreateNewPlayer()
        {
            Player = new Player(row, col, Room);
        }

        private void CreateNewEnemies(int lvl)
        {
            int maxEnemies = (int)(11 * Math.Log(3.3 * lvl));
            maxEnemies = Math.Min(maxEnemies, ((row - 2) * (col - 2)) / 2);

            int maxMinions = rnd.Next(maxEnemies);
            int maxBosses = rnd.Next(Math.Abs(maxMinions - maxEnemies));

            for (int n = 0; n < maxMinions; n++)
            {
                Position pos = new Position(rnd.Next(1, row - 1), 
                    rnd.Next(1, col - 2));

                AllEnemies.Add(new Minion(Room, Player,pos));

                Room[pos] = Enums.Enemy;
            }

            for (int c = 0; c < maxBosses; c++)
            {
                Position pos = new Position(rnd.Next(1, row - 1), 
                    rnd.Next(1, col - 2));

                AllEnemies.Add(new Minion(Room, Player, pos));

                Room[pos] = Enums.Boss;
            }
        }

        private void CreateNewPowerUps(int lvl)
        {
            int maxPowerUps = (int)(11 * Math.Log(5 * lvl));

            
        }

        private void CreateNewRoomStructure()
        {
            Room.SetBoardToInitState(row, col, rnd.Next(1, col - 1));

            int nObstacles = rnd.Next(Math.Min(row, col) - 1);

            for (int i = 0; i < nObstacles; i++)
            {
                Position startPos =
                    new Position(rnd.Next(1, row - 2), rnd.Next(1, col - 2));

                Room[startPos] = Enums.Block;
            }
        }
    }
}