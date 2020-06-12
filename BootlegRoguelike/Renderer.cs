using System;
using System.Collections.Generic;

namespace BootlegRoguelike
{
    public class Renderer
    {
        private readonly RoomGenerator level;
        private readonly Player player;

        private readonly float initialHP;

        private readonly Enums[] allVisuals;

        public Renderer(RoomGenerator level, Player player)
        {
            this.level = level;
            this.player = player;

            initialHP = ((level.SizeX - 3) * (level.SizeY - 2)) / 4;

            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Clear();

            allVisuals = new Enums[]
            {
                Enums.Block,
                Enums.Boss,
                Enums.Enemy,
                Enums.Exit,
                Enums.Player,
                Enums.PowerMax,
                Enums.PowerMed,
                Enums.PowerMin
            };
        }

        public void Render(string msg = null)
        {
            Console.SetCursorPosition(0, 0);

            for (int c = 0; c < level.SizeY; c++)
            {
                for (int r = 0; r < level.SizeX; r++)
                {
                    Position pos = new Position(r, c);

                    if (level[pos] == Enums.Block)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(' ');
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write((char)level[pos]);
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
                Console.WriteLine($"\n{msg}                               \n");
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
            Console.WriteLine("\n");

            for (int i = 0; i < allVisuals.Length; i++)
            {
                if (i == 0)
                    Console.BackgroundColor = ConsoleColor.White;
                Console.Write($"{(char)allVisuals[i]}");
                Console.ResetColor();
                Console.WriteLine($"= {allVisuals[i]}");
            }
        }
    }
}