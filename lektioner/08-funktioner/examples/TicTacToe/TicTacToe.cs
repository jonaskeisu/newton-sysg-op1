using static System.Console;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {
        static void Clear(char[,] board)
        {
            for (int row = 0; row < 3; ++row)
            {
                for (int col = 0; col < 3; ++col)
                {
                    board[row, col] = ' ';
                }
            }
        }

        static void Print(char[,] board)
        {
            WriteLine("=======");
            for (int row = 0; row < 3; ++row)
            {
                Write('|');
                for (int col = 0; col < 3; ++col)
                {
                    Write($"{board[row, col]}|");
                }
                WriteLine("\n" + "=======");
            }
        }

        static int ReadPosition(string prompt)
        {
            do
            {
                Write($"{prompt}: ");
                char key = ReadKey().KeyChar;
                Write('\n');
                if (key >= '1' && key <= '3')
                {
                    return key - '0' - 1;
                }
                WriteLine("Ogiltigt tecken.");
            }
            while (true);
        }

        static bool CheckLine(char marker, char[,] board, int startRow, int startCol, int deltaRow, int deltaCol)
        {
            return
                board[startRow, startCol] == marker &&
                board[startRow + deltaRow, startCol + deltaCol] == marker &&
                board[startRow + 2 * deltaRow, startCol + 2 * deltaCol] == marker;
        }

        static bool Occupied(char[,] board, int row, int col) => board[row, col] != ' ';

        static void PlaceMarker(char[,] board, char marker)
        {
            while (true)
            {
                int row = ReadPosition("Rad");
                int col = ReadPosition("Kolumn");

                WriteLine();

                if (Occupied(board, row, col))
                {
                    WriteLine("Upptagen position. Försök igen.");
                }
                else
                {
                    board[row, col] = marker;
                    break;
                }
            }
        }

        static bool CheckPlayerWon(char[,] board, char marker)
        {
            bool playerWon = false;
            for (int i = 0; i < 3; ++i)
            {
                playerWon |= CheckLine(marker, board,
                    startRow: i, startCol: 0, deltaRow: 0, deltaCol: 1);

                playerWon |= CheckLine(marker, board,
                    startRow: 0, startCol: i, deltaRow: 1, deltaCol: 0);
            }

            playerWon |= CheckLine(marker, board,
                    startRow: 0, startCol: 0, deltaRow: 1, deltaCol: 1);

            playerWon |= CheckLine(marker, board,
                    startRow: 0, startCol: 2, deltaRow: 1, deltaCol: -1);

            return playerWon;
        }

        static void Main(string[] args)
        {
            var board = new char[3, 3];

            // Clear the board
            Clear(board);

            bool gameEnded = false;
            char currentSymbol = 'O';
            int symbolCount = 0;

            // Game loop
            while (!gameEnded)
            {
                var playerName = currentSymbol == 'O' ? "Ring" : "Kryss";

                Print(board);

                WriteLine($"\n{playerName} spelar.\n");

                PlaceMarker(board, currentSymbol);
                ++symbolCount;

                bool playerWon = CheckPlayerWon(board, currentSymbol);

                if (playerWon)
                {
                    WriteLine($"{playerName} har vunnit!");
                    break;
                }
                else if (symbolCount == 9)
                {
                    WriteLine("Oavgjort.");
                    break;
                }

                // Switch player
                if (currentSymbol == 'O')
                {
                    currentSymbol = 'X';
                }
                else
                {
                    currentSymbol = 'O';
                }
            }

            Print(board);
        }
    }
}
