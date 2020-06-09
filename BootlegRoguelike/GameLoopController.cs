using System;

namespace BootlegRoguelike
{
    public class GameLoopController
    {
        private Renderer graphics;
        private SceneManager scene;
        private int lvl;

        public GameLoopController(int rows, int cols, int lvl = 1)
        {
            this.lvl = lvl;

            scene = new SceneManager(cols, rows);

            scene.GenerateNewScene(lvl);

            graphics = new Renderer(scene.Room, scene.Player, scene.AllEnemies);


            ScheduledUpdate();
        }

        private void ScheduledUpdate()
        {
            while (true)
            {
                graphics.Render();
                MovePlayer();
                CheckIfOnExit();
            }
        }

        private void MovePlayer()
        {
            char choice = ' ';

            while (choice != 'W' && choice != 'A' && choice != 'S' && choice != 'D')
            {
                choice = char.ToUpper(Console.ReadKey(true).KeyChar);
            }

            scene.Player.Movement(choice);
        }

        private void CheckIfOnExit()
        {
            if (scene.Player.Position.Row == scene.Room.Exit.Row &&
                scene.Player.Position.Col == scene.Room.Exit.Col)
            {
                lvl++;

                scene.GenerateNewScene(lvl);

                graphics = new Renderer(scene.Room, scene.Player, scene.AllEnemies);

                ScheduledUpdate();
            }
        }
    }
}