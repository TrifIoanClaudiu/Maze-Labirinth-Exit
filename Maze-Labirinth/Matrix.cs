using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Labirinth
{
    internal class Matrix
    {
        class pair
        {
            public int first, second;

            public pair(int first, int second)
            {
                this.first = first;
                this.second = second;
            }
        }

        private int[,] matrix;
        private int rows;
        private int cols;
        private bool[,] vis;
        public Matrix(int rowsNumber, int columns)
        {
            rows = rowsNumber;
            cols = columns;
            matrix = new int[rowsNumber, columns];
            vis = new bool[rowsNumber, columns];
        }

        static int[] dRow = { -1, 0, 1, 0 };
        static int[] dCol = { 0, 1, 0, -1 };
        private bool validReading(int n)
        {
            if (!((n == 0) || (n == 1)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void readMatrix()
        {
            Console.WriteLine("Write your labirinth, put 0 if a cell is locked," +
                " 1 if it's free!");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int n = Convert.ToInt32(Console.ReadLine());
                    if (!validReading(n))
                    {
                        Console.WriteLine("You entered a wrong number!!");
                        break;
                    }
                    else
                    {
                        matrix[i, j] = n;
                    }
                }
            }
        }


        private bool Finish(int m, int n)
        {
            if ((m == 0) || (n == 0) || (m==rows-1) || (n== cols-1))
            {
                if (matrix[m, n] == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void BFS(int m, int n)
        {
            matrix[m, n] = 1;
            Queue<pair> q = new Queue<pair>();
            q.Enqueue(new pair(m, n));
            vis[m, n] = true;

            bool isValid(int row, int col)
            { 

                if (row < 0 || col < 0 || row >= rows || col >= cols)
                {
                    return false;
                }
                if(matrix[row,col] == 0)
                {
                    return false;
                }
                if (vis[row, col])
                    return false;

                return true;
            }
            while (q.Count != 0)
            {
                pair cell = q.Peek();
                int x = cell.first;
                int y = cell.second;
                Console.Write(x + " " + y + " - ");
                q.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int adjx = x + dRow[i];
                    int adjy = y + dCol[i];

                    if(isValid(adjx, adjy))
                    {
                        q.Enqueue(new pair(adjx, adjy));
                        vis[adjx,adjy] = true;

                        if (Finish(adjx, adjy))
                        {
                            Console.Write(adjx + " " + adjy + " "); 
                            Console.WriteLine("The man escaped the maze");
                            return;
                        }
                        break;
                    }
                }
            }
            Console.WriteLine("The man was lost!");
        }

        public void showMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
