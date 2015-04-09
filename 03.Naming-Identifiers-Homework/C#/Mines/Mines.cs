using System;
using System.Collections.Generic;

namespace Mines
{
    public class Minesweeper
    {
        public class RatingStats
        {
            private string name;
            private int points;
            public string Player
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }

            public int Score
            {
                get
                {
                    return points;
                }

                set
                {
                    points = value;
                }
            }

            public RatingStats()
            {
            }

            public RatingStats(string name, int points)
            {
                this.name = name;
                this.points = points;
            }
        }

        private static void Main()
        {
            string command = string.Empty;
            char[,] field = CreatePlayingFild();
            char[,] bombs = PuttingBombs();
            int counter = 0;
            bool explode = false;
            List<RatingStats> champoins = new List<RatingStats>(6);
            int row = 0;
            int column = 0;
            bool flag = true;
            const int maximum = 35;
            bool flagTwo = false;

            do
            {
                if (flag)
                {
                    Console.WriteLine("Lets play Minesweeper, try your luck" + " Comand 'top' shows the score, 'restart' begins new game, 'exit' exits!");
                    Dumpp(field);
                    flag = false;
                }

                Console.Write("Gving row and colon");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column)
                        && row <= field.GetLength(0) && column <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Raiting(champoins);
                        break;
                    case "restart":
                        field = CreatePlayingFild();
                        bombs = PuttingBombs();
                        Dumpp(field);
                        explode = false;
                        flag = false;
                        break;
                    case "exit":
                        Console.WriteLine("bye, bye, bye");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                SilenceTurn(field, bombs, row, column);
                                counter++;
                            }

                            if (maximum == counter)
                            {
                                flagTwo = true;
                            }
                            else
                            {
                                Dumpp(field);
                            }
                        }
                        else
                        {
                            explode = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nMistake invalid comand\n");
                        break;
                }

                if (explode)
                {
                    Dumpp(bombs);
                    Console.Write("\nDies with hero with {0} score. " + "Give your nickname: ", counter);
                    string nickName = Console.ReadLine();
                    RatingStats charackter = new RatingStats(nickName, counter);
                    if (champoins.Count < 5)
                    {
                        champoins.Add(charackter);
                    }
                    else
                    {
                        for (int i = 0; i < champoins.Count; i++)
                        {
                            if (champoins[i].Score < charackter.Score)
                            {
                                champoins.Insert(i, charackter);
                                champoins.RemoveAt(champoins.Count - 1);
                                break;
                            }
                        }
                    }

                    champoins.Sort((RatingStats firstRaiting, RatingStats secondRaiting) => secondRaiting.Player.CompareTo(firstRaiting.Player));
                    champoins.Sort((RatingStats firstRaiting, RatingStats secondRaiting) => secondRaiting.Score.CompareTo(firstRaiting.Score));
                    Raiting(champoins);

                    field = CreatePlayingFild();
                    bombs = PuttingBombs();
                    counter = 0;
                    explode = false;
                    flag = true;
                }

                if (flagTwo)
                {
                    Console.WriteLine("Good 35 points without hitting a mine");
                    Dumpp(bombs);
                    Console.WriteLine("What is your name ");
                    string name = Console.ReadLine();
                    RatingStats points = new RatingStats(name, counter);
                    champoins.Add(points);
                    Raiting(champoins);
                    field = CreatePlayingFild();
                    bombs = PuttingBombs();
                    counter = 0;
                    flagTwo = false;
                    flag = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria");
            Console.WriteLine("Come onnnnnnnn");
            Console.Read();
        }

        private static void Raiting(List<RatingStats> score)
        {
            Console.WriteLine("\nPoints:");
            if (score.Count > 0)
            {
                for (int i = 0; i < score.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, score[i].Player, score[i].Score);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No socre!!!\n");
            }
        }

        private static void SilenceTurn(char[,] filed, char[,] bombs, int row, int column)
        {
            char countBombs = Score(bombs, row, column);
            bombs[row, column] = countBombs;
            filed[row, column] = countBombs;
        }

        private static void Dumpp(char[,] board)
        {
            int firstBoard = board.GetLength(0);
            int secondBoard = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < firstBoard; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < secondBoard; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayingFild()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PuttingBombs()
        {
            int rows = 5;
            int coloumn = 10;
            char[,] playingField = new char[rows, coloumn];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < coloumn; j++)
                {
                    playingField[i, j] = '-';
                }
            }

            List<int> thirdRow = new List<int>();
            while (thirdRow.Count < 15)
            {
                Random random = new Random();
                int mine = random.Next(50);
                if (!thirdRow.Contains(mine))
                {
                    thirdRow.Add(mine);
                }
            }

            foreach (int mine in thirdRow)
            {
                int mineColoumn = mine / coloumn;
                int mineRow = mine % coloumn;
                if (mineRow == 0 && mine != 0)
                {
                    mineColoumn--;
                    mineRow = coloumn;
                }
                else
                {
                    mineRow++;
                }

                playingField[mineColoumn, mineRow - 1] = '*';
            }

            return playingField;
        }

        private static void Accounts(char[,] field)
        {
            int coloumn = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < coloumn; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char score = Score(field, i, j);
                        field[i, j] = score;
                    }
                }
            }
        }

        private static char Score(char[,] firstRow, int secondRow, int thirdRow)
        {
            int theScore = 0;
            int rows = firstRow.GetLength(0);
            int coloumns = firstRow.GetLength(1);

            if (secondRow - 1 >= 0)
            {
                if (firstRow[secondRow - 1, thirdRow] == '*')
                {
                    theScore++;
                }
            }

            if (secondRow + 1 < rows)
            {
                if (firstRow[secondRow + 1, thirdRow] == '*')
                {
                    theScore++;
                }
            }

            if (thirdRow - 1 >= 0)
            {
                if (firstRow[secondRow, thirdRow - 1] == '*')
                {
                    theScore++;
                }
            }

            if (thirdRow + 1 < coloumns)
            {
                if (firstRow[secondRow, thirdRow + 1] == '*')
                {
                    theScore++;
                }
            }

            if ((secondRow - 1 >= 0) && (thirdRow - 1 >= 0))
            {
                if (firstRow[secondRow - 1, thirdRow - 1] == '*')
                {
                    theScore++;
                }
            }

            if ((secondRow - 1 >= 0) && (thirdRow + 1 < coloumns))
            {
                if (firstRow[secondRow - 1, thirdRow + 1] == '*')
                {
                    theScore++;
                }
            }

            if ((secondRow + 1 < rows) && (thirdRow - 1 >= 0))
            {
                if (firstRow[secondRow + 1, thirdRow - 1] == '*')
                {
                    theScore++;
                }
            }

            if ((secondRow + 1 < rows) && (thirdRow + 1 < coloumns))
            {
                if (firstRow[secondRow + 1, thirdRow + 1] == '*')
                {
                    theScore++;
                }
            }

            return char.Parse(theScore.ToString());
        }
    }
}