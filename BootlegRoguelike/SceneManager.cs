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
        public object[] PowerUps { get; private set; }

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
            CreateNewEnemies(lvl);
            CreateNewPlayer();

            if (hp != -1)
            {
                Player.HP = hp;
            }
        }
        private void CreateNewPlayer()
        {
            Player = new Player(row, col);
        }

        private void CreateNewEnemies(int lvl)
        {
            int x = (int)(11 * Math.Log(3.3 * lvl));
            x = rnd.Next(x);

            for (int n = 0; n < x; n++)
            {
                AllEnemies.Add(new Enemies());
            }
        }

        private void CreateNewPowerUps()
        {

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