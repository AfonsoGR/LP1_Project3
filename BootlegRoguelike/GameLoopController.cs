using System;
using System.Threading;

namespace BootlegRoguelike
{
    public class GameLoopController
    {
        private Renderer graphics;
        private readonly SceneManager scene;
        public int CurrentLevel { get; private set; }

        public GameLoopController(int rows, int cols, int lvl = 1)
        {
            CurrentLevel = lvl;

            scene = new SceneManager(cols, rows);

            scene.GenerateNewScene(CurrentLevel);

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

                UpdatePowerUps();

                MovePlayer();

                CheckIfOnExit();

                UpdatePowerUps();

                MoveEnemies();

                UpdatePowerUps();
            }
        }
        private void UpdatePowerUps()
        {
            int currentHP = scene.Player.HP;

            for (int i = 0; i < scene.PowerUps.Count; i++)
            {
                scene.PowerUps[i].CheckPlayer();


                if (scene.Player.HP != currentHP)
                {
                    graphics.Render($"Player was healed " +
                        $"{scene.Player.HP -currentHP} HP");

                    scene.PowerUps.RemoveAt(i);
                }
                else
                {
                    scene.Room[scene.PowerUps[i].Position] =
                        scene.PowerUps[i].Type;
                }
            }
        }
        private void MovePlayer()
        {
            Position previousPos = scene.Player.Position;

            scene.Room[scene.Player.Position] = Enums.Empty;

            ConsoleKey choice = ConsoleKey.NoName;

            while (choice != ConsoleKey.W && choice != ConsoleKey.A
                && choice != ConsoleKey.S && choice != ConsoleKey.D 
                && choice != ConsoleKey.UpArrow 
                && choice != ConsoleKey.DownArrow 
                && choice != ConsoleKey.LeftArrow 
                && choice != ConsoleKey.RightArrow)
            {
                choice = Console.ReadKey(true).Key;
            }

            scene.Player.Movement(choice);

            scene.Room[scene.Player.Position] = Enums.Player;

            if (scene.Player.Position.Row == previousPos.Row &&
                scene.Player.Position.Col == previousPos.Col)
            {
                graphics.Render("You can't move there");
                MovePlayer();
            }
            else
            {
                graphics.Render($"Player moved to " +
                    $"({scene.Player.Position.Row}" +
                    $",{scene.Player.Position.Col})");
            }
        }

        private void MoveEnemies()
        {
            for (int i = 0; i < scene.AllEnemies.Count; i++)
            {
                scene.Room[scene.AllEnemies[i].Position] = Enums.Empty;

                scene.AllEnemies[i].Movement();

                scene.Room[scene.AllEnemies[i].Position] = 
                    scene.AllEnemies[i].Type;

                graphics.Render($"{scene.Room[scene.AllEnemies[i].Position]}" +
                    $" moved to ({scene.AllEnemies[i].Position.Row}," +
                    $"{scene.AllEnemies[i].Position.Col} )");

                //Thread.Sleep(200);
            }
        }

        private void CheckIfOnExit()
        {
            Position exitPos = new Position(scene.Player.Position.Row + 1,
                scene.Player.Position.Col);

            if (scene.Room[exitPos] == Enums.Exit)
            {
                CurrentLevel++;

                scene.GenerateNewScene(CurrentLevel, false);

                graphics = new Renderer(scene.Room, scene.Player);

                ScheduledUpdate();
            }
        }
    }
}