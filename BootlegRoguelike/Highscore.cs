using System;
namespace BootlegRoguelike
{
    public struct Highscore : IComparable<Highscore>
    {
        public string Name {get;}        
        public int Score {get;}

        public Highscore (string name, int score)
        {
            Name = name;
            Score = score;
        }

        public int CompareTo(Highscore other)
        {
            return other.Score - Score;
        }

        public override string ToString()
        {
            return Name + ScoresManager.tab + Score;
        }        
    }
}