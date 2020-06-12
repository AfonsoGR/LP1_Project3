using System;
using System.IO;

namespace BootlegRoguelike
{
    /// <summary>
    /// Manages the loading and saving of the game
    /// </summary>
    public class SavesManager
    {
        // Constant variable, name of the folder
        private const string folderName = "BootlegSaves";

        // Constant variable, separator
        public const char tab = '\t';

        // The path where the file is stored
        private readonly string filepath;

        // The path where the folder is stored
        private readonly string folderpath;

        /// <summary>
        /// Constructor, initializes variables and creates save files if needed
        /// </summary>
        public SavesManager()
        {
            // Assigns value to filepath
            filepath = Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments);

            // Assigns value to folderpath
            // and combines the filepath with the respective folder
            folderpath = Path.Combine(filepath, folderName);

            //Checks if the folder exists in the respective directory
            if (!Directory.Exists(folderpath))
            {
                // Creates the folder
                Directory.CreateDirectory(folderpath);
            }
        }

        /// <summary>
        /// Saves the game
        /// </summary>
        public void SaveGame(int r, int c, int lvl, int hp)
        {
            // Displays a message to the user
            Console.WriteLine("What's the name of the file?");

            // Gets input from the user
            string name = Console.ReadLine();

            // Checks if the name given contains spaces
            while (name.Contains(' '))
            {
                // Asks for input again
                Console.WriteLine("The name can't contain spaces!");
                name = Console.ReadLine();
            }

            string file = Path.Combine(folderpath, name);
            file += ".txt";

            // Creates the file and closes the process
            File.Create(file).Close();

            // Creates a string with each of the variables
            string text = r + tab.ToString() + c + tab.ToString()
                + lvl + tab.ToString() + hp;

            // Writes the save text value into the file
            File.WriteAllText(file, text);
        }

        /// <summary>
        /// Loads the save
        /// </summary>
        public (int, int, int, int) LoadSave(string name)
        {
            // Creates the full path to the file
            string file = Path.Combine(folderpath, name + ".txt");

            // Stores the parsed rows
            int rows = 0;
            // Stores the parsed cols
            int cols = 0;
            // Stores the parsed level
            int lvl = 0;
            // Stores the parsed hp
            int hp = 0;

            if (Directory.Exists(folderpath))
            {
                //Checks if the file exists in the respective file
                if (File.Exists(file))
                {
                    // Assigns all lines in the file to a string in an array
                    string[] array = File.ReadAllLines(file);

                    // Runs thorugh every string in the array
                    foreach (string line in array)
                    {
                        // Separates names from scores
                        string[] values = line.Split(tab);

                        // If the array is smaller than the arguments count
                        if (values.Length < 4)
                        {
                            break;
                        }

                        // Assgins value to rows
                        if (!int.TryParse(values[0], out rows))
                        {
                            // Displays where the save file is currupted
                            Console.WriteLine("Bad Data at getting rows");
                        }
                        // Assgins value to cols
                        if (!int.TryParse(values[1], out cols))
                        {
                            // Displays where the save file is currupted
                            Console.WriteLine("Bad Data at getting cols");
                        }
                        // Assgins value to lvl
                        if (!int.TryParse(values[2], out lvl))
                        {
                            // Displays where the save file is currupted
                            Console.WriteLine("Bad Data at getting level");
                        }
                        // Assgins value to hp
                        if (!int.TryParse(values[3], out hp))
                        {
                            // Displays where the save file is currupted
                            Console.WriteLine("Bad Data at getting hp");
                        }
                        Console.WriteLine();
                    }
                }
            }
            // Returns the parsed data
            return (rows, cols, lvl, hp);
        }
    }
}