using System;

namespace BootlegRoguelike
{
    public class MainMenu
    {
        private int cols;
        private int rows;

        private StartupMenu(int menuChoice)
        {
            Console.WriteLine("Hello and Welcome to...\n\tBOOTLEG ROGUELIKE" +
                "\n\nPlease select one of the following options:\n" +
                "\t1 - New Game\n\t2 - High scores\n\t3 - Instructions\n\t" + 
                "4 - Credits\n\t5 - Quit\n\n Select an option using the " + 
                "numbers...");

            //menuChoice = Convert.ToInt32(Console.ReadKey());

            while (!int.TryParse(Console.ReadKey(), menuChoice)
                    || menuChoice < 1 || menuChoice > 5)

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
        {}

        private void Credits()
        {}

        private void Quit()
        {
            System.Environment.Exit(1);
        }
    }
}