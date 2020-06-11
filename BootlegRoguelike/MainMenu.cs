using System;

namespace BootlegRoguelike
{
    public class MainMenu
    {
        public int Cols {get; set;}
        public int Rows {get; set;}

        private ScoresManager scoresManager;
        private GameLoopController gameLoopController;

        public void StartupMenu()
        {
            InfoRules.WelcomeText();

            int menuChoice;

            while (!int.TryParse(Console.ReadLine(), out menuChoice)
                    || menuChoice < 1 || menuChoice > 5);
            
            switch (menuChoice)
            {
                case 1:
                    NewGame();
                    break;
                case 2:
                    Highscores();
                    break;
                case 3:
                    Instructions();
                    break;
                case 4:
                    Credits();
                    break;
                case 5:
                    QuitGame();
                    break;
                default:
                    break;
            }
        }
        
        public void NewGame()
        {
            gameLoopController = new GameLoopController(Rows, Cols);
        }

        public void Highscores()
        {
            scoresManager = new ScoresManager();

            //! TESTING-------------------------------------------------------
            //scoresManager.RegisterScores();
            //! TESTING-------------------------------------------------------

            //scoresManager.DisplayTopScores();
            
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();

            StartupMenu();
        }

        public void Instructions()
        {   
            InfoRules.Intro();

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();

            StartupMenu();
        }

        public void Credits()
        {
            InfoRules.Credits();

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();

            StartupMenu();            
        }

        public void QuitGame()
        {
            Console.WriteLine("Are you certain of this?\t(y/n)");

            string quitChoice = Console.ReadLine();
            
            if (quitChoice == "y" || quitChoice == "Y")
                System.Environment.Exit(1);
            else if (quitChoice == "n" || quitChoice == "N")
                StartupMenu();
            else
            {
                Console.WriteLine("Please input a valid choice...");
                QuitGame();
            }            
        }
    }
}