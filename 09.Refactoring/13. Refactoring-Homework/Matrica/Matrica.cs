using System;

namespace ThirdTask
{
    public class WalkInMatrica
    {
        public static void Change(ref int dx, ref int dy)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int cd = 0;

            for (int count = 0; count < 8; count++)
            {
                if (dirX[count] == dx && dirY[count] == dy)
                {
                    cd = count;
                    break;
                }
            }

            if (cd == 7)
            {
                dx = dirX[0];
                dy = dirY[0];
                return;
            }

            dx = dirX[cd + 1];
            dy = dirY[cd + 1];
        }

        public static bool Verification(int[,] matrix, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int index = 0; index < 8; index++)
            {
                if (x + dirX[index] >= matrix.GetLength(0) || x + dirX[index] < 0)
                {
                    dirX[index] = 0;
                }

                if (y + dirY[index] >= matrix.GetLength(0) || y + dirY[index] < 0)
                {
                    dirY[index] = 0;
                }
            }

            for (int index = 0; index < 8; index++)
            {
                if (matrix[x + dirX[index], y + dirY[index]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static void FindCell(int[,] matrix, out int x, out int y)
        {
            x = 0;
            y = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        x = row;
                        y = col;
                    }
                }
            }
        }

        static void Main()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();

            int number = 0;
            while (!int.TryParse(input, out number) || number < 0 || number > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            int step = 3;
            int[,] matrica = new int[step, step];
            int k = 1;
            int row = 0;
            int col = 0;
            int dx = 1;
            int dy = 1;

            while (true)
            { 
                matrica[row, col] = k;

                if (!Verification(matrica, row, col))
                {
                    {
                        break;
                    }
                }

                if (row + dx >= step || row + dx < 0 || col + dy >= step || col + dy < 0 
                    || matrica[row + dx, col + dy] != 0)
                {
                    while ((row + dx >= step || row + dx < 0 || col + dy >= step || col + dy < 0 ||
                            matrica[row + dx, col + dy] != 0))
                    {
                        Change(ref dx, ref dy);
                    }

                    row += dx;
                    col += dy;
                    k++;
                }
            }

            for (int rowPosition = 0; rowPosition < step; rowPosition++)
            {
                for (int colPosition = 0; colPosition < step; colPosition++)
                {
                    Console.Write("{0,3}", matrica[rowPosition, colPosition]);
                }

                Console.WriteLine();
            }

            FindCell(matrica, out row, out col);

            if (row != 0 && col != 0)
            { 
                dx = 1;
                dy = 1;

                while (true)
                {
                    matrica[row, col] = k;

                    if (!Verification(matrica, row, col))
                    {
                        break;
                    }

                    if (row + dx >= step || row + dx < 0 || col + dy >= step || col + dy < 0
                        || matrica[row + dx, col + dy] != 0)
                    {
                        while ((row + dx >= step || row + dx < 0 || col + dy >= step || col + dy < 0
                                || matrica[row + dx, col + dy] != 0))
                        {
                            Change(ref dx, ref dy);
                        }

                        row += dx;
                        col += dy;
                        k++;
                    }
                }
            }

            for (int rowPosition = 0; rowPosition < step; rowPosition++)
            {
                for (int colPosition = 0; colPosition < step; colPosition++)
                {
                    Console.Write("{0,3}", matrica[rowPosition, colPosition]);
                }

                Console.WriteLine();
            }
        }
    }
}
