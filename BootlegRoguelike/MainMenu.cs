using System;
using System.IO;
using System.Collections.Generic;

namespace BootlegRoguelike
{
    /// <summary>
    /// Manages the Main Menu of the game
    /// </summary>
    public class MainMenu
    {
        /// <summary>
        /// Gets and sets the value of Cols
        /// </summary>
        /// <value> Value of Cols </value>
        public int Cols {get; set;}
        
        /// <summary>
        /// Gets and sets the value of Rows
        /// </summary>
        /// <value> Value of Rows </value>
        public int Rows {get; set;}

        // Creates a variable of ScoresManager
        private ScoresManager scoresManager;

        // Creates a variable of GameLoopController
        private GameLoopController gameLoopController;

        // Creates a variable of InfoRules
        private InfoRules infoRules;

        /// <summary>
        /// Constructor to define rows and cols
        /// </summary>
        /// <param name="rows"> Value of rows </param>
        /// <param name="cols"> Value of cols </param>
        public MainMenu (int rows, int cols)
        {
            // Value of rows
            Rows = rows;
            // Value of rows
            Cols = cols;
            // Creates a new ScoresManager
            scoresManager = new ScoresManager(Rows, Cols);
        }

        /// <summary>
        /// Manages the startup menu and waits for user input
        /// Calls for respective method based on user input
        /// </summary>
        public void StartupMenu()
        {
            // Creates a new InfoRules
            infoRules = new InfoRules();

            // Displays on-screen text
            infoRules.WelcomeText();
            
            // Stores player choice
            int menuChoice;

            // Asks for input until a valid one is given
            while (!int.TryParse(Console.ReadLine(), out menuChoice)
                    || menuChoice < 1 || menuChoice > 5);
            
            // Selects section based on user input "menuChoice"
            switch (menuChoice)
            {
                // Executes if menuChoice is 1
                case 1:
                    // Starts a new game
                    NewGame();
                    // Exits the current switch section
                    break;
                // Executes if menuChoice is 2
                case 2:
                    // Displays top scores of the current board
                    Highscores();
                    // Exits the current switch section
                    break;
                // Executes if menuChoice is 3
                case 3:
                    // Displays on-screen text
                    Instructions();
                    // Exits the current switch section
                    break;
                // Executes if menuChoice is 4
                case 4:
                    // Displays on screen-text
                    Credits();
                    // Exits the current switch section
                    break;
                // Executes if menuChoice is 5
                case 5:
                    // Quits game
                    QuitGame();
                    // Exits the current switch section
                    break;
                // Executes if an invalid menuChoice is given
                default:
                    // Exits the current switch section
                    break;
            }
        }
        
        /// <summary>
        /// Starts a new game with given arguments
        /// </summary>
        public void NewGame()
        {
            // Creates a new Game Loop Controller with given arguments
            gameLoopController = new GameLoopController(Rows, Cols);
            // Registers user's score
            scoresManager.RegisterScores(gameLoopController.CurrentLevel);
            // Returns to StartupMenu
            StartupMenu();
        }

        /// <summary>
        /// Displays Top Scores fo the current board setup 
        /// and waits for user input before returning to the startup menu
        /// </summary>
        public void Highscores()
        {
            // Displays highscores 
            scoresManager.PrintHighcore();           
            // Displays on-screen text
            Console.WriteLine("Press any key to return to the main menu...");
            // Waits for user input
            Console.ReadKey();
            // Returns to StartupMenu
            StartupMenu();
        }

        /// <summary>
        /// Displays Intro text and waits for user input 
        /// before returning to the startup menu
        /// </summary>
        public void Instructions()
        {
            // Displays on-screen text
            infoRules.Intro();
            // Displays on-screen text
            Console.WriteLine("Press any key to return to the main menu...");
            // Waits for user input
            Console.ReadKey();
            // Returns to StartupMenu
            StartupMenu();
        }

        /// <summary>
        /// Displays Credits text and waits for user input 
        /// before returning to the startup menu
        /// </summary>
        public void Credits()
        {
            // Creates a new InfoRules
            infoRules = new InfoRules();
            // Displays on-screen text
            infoRules.Credits();
            // Displays on-screen text
            Console.WriteLine("Press any key to return to the main menu...");
            // Waits for user input
            Console.ReadKey();
            // // Returns to StartupMenu
            StartupMenu();            
        }

        /// <summary>
        /// Asks player if he wants to exit the game 
        /// and either leaves or returns to the startup menu
        /// </summary>
        public void QuitGame()
        {
            // Displays on-screen text
            Console.WriteLine("Are you certain of this?\t(y/n)");
            // Stores user input in quitChoice variable
            string quitChoice = Console.ReadLine();
            // Converts string to lower case
            quitChoice = quitChoice.ToLower();
            // Checks if the quitchoice variable has specified values
            if (quitChoice == "y")
            {
                // Exists the game
                System.Environment.Exit(1);
            }
            // Checks if the quitChoice variable has specified values
            else if (quitChoice == "n")
                // Returns to StartupMenu
                StartupMenu();
            // Previous conditions were not met
            else
            {
                // Displays on-screen text
                Console.WriteLine("Please input a valid choice...");
                // Returns to QuitGame
                QuitGame();
            }            
        }
    }
}