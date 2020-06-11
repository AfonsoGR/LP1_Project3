using System;
using System.Threading;

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

                CheckIfOnExit();

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
                string tmp = Console.ReadLine().ToUpper();
                choice = tmp.Length >= 1 ? tmp[0] : ' ';

                //choice = char.ToUpper(Console.ReadKey(true).KeyChar);
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

                graphics.Render(scene.Room[scene.AllEnemies[i].Position] + 
                    " moved");
            }
        }

        private void CheckIfOnExit()
        {
            Position exitPos = new Position(scene.Player.Position.Row + 1,
                scene.Player.Position.Col);

            if (scene.Room[exitPos] == Enums.Exit)
            {
                lvl++;

                scene.GenerateNewScene(lvl, false);

                graphics = new Renderer(scene.Room, scene.Player);

                ScheduledUpdate();
            }
        }
    }
}