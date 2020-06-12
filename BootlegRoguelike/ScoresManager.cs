using System;
using System.IO;
using System.Collections.Generic;

namespace BootlegRoguelike
{
    /// <summary>
    /// Manages registering, comparing, ordering and displaying scores
    /// </summary>
    public class ScoresManager
    {
        // public int Rows {get; set;}
        // public int Cols {get; set;}
        // const string scoresFile = $"highscoresR{Rows}C{Cols}.txt";
        const string scoresFile = "highscores.txt";
        string displayScores;
        string nameRegister;

        const char tab = '\t';
        int finalScore = 100;
        StreamReader reader;
        StreamWriter writer;
        List<Highscore> scores;

        public ScoresManager()
        {
            // writer = new StreamWriter(scoresFile);
            scores = new List<Highscore>();
            //reader = new StreamReader(scoresFile);
        }

        /// <summary>
        /// Registers user's scores
        /// </summary>
        public void RegisterScores(int score)
        {
            writer = new StreamWriter(scoresFile);
            // Displays on-screen text
            Console.WriteLine("Register your name for the leaderboards:\t");
            // Stores user input
            nameRegister = Console.ReadLine();
            finalScore = score;
            //finalScore = Int32.Parse(Console.ReadLine());

            // Adds highscores
            scores.Add(new Highscore(nameRegister, finalScore));
            scores.Sort();
            //Close();
            
            
        }

        /// <summary>
        /// Displays user's top 10 scores in respective file
        /// </summary>
        /// <param name="scoresCollection"></param>
        public void DisplayTopScores()
        {
            reader = new StreamReader(scoresFile);
            // Reads each lines and displays each one on the screen
            while ((displayScores = reader.ReadLine()) != null)
            {
                string[] nameAndScore = displayScores.Split(tab);
                string name = nameAndScore[0];
                float score = Convert.ToSingle(nameAndScore[1]);
                Console.WriteLine($"Score of '{name}' is {finalScore}");
            }

            // Closes the file
            reader.Close();
        }
        public void Close()
        {
            foreach (Highscore highscore in scores)
            {
                // Adds a new line with name and score
                writer.WriteLine(highscore.Name + " " + highscore.Score);
            }
            writer.Close();
        }
    }
}