using System;

namespace BootlegRoguelike
{
    public class InfoRules
    {
        public void Intro()
        {
            Console.WriteLine("Welcome to our game, Bootleg Roguelike!\n" 
            + "In this game you have to reach the exit in the level. Each "
            + "level is randomly generated and has multiple enemies and" 
            + "obstacles.\n The player can move Up (W), Down (S), left (A)" 
            + "or Right (D) and loses when their HP reaches 0.\n\n\t" 
            + "The player loses 1 HP everytime they move.\n\t" 
            + "The player loses 5 HP or 10 HP (depends on enemy type) when an"
            + " enemy is above, below, to the right or to the left of the" 
            + "player's current position.");
        }

        public void Credits()
        {
            Console.WriteLine("This game was made by the following students:"
                + "1n\tAfonso Rosa      - a21802169"
                + "\n\tAndré Vitorino   - a21902663"
                + "\n\tJoão Fonseca     - a21905441");
        }        
    }
}