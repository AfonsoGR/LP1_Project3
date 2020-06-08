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
            for (int x = 0; x < level.SizeX; x++)
            {
                for (int y = 0; y < level.SizeY; y++)
                {
                    Console.Write(level[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}
