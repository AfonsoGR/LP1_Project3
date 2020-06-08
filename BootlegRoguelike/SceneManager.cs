using System;
using System.Collections.Generic;
using System.Text;

namespace BootlegRoguelike
{
    class SceneManager
    {
        object[] ents;
        object physics;
        private Random rnd;
        private int col;
        private int row;
        private RoomGenerator room;

        public SceneManager(int col, int row)
        {
            this.col = col;
            this.row = row;

            rnd = new Random();
            room = new RoomGenerator();
            CreateNewRoomStructure();
            Renderer a = new Renderer(room);
            a.Render();
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
        private void CreateNewExitPortal()
        {

        }
        private void CreateNewRoomStructure()
        {
            room.SetBoardToInitState(col, row);
        }
    }
}
