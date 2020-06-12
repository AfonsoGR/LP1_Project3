using System;

namespace BootlegRoguelike
{
    /// <summary>
    /// Stores the value of a string and an integer
    /// </summary>
    public struct Highscore : IComparable<Highscore>
    {
        /// <summary>
        ///  Gets the value of the user's Name
        /// </summary>
        /// <value> Value of the user's Name </value>
        public string Name {get;}

        /// <summary>
        /// Gets the value of the user's Score
        /// </summary>
        /// <value> Value of the user's Score </value>        
        public int Score {get;}

        /// <summary>
        /// Constructor to define a new name and score
        /// </summary>
        /// <param name="name"> Value of the user's Name </param>
        /// <param name="score"> Value of the user's Score </param>
        public Highscore (string name, int score)
        {
            // Value of name
            Name = name;
            // Value of score
            Score = score;
        }

        /// <summary>
        ///  Compares scores
        /// </summary>
        /// <param name="other"> Value of other scores </param>
        /// <returns></returns>
        public int CompareTo(Highscore other)
        {
            // Returns the value of the user's score
            return other.Score - Score;
        }

        /// <summary>
        /// Overrides ToString method and assigns value to highscore string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Returns overridden highscore string
            return Name + ScoresManager.tab + Score;
        }        
    }
}