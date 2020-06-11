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

            graphics = new Renderer(scene.Room, scene.Player);

            ScheduledUpdate();
        }

        private void ScheduledUpdate()
        {
            graphics.Render("You already lost");

            while (true)
            {
                MovePlayer();
                MovePlayer();

                CheckIfOnExit();

                MoveEnemies();
            }
        }

        private void MovePlayer()
        {
            scene.Room[scene.Player.Position] = Enums.Empty;

            char choice = ' ';

            while (choice != 'W' && choice != 'A'
                && choice != 'S' && choice != 'D')
            {
                choice = char.ToUpper(Console.ReadKey(true).KeyChar);
            }

            scene.Player.Movement(choice);

            scene.Room[scene.Player.Position] = Enums.Player;

            graphics.Render("Player Moved");
        }

        private void MoveEnemies()
        {
            for (int i = 0; i < scene.AllEnemies.Count; i++)
            {
                scene.Room[scene.AllEnemies[i].Position] = Enums.Empty;

                scene.AllEnemies[i].Movement();

                scene.Room[scene.AllEnemies[i].Position] =
                    scene.AllEnemies[i] is Boss ? Enums.Boss : Enums.Enemy;

                graphics.Render("Hello");
            }
        }

        private void CheckIfOnExit()
        {
            if (scene.Room[scene.Player.Position] == Enums.Exit)
            {
                lvl++;

                scene.GenerateNewScene(lvl, false);

                graphics = new Renderer(scene.Room, scene.Player);

                ScheduledUpdate();
            }
        }
    }
}