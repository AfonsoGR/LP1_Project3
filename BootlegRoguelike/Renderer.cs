using System;
using System.Collections.Generic;
using System.Text;

namespace BootlegRoguelike
{
    public class Renderer
    {
        private readonly RoomGenerator level;
        public Renderer(RoomGenerator level)
        {
            this.level = level;
        }

        public void Render()
        {
            Console.SetCursorPosition(0, 0);
            for (int c = 0; c < level.SizeY; c++)
            {
                for (int r = 0; r < level.SizeX; r++)
                {
                    Console.Write(level[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}
