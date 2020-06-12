using System;
using System.Collections.Generic;
using System.IO;

namespace BootlegRoguelike
{
    /// <summary>
    /// Manages registering, comparing, ordering and displaying scores
    /// </summary>
    public class ScoresManager
    {
        // Constant variable, portion of the filename
        private const string scoresFile = "highscores";

        // Constant variable, name of the folder
        private const string folderName = "BootlegScores";

        // Constant variable, extension of the filename
        private const string fileExtension = ".txt";

        // Constant variable, separator
        public const char tab = '\t';

        // Max number of files in the score file
        private const int maxScoresInFiles = 10;

        // The path where the file is stored
        private readonly string filepath;

        // The path where the folder is stored
        private readonly string folderpath;

        // The final name of the folder
        private readonly string finalFileName;

        // The user's name
        private string nameRegister;

        // The user's final score
        private int finalScore;

        // Collection of scores
        private readonly List<Highscore> scores;

        /// <summary>
        /// Constructor, initializes variables and creates save files if needed
        /// </summary>
        /// <param name="rows"> Value of rows </param>
        /// <param name="cols"> Value of cols </param>
        public ScoresManager(int rows, int cols)
        {
            // Assigns value to finalFileName
            finalFileName = scoresFile + rows + '_' + cols + fileExtension;

            // Assigns value to filepath
            filepath = Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments);
            // Assigns value to folderpath
            // and combines the filepath with the respective folder
            folderpath = Path.Combine(filepath, folderName);
            // Assigns value to filepath
            // and combines the folderpath with the respective file
            filepath = Path.Combine(folderpath, finalFileName);
            // Assigns value to scores
            scores = new List<Highscore>();
            // Checks if the folder exists in the respective directory
            if (Directory.Exists(folderpath))
            {
                // Checks if the file exists in the respective file
                if (File.Exists(filepath))
                {
                    // Fetch scores
                    FetchScores();
                }
                // Previous conditions weren't met
                else
                {
                    // Create scores file
                    CreateScoreFile();
                }
            }
            // Previous conditions weren't met
            else
            {
                // Create scores folder
                CreateScoreFolder();
                // Create scores file
                CreateScoreFile();
            }
        }

        /// <summary>
        /// Creates the score file in the respective directory
        /// </summary>
        private void CreateScoreFile()
        {
            // Creates the file and closes the process
            File.Create(filepath).Close();
        }

        /// <summary>
        /// Creates the score folder in the respective directory
        /// </summary>
        private void CreateScoreFolder()
        {
            // Creates the folder
            Directory.CreateDirectory(folderpath);
        }

        /// <summary>
        /// Registers user's scores
        /// </summary>
        public void RegisterScores(int score)
        {
            // Checks if the score can't be inserted
            if (!CanBeInserted(score))
            {
                // Terminates method execution
                return;
            }

            // Displays on-screen text
            Console.WriteLine("Register your name for the leaderboards:\t");
            // Stores user input
            nameRegister = Console.ReadLine();
            // Assigns value to final score
            finalScore = score;

            // Creates a new highscore
            Highscore newHighscore = new Highscore(nameRegister, finalScore);
            // Adds to collection
            scores.Add(newHighscore);
            // Sorts scores in collection
            scores.Sort();
            // Checks if scores in the file surpasses its wished limit
            if (scores.Count > maxScoresInFiles)
            {
                scores.RemoveAt(scores.Count - 1);
            }
            // Saves scores
            SaveScores();
        }

        /// <summary>
        /// Displays user's top 10 scores in respective file
        /// </summary>
        public void FetchScores()
        {
            // Assigns all lines in the file to a string in an array
            string[] array = File.ReadAllLines(filepath);

            // Runs through every string in the array
            foreach (string line in array)
            {
                // Separates names from scores
                string[] values = line.Split(tab);
                // Assigns value to name
                nameRegister = values[0];
                // Assigns value to score and converts it to an integer
                finalScore = int.Parse(values[1]);
                // Adds name and score to collection
                scores.Add(new Highscore(nameRegister, finalScore));
            }
        }

        /// <summary>
        /// Displays names and scores on the screen
        /// </summary>
        public void PrintHighcore()
        {
            // Runs through every highscore in the scores collection
            foreach (Highscore highscore in scores)
            {
                // Displays each highscore on the screen
                Console.WriteLine(highscore);
            }
        }

        /// <summary>
        /// Saves highscores into the file
        /// </summary>
        private void SaveScores()
        {
            // Assigns value to scorestext
            string scorestext = "";

            // Runs through every highscore in the scores collection
            foreach (Highscore highscore in scores)
            {
                // Adds a line with name and score
                scorestext += highscore;
                // Add a new line
                scorestext += "\n";
            }
            // Writes the scorestext value into the file
            File.WriteAllText(filepath, scorestext);
        }

        /// <summary>
        /// Checks if the score can be stored in the top 10
        /// </summary>
        /// <param name="score"> Value of score </param>
        /// <returns> Returns if score can be stored or not </returns>
        private bool CanBeInserted(int score)
        {
            // Assigns "false" value to checker
            bool checker = false;

            // Checks if the number of scores in the file
            // is less than it's desired limit
            if (scores.Count < maxScoresInFiles)
            {
                // Assigns "true" value to checker
                checker = true;
            }

            // Checks if any of the scores is lower than the given score
            for (int i = 0; i < maxScoresInFiles && !checker; i++)
            {
                // Assigns value to checker
                checker = scores[i].Score < score;
            }
            // Returns checker
            return checker;
        }
    }
}