using System;

namespace BootlegRoguelike
{
    public class MainMenu
    {
        private int cols {get; set;}
        private int rows {get; set;}

        private InfoRules infoRules;

        private void StartupMenu(int menuChoice)
        {
            infoRules = new InfoRules();

            infoRules.WelcomeText();

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
            //! Reference
            // if (args[b] == 'r')
            // {
            //     rows = (int)args[b+1];
            // }
        }

        private void Highscores()
        {}

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
            System.Environment.Exit(1);
        }
    }
}