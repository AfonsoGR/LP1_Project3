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
        string displayString;
        string nameRegister;

        public void CompareScores()
        {

        }

        public void RegisterScores()
        {
            Console.WriteLine("Register your name for the leaderboards:\t");
            nameRegister = Console.ReadLine();

            // Adds highscores
            //!scores.Add(new Highscore(nameRegister, THEPLAYERSCORE));

            // Orders highscores
            //! Check class

            // Saves highscores into a file
            foreach (Highscore highscore in scores)
            {
                writer.WriteLine(highscore.PlayerName 
                    + tab + highscore.PlayerScore);
            }

            // Closes file
            writer.Close();            
        }

        public void DisplayScores()
        {
            // Opens file for reading
            reader = new StreamReader(scoresFile);

            // Reads each lines and displays each one on the screen
            while ((displayString = reader.ReadLine()) != null)
            {
                string[] nameAndScore = displayString.Split(tab);
                string name = nameAndScore[0];
                float score = Convert.ToSingle(nameAndScore[1]);
                Console.WriteLine($"Score of '{name}' is {score}");
            }
            
            // Closes the file
            reader.Close();            
        }
    }
}