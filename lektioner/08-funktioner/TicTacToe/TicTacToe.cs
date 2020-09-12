using System;
using static System.Console;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new char[3, 3];

            // Clear the board
            for (int row = 0; row < 3; ++row)
            {
                for (int col = 0; col < 3; ++col)
                {
                    board[row, col] = ' ';
                }
            }

            bool gameEnded = false;
            char currentSymbol = 'O';
            int symbolCount = 0; 

            // Game loop
            while (!gameEnded)
            {
                var playerName = currentSymbol == 'O' ? "Ring" : "Kryss";

                // Print board
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
                
                WriteLine($"\n{playerName} spelar.\n");

                while (true) 
                {
                    int row, col; 
                    do
                    {
                        Write("Rad: ");
                        char key = ReadKey().KeyChar;
                        Write('\n');
                        if (key >= '1' && key <= '3') 
                        {
                            row = key - '0' - 1;
                            break;
                        }
                        WriteLine("Ogiltigt tecken.");
                    } 
                    while(true);

                    do
                    {
                        Write("Kolumn: ");
                        char key = ReadKey().KeyChar;
                        Write('\n');
                        if (key >= '1' && key <= '3') 
                        {
                            col = key - '0' - 1;
                            break;
                        }
                        WriteLine("Ogiltigt tecken.");
                    } 
                    while(true);
                    
                    WriteLine();

                    if (board[row, col] != ' ') 
                    {
                        WriteLine("Upptagen position. Försök igen.");
                    }
                    else
                    {
                        board[row, col] = currentSymbol;
                        ++symbolCount; 
                        break;
                    }
                }

                bool playerWon = false;

                bool fullLine;

                // Check rows for win
                for (int col = 0; col < 3; ++col)
                {
                    fullLine = true;
                    for (int row = 0; row < 3; ++row)
                    {
                        fullLine &= board[row, col] == currentSymbol;
                    }
                    playerWon |= fullLine;
                }

                // Check columns for win
                for (int row = 0; row < 3; ++row)
                {
                    fullLine = true;
                    for (int col = 0; col < 3; ++col)
                    {
                        fullLine &= board[row, col] == currentSymbol;
                    }
                    playerWon |= fullLine;
                }

                // Check first diagonal for win
                fullLine = true;
                for (int pos = 0; pos < 3; ++pos)
                {
                    fullLine &= board[pos, pos] == currentSymbol;
                }
                playerWon |= fullLine; 

                // Check first diagonal for win
                fullLine = true;
                for (int pos = 0; pos < 3; ++pos)
                {
                    fullLine &= board[pos, 2 - pos] == currentSymbol;
                }
                playerWon |= fullLine;

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
        }
    }
}
