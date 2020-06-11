namespace BootlegRoguelike
{
    public struct Highscore
    {
        public string Name {get;}        
        public float Score {get;}

        public Highscore (string name, float score)
        {
            Name = name;
            Score = score;
        }        
    }
}