using System;

namespace BootlegRoguelike
{
    /// <summary>
    /// Stores the value of a string and an integer
    /// </summary>
    public struct Highscore : IComparable<Highscore>
    {
<<<<<<< HEAD
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
=======
        public string Name { get; }
        public int Score { get; }

        public Highscore(string name, int score)
>>>>>>> ae5b02c522f469038112e586b8cc6b44bb1e5997
        {
            // Value of name
            Name = name;
            // Value of score
            Score = score;
        }

<<<<<<< HEAD
        /// <summary>
        ///  Compares scores
        /// </summary>
        /// <param name="other"> Value of other scores </param>
        /// <returns></returns>
=======
>>>>>>> ae5b02c522f469038112e586b8cc6b44bb1e5997
        public int CompareTo(Highscore other)
        {
            // Returns the value of the user's score
            return other.Score - Score;
        }
<<<<<<< HEAD

        /// <summary>
        /// Overrides ToString method and assigns value to highscore string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Returns overridden highscore string
            return Name + ScoresManager.tab + Score;
        }        
=======
>>>>>>> ae5b02c522f469038112e586b8cc6b44bb1e5997
    }
}