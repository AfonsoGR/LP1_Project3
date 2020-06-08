using System;
using System.Collections.Generic;
using System.Text;

namespace BootlegRoguelike
{
    public class GameLoopController
    {
        private Renderer graphics;
        private SceneManager scene;
        private int lvl;
        private int rows;
        private int cols;

        public GameLoopController(int rows, int cols, int lvl = 1)
        {
            this.lvl = lvl;
            this.rows = rows;
            this.cols = cols;

            scene = new SceneManager(cols, rows, lvl);

            graphics = new Renderer(scene.Room);

            ScheduledUpdate();
        }

        private void ScheduledUpdate()
        {
            while (true)
            {
                MovePlayer();
                CheckIfOnExit();
            }
        }
        private void MovePlayer()
        {
            char choice = ' ';

            scene.Room[scene.Player.Position.Row, scene.Player.Position.Col] = '@';

            graphics.Render();

            scene.Room[scene.Player.Position.Row, scene.Player.Position.Col] = '.';

            while (choice != 'W' && choice != 'A' && choice != 'S' && choice != 'D')
            {
                choice = Console.ReadLine().ToUpper()[0];
            }

            scene.Player.Movement(choice);

            scene.Room[scene.Player.Position.Row, scene.Player.Position.Col] = '@';

            graphics.Render();

            scene.Room[scene.Player.Position.Row, scene.Player.Position.Col] = '.';
        }
        private void CheckIfOnExit()
        {
            if (scene.Player.Position.Row == scene.Room.Exit.Row &&
                scene.Player.Position.Col == scene.Room.Exit.Col)
            {
                scene = new SceneManager(cols, rows, lvl++);

                graphics = new Renderer(scene.Room);

                ScheduledUpdate();
            }
        }
    }
}
