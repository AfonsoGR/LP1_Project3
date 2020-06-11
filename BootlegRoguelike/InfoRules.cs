using System;

namespace BootlegRoguelike
{
    public static class InfoRules
    {
        public static void WelcomeText()
        {
            Console.Clear();
            Console.WriteLine("Hello and Welcome to...\n\tBOOTLEG ROGUELIKE" +
                "\n\nPlease select one of the following options:\n" +
                "\t1 - New Game\n\t2 - High scores\n\t3 - Instructions\n\t" + 
                "4 - Credits\n\t5 - Quit\n\n Select an option using the " + 
                "numbers...");
        }

        public static void Intro()
        {
            Console.Clear();
            Console.WriteLine("Welcome to our game, Bootleg Roguelike!\n" 
            + "In this game you have to reach the exit in the level. Each "
            + "level is randomly generated and has multiple enemies, obstacles" 
            + " and powerups.\nThe player can move Up (W), Down (S), left (A) " 
            + "or Right (D) and loses when their HP reaches 0.\n\n\t" 
            + "The player loses 1 HP everytime they move.\n\t" 
            + "The player loses 5 HP or 10 HP when an enemy (depends on enemy"
            + " type) is above, below, to the right or to the left of the " 
            + "player's current position.\n\nThere are 3 different powerups:"
            + "\n\tSmall -> Heals 4 HP.\n\tMedium -> Heals 8 HP.\n\tBig -> "
            + "16 HP.\n\nThe game will get harder the longer it goes, there "
            + "will be less powerups and more enemies, but the longer you go "
            + "the bigger your score will be!\nKeep in mind that your total "
            + "HP, the number of enemies, obstacles and powerups will be " 
            + "influenced by the size of the board.\n");
        }

        public static void Credits()
        {
            Console.Clear();
            Console.WriteLine("This game was made by the following students:"
                + "\n\tAfonso Rosa      - a21802169"
                + "\n\tAndré Vitorino   - a21902663"
                + "\n\tJoão Fonseca     - a21905441");
        }        
    }
}