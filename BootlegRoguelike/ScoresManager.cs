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
        
        const string path = @"C:\Users\joao\Desktop\Faculdade\LP1\LP1_PROJECT3\highscores.txt";
        const char tab = '\t';
        private int finalScore;
        StreamReader reader;
        StreamWriter writer;
        List<Highscore> scores;

        public ScoresManager()
        {
            scores = new List<Highscore>();
            if(File.Exists(path))
            {
                DisplayTopScores();
            }
            //writer = new StreamWriter(scoresFile);
            
        }

        /// <summary>
        /// Registers user's scores
        /// </summary>
        public void RegisterScores(int score)
        {
            
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
            string [] array = File.ReadAllLines(path);

            foreach ( string line in array)
            {
                string[] values = line.Split(' ');
                nameRegister = values[0];
                finalScore = Int32.Parse(values[1]);
                scores .Add (new Highscore(nameRegister,finalScore));
            }
            // Reads each lines and displays each one on the screen
            // while ((displayScores = reader.ReadLine()) != null)
            // {
            //     string[] nameAndScore = displayScores.Split(tab);
            //     string name = nameAndScore[0];
            //     int score = Int32.Parse(nameAndScore[1]);
            //     scores.Add(new Highscore (name,score));
            // }

            // Closes the file
            //reader.Close();
        }

        public void PrintHighcore()
        {
            foreach(Highscore highscore in scores)
                Console.WriteLine(highscore.Name + " " + highscore.Score);;
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