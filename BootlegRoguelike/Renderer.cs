using System;
using System.Collections.Generic;
using System.Text;

namespace BootlegRoguelike
{
    public class Renderer
    {
        private readonly RoomGenerator level;
        private readonly Player p;
        private readonly List<Enemies> enemies;
        public Renderer(RoomGenerator level, Player player, List<Enemies> enemies)
        {
            this.level = level;
            p = player;
            this.enemies = enemies;

        }

        public void Render()
        {
            Console.SetCursorPosition(0, 0);

            for (int c = 0; c < level.SizeY; c++)
            {
                for (int r = 0; r < level.SizeX; r++)
                {
                    if (p.Position.Row == r && p.Position.Col == c)
                    {
                        Console.Write('@');
                    }
                    else
                    {
                        Console.Write(level[r, c]);
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
