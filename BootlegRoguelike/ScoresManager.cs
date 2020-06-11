using System;
using System.IO;
using System.Collections.Generic;

namespace BootlegRoguelike
{
    public class ScoresManager
    {
        const string scoresFile = "highscores.txt";
        const char tab = '\t';
        StreamWriter writer = new StreamWriter(scoresFile);
        StreamReader reader;
        List<Highscore> scores = new List<Highscore>();
        string displayScores;
        string nameRegister;
        float finalScore = 100f;

        public void CompareScores()
        {

        }

        public void RegisterScores()
        {
            Console.WriteLine("Register your name for the leaderboards:\t");
            nameRegister = Console.ReadLine();

            // Adds highscores
            scores.Add(new Highscore(nameRegister, finalScore));

            // Orders highscores
            //! Check class recording (11 or 12)

            // Saves highscores into a file
            foreach (Highscore highscore in scores)
            {
                writer.WriteLine(highscore.PlayerName
                    + tab + highscore.PlayerScore);
            }

            // Closes file
            writer.Close();
        }

        public void DisplayTopScores()
        {
            // Opens file for reading
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
    }
}