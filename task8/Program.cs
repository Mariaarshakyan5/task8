using System;

class KnightMoves
{
    static void Main()
    {
        int[,] chessboard = new int[8, 8];
        int[,] knightTemplate = GenerateKnightTemplate();

        MoveKnight(chessboard, knightTemplate);

        // Display the chessboard with knight moves
        DisplayChessboard(chessboard);

        Console.ReadLine();
    }

    static void MoveKnight(int[,] chessboard, int[,] knightTemplate)
    {
        int currentRow = 0;
        int currentCol = 0;

        chessboard[currentRow, currentCol] = 1; // Start position

        for (int moveNumber = 2; moveNumber <= 64; moveNumber++)
        {
            int minMoves = int.MaxValue;
            int nextRow = -1;
            int nextCol = -1;

            // Check all possible moves
            for (int i = 0; i < 8; i++)
            {
                int newRow = currentRow + KnightMovesRow[i];
                int newCol = currentCol + KnightMovesCol[i];

                if (IsValidMove(chessboard, newRow, newCol) && chessboard[newRow, newCol] == 0)
                {
                    int moves = CountAvailableMoves(chessboard, knightTemplate, newRow, newCol);
                    if (moves < minMoves)
                    {
                        minMoves = moves;
                        nextRow = newRow;
                        nextCol = newCol;
                    }
                }
            }

            // Move to the field with the minimum number of available moves
            if (nextRow != -1 && nextCol != -1)
            {
                chessboard[nextRow, nextCol] = moveNumber;
                currentRow = nextRow;
                currentCol = nextCol;
            }
        }
    }

    static int CountAvailableMoves(int[,] chessboard, int[,] knightTemplate, int row, int col)
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            int newRow = row + KnightMovesRow[i];
            int newCol = col + KnightMovesCol[i];

            if (IsValidMove(chessboard, newRow, newCol) && chessboard[newRow, newCol] == 0)
            {
                count += knightTemplate[newRow, newCol];
            }
        }

        return count;
    }

    static bool IsValidMove(int[,] chessboard, int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }

    static void DisplayChessboard(int[,] chessboard)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write("[{0,2}] ", chessboard[i, j]);
            }
            Console.WriteLine();
        }
    }

    static int[,] GenerateKnightTemplate()
    {
        int[,] template = new int[8, 8];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                int moves = 0;

                for (int k = 0; k < 8; k++)
                {
                    int newRow = i + KnightMovesRow[k];
                    int newCol = j + KnightMovesCol[k];

                    if (IsValidMove(template, newRow, newCol))
                    {
                        moves++;
                    }
                }

                template[i, j] = moves;
            }
        }

        return template;
    }

    static int[] KnightMovesRow = { 2, 1, -1, -2, -2, -1, 1, 2 };
    static int[] KnightMovesCol = { 1, 2, 2, 1, -1, -2, -2, -1 };
}

