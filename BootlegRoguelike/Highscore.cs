namespace BootlegRoguelike
{
    public struct Highscore
    {
        public string PlayerName {get;}        
        public float PlayerScore {get;}

        public Highscore (string playerName, float playerScore)
        {
            PlayerName = playerName;
            PlayerScore = playerScore;
        }        
    }
}