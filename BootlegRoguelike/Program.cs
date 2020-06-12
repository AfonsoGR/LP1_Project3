using System;

namespace BootlegRoguelike
{
    class Program
    {
        private MainMenu mainMenu;

        static void Main(string[] args)
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
                Console.WriteLine("Use the following commands:\n\t"
                    + "dotnet run -p BootlegRoguelike/ -- -r X -c Y\n\n"
                    + "OR\n\n\tdotnet run -- -r X -c Y\n\n"
                    + "Replace X and Y by any numeric values of your choice, "
                    + "you can also swap the order of '-r' and '-c' at will.");
            }
            else if (args[0] == "-r" && args[2] == "-c")
            {
                if (!Int32.TryParse(args[1], out rows))
                {
                    Console.WriteLine("You can't do that");
                    return;
                }
                if (!Int32.TryParse(args[3], out cols))
                {
                    Console.WriteLine("You can't do that");
                    return;
                }

                InitializeMainMenu(rows, cols);
            }
            else if (args[0] == "-c" && args[2] == "-r")
            {
                rows = Int32.Parse(args[3]);
                cols = Int32.Parse(args[1]);

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
    }
}
