using System;
namespace BootlegRoguelike
{
    public class Highscore : IComparable<Highscore>
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
            if(other == null) return-1;
            return other.Score - Score;
        }        
    }
}