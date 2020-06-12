using System;

namespace BootlegRoguelike
{
    /// <summary>
    /// Responsible for Rendering the board, UI and tooltips to the user
    /// </summary>
    public class Renderer
    {
        // Stores a reference to the current level layout
        private readonly RoomGenerator level;

        // Stores a reference to the player
        private readonly Player player;

        // The HP the player starts with (for the UI)
        private readonly float initialHP;

        // Array containing most of the visuals from the Piece
        private readonly Piece[] allVisuals;

        // The current level the user is currently at
        private readonly int lvl;

        /// <summary>
        /// Constructor of the class Renderer
        /// </summary>
        /// <param name="level"> The current room layout </param>
        /// <param name="player"> The player </param>
        public Renderer(RoomGenerator level, Player player, int lvl)
        {
            // Saves the level given to the one created
            this.lvl = lvl;
            // Saves the room layout given
            this.level = level;
            // Saves the player given
            this.player = player;

            // Calculates the initial HP of the player
            initialHP = ((level.SizeX - 3) * (level.SizeY - 2)) / 4;

            // Rests the color of the console
            Console.ResetColor();
            // Hides the cursor while drawing
            Console.CursorVisible = false;
            // Clears the console
            Console.Clear();

            // Creates an Array of all the Piece
            allVisuals = new Piece[]
            {
                Piece.Block,
                Piece.Boss,
                Piece.Enemy,
                Piece.Exit,
                Piece.Player,
                Piece.PowerMax,
                Piece.PowerMed,
                Piece.PowerMin
            };

            // Draws the level information once
            DrawLevelUI();
        }

        /// <summary>
        /// Called to draw the Room along with the enemies, player and powerups
        /// </summary>
        /// <param name="msg"> A message to be displayed </param>
        public void Render(string msg = null)
        {
            // Resets the cursor back to the top left of the screen
            Console.SetCursorPosition(0, 0);

            // Cycles through all the pieces of the board
            for (int c = 0; c < level.SizeY; c++)
            {
                for (int r = 0; r < level.SizeX; r++)
                {
                    // Creates a new position equal to the current X and Y
                    Position pos = new Position(r, c);

                    // Checks if on that position is a Block
                    if (level[pos] == Piece.Block)
                    {
                        // Sets the background color to white
                        Console.BackgroundColor = ConsoleColor.White;
                        // writes an empty space
                        Console.Write(' ');
                        // Resets back the colors to the default ones
                        Console.ResetColor();
                    }
                    else
                    {
                        // Displays the visual on that position of the room
                        Console.Write((char)level[pos]);
                    }
                }
                // Moves the cursor a line below
                Console.WriteLine();
            }
            // Moves the cursor a line below
            Console.WriteLine();
            // Draws the UI of the game
            DrawPlayerUI(msg);
        }

        /// <summary>
        /// Displays the information of the player along with the messages
        /// </summary>
        /// <param name="msg"> A message to be player </param>
        private void DrawPlayerUI(string msg)
        {
            // Checks if the message exists
            if (msg != null)
            {
                // Displays that message
                Console.WriteLine($"\n{msg}                               \n");
            }

            // Finds the percentage of HP the player has
            float percentageHP = player.HP / initialHP;
            // Multiplies that number by the initialHP to get the number of
            // squares in the HP bar
            int barHP = (int)(percentageHP * initialHP);

            // Displays the current HP of the player besides the bar
            Console.WriteLine(@"HP: |" + player.HP + "|");

            // Loops for the amount of squares it should draw
            for (int i = 0; i < initialHP; i++)
            {
                // Sets the bar color acording to the amount of hp left
                Console.BackgroundColor = i >= barHP ?
                    ConsoleColor.White : ConsoleColor.DarkRed;

                // Writes an empty space with a color
                Console.Write(' ');
            }
            // Resets the color to the default
            Console.ResetColor();
            // Goes down two lines
            Console.WriteLine("\n");

            // Displays to the user the keys used to move
            Console.WriteLine("WASD or arrow keys to move");
        }

        /// <summary>
        /// Draws the current level and a caption of what each piece is
        /// </summary>
        private void DrawLevelUI()
        {
            // Resets the cursor back to the top left of the screen
            Console.SetCursorPosition(0, 0);

            // Sets the cursor to a position after the board + 5
            DrawAfterBoardPosition();

            // Displays the current level
            Console.WriteLine($"Current level : {lvl} \n\n");

            // Displays all the visuals on the allVisuals array
            for (int i = 0; i < allVisuals.Length; i++)
            {
                // Sets the cursor to a position after the board + 5
                DrawAfterBoardPosition();

                // If it's the first on the array set's the background to white
                if (i == 0)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                // Draws the visual translated into a char
                Console.Write($"{(char)allVisuals[i]}");
                // Resets the color
                Console.ResetColor();
                // Displays the name of that visual
                Console.WriteLine($"= {allVisuals[i]}");
            }
        }

        /// <summary>
        /// Sets the cursor of the console to a position after the board plus
        /// an offset of 5
        /// </summary>
        private void DrawAfterBoardPosition()
        {
            // Sets the cursor after the size of the level + 5
            for (int i = 0; i < level.SizeX + 50; i++)
            {
                // Writes an empty space
                Console.Write(' ');
            }
        }
    }
}