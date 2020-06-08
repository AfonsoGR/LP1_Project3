using System;

namespace BootlegRoguelike
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            _ = new GameLoopController(20, 10);
        }
    }
}
