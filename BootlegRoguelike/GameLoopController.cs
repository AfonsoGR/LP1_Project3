using System;
using System.Threading;

namespace BootlegRoguelike
{
    /// <summary>
    /// Controls the call of the objects of the game
    /// </summary>
    public class GameLoopController
    {
        // The graphic renderer
        private Renderer graphics;

        // Stores the current scene
        private readonly SceneManager scene;

        /// <summary>
        /// Stores the current level
        /// </summary>
        public int CurrentLevel { get; private set; }

        /// <summary>
        /// Constructor of the GameController class
        /// </summary>
        /// <param name="rows"> Width of the room </param>
        /// <param name="cols"> Height of the board</param>
        /// <param name="lvl"> The starting level </param>
        public GameLoopController(int rows, int cols, int lvl = 1)
        {
            // Sets the current level to the one given
            CurrentLevel = lvl;

            // Creates a new Scene with the dimensions given
            scene = new SceneManager(cols, rows);

            // Generates all the objects of the game
            scene.GenerateNewScene(CurrentLevel);

            // Creates a new Renderer to display information
            graphics = new Renderer(scene.Room, scene.Player);

            // Starts the main Update for the game
            ScheduledUpdate();
        }

        /// <summary>
        /// Cycles while the player hasn't died
        /// </summary>
        private void ScheduledUpdate()
        {
            // Displays the starting board and a simple message
            graphics.Render("You already lost");

            // Main Loop of the game
            while (true)
            {
                // Moves the player and updates the visuals
                MovePlayer();

                // Checks if the player is stuck or died
                if (scene.Player.Gameover()) break;

                // Checks if the player is at the exit
                CheckIfOnExit();

                // Checks if the player is on a powerup
                UpdatePowerUps();

                // Moves the player and updates the visuals
                MovePlayer();

                // Checks if the player is stuck or died
                if (scene.Player.Gameover()) break;

                // Checks if the player is at the exit
                CheckIfOnExit();

                // Checks if the player is on a powerup
                UpdatePowerUps();

                // Asks all the AIs to perform their movement
                MoveEnemies();

                // Checks if the player is stuck or died
                if (scene.Player.Gameover()) break;

                // In case an AI was on top of a powerup updates the visuals
                UpdatePowerUps();
            }
        }

        /// <summary>
        /// Cycles through all the powerups for them to perform a player check
        /// </summary>
        private void UpdatePowerUps()
        {
            // The current HP of the player before receiving HP
            int currentHP = scene.Player.HP;

            // If the player was already healed once
            bool alreadyHealed = false;

            // Checks all powerups
            for (int i = 0; i < scene.AllPowerUps.Count; i++)
            {
                // Tells the powerups to check if the player is on top of them
                scene.AllPowerUps[i].CheckPlayer();

                // Checks if the position where they are is empty
                if (scene.Room[scene.AllPowerUps[i].Position] == Enums.Empty)
                {
                    // Re-adds them to the board
                    scene.Room[scene.AllPowerUps[i].Position] =
                        scene.AllPowerUps[i].Type;
                }

                // Checks if the player wasn't healed yet
                if (!alreadyHealed && scene.Player.HP != currentHP)
                {
                    // Sets the alreadyHealed to true
                    alreadyHealed = true;

                    // Renders the board displaying the amount of HP gained
                    graphics.Render($"Player was healed " +
                        $"{scene.Player.HP - currentHP} HP");

                    // Removes the consumed powerup from the list
                    scene.AllPowerUps.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Moves the player and updates the board
        /// </summary>
        private void MovePlayer()
        {
            // Stores the position before moving
            Position previousPos = scene.Player.Position;

            // Sets the position before moving to empty
            scene.Room[previousPos] = Enums.Empty;

            // Asks the player to perform the movement
            scene.Player.Movement();

            // Sets the new position of the player on the board
            scene.Room[scene.Player.Position] = Enums.Player;

            // Checks if the player didn't move
            if (scene.Player.Position.Row == previousPos.Row &&
                scene.Player.Position.Col == previousPos.Col)
            {
                // Shows the board with a simple message
                graphics.Render("You can't move there");
                // Calls this method again
                MovePlayer();
            }
            else
            {
                // Shows the board and where the player moved to
                graphics.Render($"Player moved to " +
                    $"({scene.Player.Position.Row}" +
                    $",{scene.Player.Position.Col})");
            }
        }

        /// <summary>
        /// Cycles through all enemies to perform their movement calculation
        /// </summary>
        private void MoveEnemies()
        {
            // Checks all the enemies on the scene
            for (int i = 0; i < scene.AllEnemies.Count; i++)
            {
                // Resets the position before moving to empty
                scene.Room[scene.AllEnemies[i].Position] = Enums.Empty;

                // Asks the AI to move
                scene.AllEnemies[i].Movement();

                // Sets the new position on the board to it's visuals
                scene.Room[scene.AllEnemies[i].Position] =
                    scene.AllEnemies[i].Type;

                // Shows the board and where the enemy moved to
                graphics.Render($"{scene.Room[scene.AllEnemies[i].Position]}" +
                    $" moved to ({scene.AllEnemies[i].Position.Row}," +
                    $"{scene.AllEnemies[i].Position.Col} )");

                // Stops the game in order for the player to see what happened
                Thread.Sleep(300);
            }
        }

        /// <summary>
        /// Checks if the player is at the position before the exit
        /// </summary>
        private void CheckIfOnExit()
        {
            // Creates a new position one step ahead on the X axis
            Position exitPos = new Position(scene.Player.Position.Row + 1,
                scene.Player.Position.Col);

            // Checks if the room is an exit on that position
            if (scene.Room[exitPos] == Enums.Exit)
            {
                // Increments the level by one
                CurrentLevel++;

                // Clears the console
                Console.Clear();
                // Displays a message
                Console.WriteLine($"\n\n\n        Now entering room:        ");
                // Displays the level the user will face next
                Console.WriteLine($"                {CurrentLevel}");

                // Stops the game for 2 seconds for visual purposes
                Thread.Sleep(2000);

                // Generates new obstacles, enemies and powerups
                scene.GenerateNewScene(CurrentLevel, false);

                // Creates a new Renderer with the info from the scene
                graphics = new Renderer(scene.Room, scene.Player);

                // Calls the Update again
                ScheduledUpdate();
            }
        }
    }
}