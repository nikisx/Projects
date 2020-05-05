using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int countOFCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int playerRow = 0;
            int playerCol = 0;

            bool Won = false;

            //filling
            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (currentRow[col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < countOFCommands; i++)
            {

                string commands = Console.ReadLine();

                if (commands == "up")
                {
                    if (isValid(playerRow - 1, playerCol, n))
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow--;

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerRow--;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerRow++;
                        }
                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = 'f';
                            Won = true;
                            break;
                        }
                        matrix[playerRow, playerCol] = 'f';
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow = n - 1;
                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = 'f';
                            Won = true;
                            break;
                        }
                        matrix[playerRow, playerCol] = 'f';

                    }
                }
                else if (commands == "down")
                {
                    if (isValid(playerRow + 1, playerCol, n))
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow++;

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerRow++;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerRow--;
                        }
                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = 'f';
                            Won = true;
                            break;
                        }
                        matrix[playerRow, playerCol] = 'f';
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow = 0;
                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = 'f';
                            Won = true;
                            break;
                        }
                        matrix[playerRow, playerCol] = 'f';
                    }
                }
                else if (commands == "right")
                {
                    if (isValid(playerRow, playerCol + 1, n))
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerCol++;

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerCol++;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerCol--;
                        }
                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = 'f';
                            Won = true;
                            break;
                        }
                        matrix[playerRow, playerCol] = 'f';
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerCol = 0;
                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = 'f';
                            Won = true;
                            break;
                        }
                        matrix[playerRow, playerCol] = 'f';
                    }
                }
                else if (commands == "left")
                {
                    if (isValid(playerRow, playerCol - 1, n))
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerCol--;

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            if (isValid(playerRow, playerCol - 1, n))
                            {
                                playerCol--;
                            }
                            else
                            {
                                playerCol = n - 1;
                            }
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerCol++;
                        }
                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = 'f';
                            Won = true;
                            break;
                        }
                        matrix[playerRow, playerCol] = 'f';
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerCol = n - 1;
                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            matrix[playerRow, playerCol] = 'f';
                            Won = true;
                            break;
                        }
                        matrix[playerRow, playerCol] = 'f';
                    }
                }
            }

            if (Won == false)
            {
                Console.WriteLine("Player lost!");
            }
            else
            {
                Console.WriteLine("Player won!");
            }
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

        }

        static bool isValid(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n ? true : false;
        }
    }
}
