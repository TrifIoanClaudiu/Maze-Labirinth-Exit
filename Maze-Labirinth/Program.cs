using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Labirinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix m = new Matrix(6, 5);
            m.readMatrix();
            m.BFS(2,3);
        }
    }
}
