int n = 4;
int counter = 0;
int x = 0;
int y = 0;
//int[,] board = new int[n, n];
// 0 = 未訂, 1 = 皇后, 2 = 空位置



//for (int j = 0; j < n; j++)
//{
//    for (int i = 0; i < n; i++)
//    {
//        if (board[i, j] == 0)
//        {
//            board[i, j] = 1;
//            board = RemovePlace(board, i, j);
//            counter++;
//            break;
//        }
//    }
//}

PutQueen(new int[n, n], y, counter);
//Output(board);



void PutQueen(int[,] board, int y, int counter)
{
    if (counter == n)
    {
        Output(board);
        return;
    }
    for (int i = 0; i < n; i++)
    {
        if (board[i, y] == 0)
        {
            for (int k = 1; k <= 2; k++)
            {
                if (k == 1)
                {
                    PutQueen(RemovePlace(board, i, y, k), y + 1, counter + 1);
                }
                else
                {
                    PutQueen(RemovePlace(board, i, y, k), y, counter);
                }
            }
        }
    }
    return;
}


int[,] RemovePlace(int[,] board, int x, int y, int decide)
{
    int[,] newBoard = board.Clone() as int[,] ?? new int[n, n];

    newBoard[x, y] = decide;
    if (decide == 1)
    {
        //去除水平及垂直同列
        for (int k = 0; k < n; k++)
        {
            newBoard[x, k] = newBoard[x, k] == 0 ? 2 : newBoard[x, k];
            newBoard[k, y] = newBoard[k, y] == 0 ? 2 : newBoard[k, y];
        }
        //去除對角線
        for (int j = y + 1; j < n; j++)
        {
            if (x + (j - y) < n)
                newBoard[x + (j - y), j] = newBoard[x + (j - y), j] == 0 ? 2 : newBoard[x + (j - y), j];

            if (x - (j - y) > -1)
                newBoard[x - (j - y), j] = newBoard[x - (j - y), j] == 0 ? 2 : newBoard[x - (j - y), j];
        }
    }
    //Output(newBoard);
    return newBoard;
}

void Output(int[,] board)
{
    Console.WriteLine("\n");
    Console.WriteLine("================================");

    for (int y = 0; y < board.GetLength(0); y++)
    {
        for (int x = 0; x < board.GetLength(0); x++)
        {
            if (board[x, y] == 1)
                Console.Write("Q ");
            else if (board[x, y] == 2)
                Console.Write("X ");
            else
                Console.Write("* ");
        }

        Console.WriteLine("");
    }

    Console.WriteLine("================================");
}
