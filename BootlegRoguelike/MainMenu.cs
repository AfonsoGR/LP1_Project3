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

        /// <summary>
        /// Creates a variable of ScoresManager
        /// </summary>
        private ScoresManager scoresManager;

        /// <summary>
        /// Creates a variable of GameLoopController
        /// </summary>
        private GameLoopController gameLoopController;

        /// <summary>
        /// Creates a variable of InfoRules
        /// </summary>
        private InfoRules infoRules;

        public MainMenu ()
        {
            scoresManager = new ScoresManager();
        }

        /// <summary>
        /// Manages the startup menu and waits for user input
        /// Calls for respective method based on user input
        /// </summary>
        public void StartupMenu()
        {
            // Creates a new InfoRules
            infoRules = new InfoRules();

            // Calls WelcomeText method from InfoRules.cs
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
                    // Calls NewGame method from this class
                    NewGame();
                    // Exits the current switch section
                    break;
                // Executes if menuChoice is 1
                case 2:
                    // Calls Highscores method from this class
                    Highscores();
                    // Exits the current switch section
                    break;
                // Executes if menuChoice is 1
                case 3:
                    // Calls Instructions method from this class
                    Instructions();
                    // Exits the current switch section
                    break;
                // Executes if menuChoice is 1
                case 4:
                    // Calls Credits method from this class
                    Credits();
                    // Exits the current switch section
                    break;
                // Executes if menuChoice is 1
                case 5:
                    // Calls QuitGame method from this class
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
            scoresManager.RegisterScores(gameLoopController.CurrentLevel);
            StartupMenu();
        }

        /// <summary>
        /// Displays Top Scores and wait for user input 
        /// before returning to the startup menu
        /// </summary>
        public void Highscores()
        {
            

            //////////////////////////scoresManager.PrintHighcore();
            // Creates a new Scores Manager
            //scoresManager.RegisterScores();

            // Calls DisplayTopScores method from ScoresManager.cs
            //scoresManager.DisplayTopScores();
            
            // Displays on-screen text
            Console.WriteLine("Press any key to return to the main menu...");
            // Waits for user input
            Console.ReadKey();
            // Calls StartupMenu method from this class
            StartupMenu();
        }

        /// <summary>
        /// Displays Intro text and waits for user input 
        /// before returning to the startup menu
        /// </summary>
        public void Instructions()
        {
            // Creates a new InfoRules
            infoRules = new InfoRules();

            // Calls Intro method from InfoRules.cs
            infoRules.Intro();

            // Displays on-screen text
            Console.WriteLine("Press any key to return to the main menu...");
            //Waits for user input
            Console.ReadKey();
            // Calls StartupMenu method from this class
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

            // Calls Credtis method from InfoRules.cs
            infoRules.Credits();

            // Displays on-screen text
            Console.WriteLine("Press any key to return to the main menu...");
            // Waits for user input
            Console.ReadKey();
            // Calls StartupMenu method from this class
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
            // Checks if the quitchoice variable has specified values
            if (quitChoice == "y" || quitChoice == "Y")
            {
                scoresManager.Close();
                // Exists the game
                System.Environment.Exit(1);
            }
            // Checks if the quitChoice variable has specified values
            else if (quitChoice == "n" || quitChoice == "N")
                // Calls StartupMenu method from this class
                StartupMenu();
            // Previous conditions were not met
            else
            {
                // Displays on-screen text
                Console.WriteLine("Please input a valid choice...");
                // Calls QuitGame method from this class
                QuitGame();
                scoresManager.Close();
            }            
        }
    }
}