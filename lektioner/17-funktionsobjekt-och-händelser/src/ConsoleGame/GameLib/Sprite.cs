using System;

namespace GameLib
{
    public class Sprite
    {
        private bool[,] pixels;

        public int Width => pixels.GetLength(1);
        public int Height => pixels.GetLength(0);

        public Sprite(params string[] rows)
        {
            pixels = new bool[rows.Length, rows[0].Length];
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    pixels[i, j] = rows[i][j] == 'X';
                }
            }
        }

        internal void Draw(Position position)
        {
            var neutralColor = Console.BackgroundColor;
            for (int r = 0; r < Height; ++r)
            {
                Console.SetCursorPosition(position.Column, position.Row + r);
                for (int c = 0; c < Width; ++c)
                {
                    Console.BackgroundColor = pixels[r, c] ? ConsoleColor.White : neutralColor; 
                    Console.Write(" ");
                }
            }
            Console.BackgroundColor = neutralColor;
        }
    }
}