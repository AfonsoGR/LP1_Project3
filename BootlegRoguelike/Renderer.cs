using System;
using System.Collections.Generic;
using System.Text;

namespace BootlegRoguelike
{
    public class Renderer
    {
        private readonly RoomGenerator level;
        private readonly Player player;
        private readonly List<Enemies> enemies;

        private readonly float initialHP;

        public Renderer(RoomGenerator level, Player player, List<Enemies> enemies)
        {
            this.level = level;
            this.enemies = enemies;
            this.player = player;

            initialHP = ((level.SizeX - 1) * level.SizeY) / 4;

            Console.ResetColor();
            Console.CursorVisible = false;
        }

        public void Render(string msg = null)
        {
            Console.SetCursorPosition(0, 0);

            for (int c = 0; c < level.SizeY; c++)
            {
                for (int r = 0; r < level.SizeX; r++)
                {
                    if (player.Position.Row == r && player.Position.Col == c)
                    {
                        Console.Write('@');
                    }
                    else if (level[r, c] == 'w')
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(' ');
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(level[r, c]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            DrawUI(msg);
        }

        private void DrawUI(string msg)
        {
            if (msg != null)
            {
                Console.WriteLine($"\n{msg}\n");
            }

            float percentageHP = player.HP / initialHP;
            int barHP = (int)(percentageHP * initialHP);

            string hpNumber = @"HP: |" + player.HP + "|";

            for (int i = 0; i < initialHP; i++)
            {
                Console.BackgroundColor = i >= barHP ?
                    ConsoleColor.White : ConsoleColor.DarkRed;

                Console.ForegroundColor = ConsoleColor.Black;

                Console.Write(i >= hpNumber.Length ? ' ' : hpNumber[i]);
            }
            Console.ResetColor();
        }
    }
}
