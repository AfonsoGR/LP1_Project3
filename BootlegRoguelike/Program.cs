using System;

namespace BootlegRoguelike
{
    internal class Program
    {
        private MainMenu mainMenu;

        private static void Main(string[] args)
        {
            Program program;
            program = new Program();
            program.GameStart(args);
        }

        private void GameStart(string[] args)
        {
            int rows;
            int cols;

            if (args == null || args.Length == 0 ||
                args[0] != "-r" && args[2] != "-c" &&
                args[0] != "-c" && args[2] != "-r")
            {
                ErrorMessage();
            }
            else if (args[0] == "-r" && args[2] == "-c")
            {
                if (!int.TryParse(args[1], out rows))
                {
                    ErrorMessage();
                    return;
                }
                if (!int.TryParse(args[3], out cols))
                {
                    ErrorMessage();
                    return;
                }
                InitializeMainMenu(rows, cols);
            }
            else if (args[0] == "-c" && args[2] == "-r")
            {
                if (!int.TryParse(args[3], out rows))
                {
                    ErrorMessage();
                    return;
                }
                if (!int.TryParse(args[1], out cols))
                {
                    ErrorMessage();
                    return;
                }
                InitializeMainMenu(rows, cols);
            }
        }

        private void InitializeMainMenu(int rows, int cols)
        {
            mainMenu = new MainMenu
            {
                Rows = rows,
                Cols = cols
            };

            mainMenu.StartupMenu();
        }

        private void ErrorMessage()
        {
            Console.WriteLine("Use the following commands:\n\t"
                + "dotnet run -p BootlegRoguelike/ -- -r X -c Y\n\n"
                + "OR\n\n\tdotnet run -- -r X -c Y\n\n"
                + "Replace X and Y by any numeric values of your choice, "
                + "you can also swap the order of '-r' and '-c' at will.");
        }
    }
}