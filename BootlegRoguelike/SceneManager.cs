using System;
using System.Collections.Generic;
using System.Text;

namespace BootlegRoguelike
{
    class SceneManager
    {
        object physics;
        private Random rnd;
        private int col;
        private int row;
        private int lvl;
        public RoomGenerator Room { get; }

        public Player Player { get; private set; }
        public object[] Enemies { get; private set; }
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
        }
        private void CreateNewPlayer()
        {
            Player = new Player(row, col);
        }
        private void CreateNewEnemies()
        {

        }
        private void CreateNewPowerUps()
        {

        }
        private void CreateNewRoomStructure()
        {
            Room.SetBoardToInitState(row, col, rnd.Next(1, col -1));
        }
    }
}
