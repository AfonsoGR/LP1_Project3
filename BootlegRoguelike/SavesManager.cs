using System;
using System.IO;
using System.Collections.Generic;

namespace BootlegRoguelike
{
    public class SavesManager
    {
        private void SaveGame()
        {}

        private void LoadGame()
        {}

        private void RegisterHighscore()
        {
            const string fileScores = "highscores.txt";
            Queue <string> queueScores = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "")
                {
                    break;
                }
                queueScores.Enqueue(input);
            }

            File.WriteAllLines(fileScores, queueScores);
        }
    }
}