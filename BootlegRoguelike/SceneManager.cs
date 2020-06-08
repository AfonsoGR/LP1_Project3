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

        public RoomGenerator Room { get; }

        public SceneManager(int col, int row)
        {
            this.col = col;
            this.row = row;

            rnd = new Random();
            Room = new RoomGenerator();
            CreateNewRoomStructure();
        }
        private void CreateNewPlayer()
        {

        }
        private void CreateNewEnemies()
        {

        }
        private void CreateNewPowerUps()
        {

        }
        private void CreateNewRoomStructure()
        {
            Room.SetBoardToInitState(col, row, rnd.Next(1, row));
        }
    }
}
