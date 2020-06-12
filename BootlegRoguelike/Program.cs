using System;

namespace BootlegRoguelike
{
    /// <summary>
    /// Main class of the program, checks for argument inputs and
    /// calls StartupMenu
    /// </summary>
    class Program
    {
        // Creates a variable of MainMenu
        private MainMenu mainMenu;

        /// <summary>
        /// Program initialization and GameStart
        /// </summary>
        /// <param name="args"> Arguments passed through console </param>
        private static void Main(string[] args)
        {
            // Creates a variable of Program
            Program program;
            // Creates a new program instance
            program = new Program();
            // Calls GameStart method from this class
            program.GameStart(args);
        }

        /// <summary>
        /// Checks passed arguments through the console
        /// </summary>
        /// <param name="args"> Arguments passed through console </param>
        private void GameStart(string[] args)
        {
            // Creates integer variable rows
            int rows;
            // Creates integer variable cols
            int cols;

            SavesManager saves = new SavesManager();

            // Checks if the input arguments are valid
            if (args[0] == "-l")
            {
                // Stores all the variables from the same
                (int row, int col, int lvl, int hp) savedVariables =
                    saves.LoadSave(args[1]);

                // Checks of any of the variables is 0
                if (savedVariables.row == 0 || savedVariables.col == 0
                    || savedVariables.lvl == 0 || savedVariables.hp == 0)
                {
                    // Displays an error message to the user
                    Console.WriteLine("No save was found or is currupted\n");
                    ErrorMessage();
                }
                else
                {
                    // Starts the main menu
                    InitializeMainMenu(savedVariables.row, savedVariables.col,
                        savedVariables.lvl, savedVariables.hp);
                }
            }
            // Checks if the input arguments are invalid
            else if (args == null || args.Length == 0 ||
                args[0] != "-r" && args[2] != "-c" &&
                args[0] != "-c" && args[2] != "-r")
            {
                // Displays error message
                ErrorMessage();
            }
            // Checks if the input arguments are valid
            else if (args[0] == "-r" && args[2] == "-c")
            {
                // Checks if the input arguments can't be converted to integers
                if (!int.TryParse(args[1], out rows))
                {
                    // Displays error message
                    ErrorMessage();
                    // Terminates method execution
                    return;
                }
                // Checks if the input arguments can't be converted to integers
                if (!int.TryParse(args[3], out cols))
                {
                    // Displays error message
                    ErrorMessage();
                    // Terminates method execution
                    return;
                }
                // Initializes the MainMenu
                InitializeMainMenu(rows, cols);
            }
            // Checks if the input arguments are valid
            else if (args[0] == "-c" && args[2] == "-r")
            {
                // Checks if the input arguments can't be converted to integers
                if (!int.TryParse(args[3], out rows))
                {
                    // Displays error message
                    ErrorMessage();
                    // Terminates method execution
                    return;
                }
                // Checks if the input arguments can't be converted to integers
                if (!int.TryParse(args[1], out cols))
                {
                    // Displays error message
                    ErrorMessage();
                    // Terminates method execution
                    return;
                }
                // Initializes the MainMenu
                InitializeMainMenu(rows, cols);
            }
        }

        /// <summary>
        /// MainMenu initialization and StartupMenu
        /// </summary>
        /// <param name="rows"> Value of rows </param>
        /// <param name="cols"> Value of cols </param>
        private void InitializeMainMenu(int rows, int cols,
            int lvl = 1, int hp = 0)
        {
            // Creates a new MainMenu instance
            mainMenu = new MainMenu(rows, cols, lvl, hp);
            // Calls StartupMenu method from MainMenu class
            mainMenu.StartupMenu();
        }

        /// <summary>
        /// Displays text message
        /// </summary>
        private void ErrorMessage()
        {
            // Displays on-screen text
            Console.WriteLine("Use the following commands:\n\n\t"
                + "dotnet run -p BootlegRoguelike/ -- -r X -c Y\n\n"
                + "OR\n\n\tdotnet run -- -r X -c Y\n\n"
                + "Replace X and Y by any numeric values of your choice, "
                + "you can also swap the order of '-r' and '-c' at will.\n"
                + "If you wish to load the file instead use:\n\t"
                + " \n\n\tdotnet run -- -l (File name)\n\n");
        }
    }
}