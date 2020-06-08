using System;

namespace BootlegRoguelike
{
    public class SceneManager
    {
        private readonly Random rnd;
        private readonly int col;
        private readonly int row;
        private readonly int lvl;

        public RoomGenerator Room { get; }
        
        public Player Player { get; private set; }
        public Enemies[] AllEnemies { get; private set; }
        public object[] PowerUps { get; private set; }

        public SceneManager(int row, int col, int lvl)
        {
            this.lvl = lvl;
            this.col = col;
            this.row = row;

            rnd = new Random();
            Room = new RoomGenerator();

            CreateNewRoomStructure();
            CreateNewPlayer();
            CreateNewEnemies();
        }

        private void CreateNewPlayer()
        {
            Player = new Player(row, col);
        }

        private void CreateNewEnemies()
        {
            int x = (int)(11 * Math.Log(3.3 * lvl));
            x = rnd.Next(x);

            AllEnemies = new Enemies[x];

            for (int n = 0; n < x; n++)
            {
                AllEnemies[n] = new Enemies();
            }
        }

        private void CreateNewPowerUps()
        {
        }

        private void CreateNewRoomStructure()
        {
            Room.SetBoardToInitState(row, col, rnd.Next(1, col - 1));
        }
    }
}