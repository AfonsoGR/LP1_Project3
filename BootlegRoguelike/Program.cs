using System;

namespace BootlegRoguelike
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows;
            int cols;

            if (args[0] == "-r" && args[2] == "-c")
            {
                rows = Int32.Parse(args[1]);
                cols = Int32.Parse(args[3]);

                _ = new GameLoopController(rows, cols);
            }
            else
            {
                Console.WriteLine("Use the following message:\n\n\t"
                    + "dotnet run -- -r ROWS -c COLUMNS\n\n\t"
                    + "Replace ROWS and COLUMNS with numeric values.");
            }

            //_ = new GameLoopController(10, 20);         
        }
    }
}
