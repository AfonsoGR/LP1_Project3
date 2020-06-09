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
        public void GenerateNewScene(int lvl)
        {
            AllEnemies = new List<Enemies>();

            CreateNewRoomStructure();
            CreateNewPlayer();
            CreateNewEnemies(lvl);
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
        }
    }
}