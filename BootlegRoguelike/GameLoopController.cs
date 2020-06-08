using System;
using System.Collections.Generic;
using System.Text;

namespace BootlegRoguelike
{
    public class GameLoopController
    {
        private Renderer graphics;
        private SceneManager scene;
        private object save;
        private int lvl;

        public GameLoopController(int rows, int cols, int lvl = 0)
        {
            this.lvl = lvl;

            scene = new SceneManager(cols, rows, lvl);

            graphics = new Renderer(scene.Room);

            ScheduledUpdate();
        }

        private void ScheduledUpdate()
        {
            while (true)
            {
                MovePlayer();
                MovePlayer();
            }
        }
        private void MovePlayer()
        {
            char choice = ' ';

            graphics.Render();

            while (choice != 'W' && choice != 'A' && choice != 'S' && choice != 'D')
            {
                choice = Console.ReadLine().ToUpper()[0];
            }

            graphics.Render();
        }
    }
}
