using System;

namespace BootlegRoguelike
{
    public class MainMenu
    {
        private int cols {get; set;}
        private int rows {get; set;}

        private InfoRules infoRules;
        private ScoresManager scoresManager;

        private void StartupMenu()
        {
            infoRules = new InfoRules();

            infoRules.WelcomeText();

            int menuChoice;

            while (!int.TryParse(Console.ReadLine(), out menuChoice)
                    || menuChoice < 1 || menuChoice > 5)

            switch (menuChoice)
            {
                case 1:
                    NewGame(cols, rows);
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
                    Quit();
                    break;
                default:
                    break;
            }
        }
        
        private void NewGame(int cols, int rows)
        {
            // Console.WriteLine("How big do you wish the board to be?");
            // Console.Write("Rows -> ");
            // while (!int.TryParse(Console.ReadLine(), out rows));
            // Console.Write("Columns -> ");
            // while (!int.TryParse(Console.ReadLine(), out cols));

            //! Reference
            // if (args[b] == 'r')
            // {
            //     rows = (int)args[b+1];
            // }
        }

        private void Highscores()
        {
            scoresManager = new ScoresManager();

            scoresManager.DisplayScores();
        }

        private void Instructions()
        {
            infoRules.Intro();
        }

        private void Credits()
        {
            infoRules.Credits();            
        }

        private void Quit()
        {
            string quitChoice;

            Console.WriteLine("Are you certain of this?\t(y/n)");

            quitChoice = Console.ReadLine();
            quitChoice.ToLower();
            
            if (quitChoice == "y")
                System.Environment.Exit(1);
            else if (quitChoice == "n")
                StartupMenu();
            else
            {
                Console.WriteLine("Please input a valid choice...");
                Quit();
            }            
        }
    }
}