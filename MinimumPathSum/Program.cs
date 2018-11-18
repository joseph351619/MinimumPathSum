using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumPathSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = new int[,] { { 1, 2, 3 }, { 2, 3, 4 }, { 2, 3, 4 } };
            grid = new int[,] { { 1, 2, 5 }, { 3, 2, 1 } };
            int ans = MinPathSum(grid);
            Console.WriteLine(ans);
            IList<IList<int>> triangle = new List<IList<int>>() {
                new List<int>() { 1 },
                new List<int>() { 1, 2 },
                new List<int>() { 1, 2, 3 } };
            int triAnswer = MinimumTotal(triangle);
            Console.WriteLine(triAnswer);
            Console.ReadLine();
        }

        static int MinPathSum(int[,] grid)
        {
            int width = grid.GetLength(1) - 1;
            int height = grid.GetLength(0) - 1;
            int y = height;
            int x = width;
            int diagonalY = y;
            int diagonalX = x;
            while (true)
            {
                if (x + 1 > width && y + 1 > height)
                { }
                else if (x + 1 > width)
                    grid[y, x] += grid[y + 1, x];
                else if (y + 1 > height)
                    grid[y, x] += grid[y, x + 1];
                else
                {
                    grid[y, x] += Math.Min(grid[y + 1, x], grid[y, x + 1]);
                }
                y++; x--;
                if (y > height || x < 0)
                {
                    diagonalY--;
                    if (diagonalY < 0)
                    {
                        diagonalY = 0;
                        diagonalX--;
                        if (diagonalX < 0)
                        {
                            return grid[0, 0];
                        }
                    }
                    y = diagonalY;
                    x = diagonalX;
                }
            }
        }
        static int MinimumTotal(IList<IList<int>> triangle)
        {
            int height = triangle.Count()-1;
            if (height == 0) return triangle[0][0];
            for(int i=1; i<height; ++i)
            {
                for(int j=0; j <= i; ++j)
                {
                    if (j == 0)
                        triangle[i][j] += triangle[i - 1][j];
                    else if (j == i)
                        triangle[i][j] += triangle[i - 1][j - 1];
                    else
                        triangle[i][j] += Math.Min(triangle[i - 1][j], triangle[i - 1][j - 1]);
                }
            }
            int answer = 0;
            for (int j = 0; j <= height; ++j)
            {
                if (j == 0)
                {
                    triangle[height][j] += triangle[height - 1][j];
                    answer = triangle[height][j];
                }
                else if (j == height)
                    triangle[height][j] += triangle[height - 1][j - 1];
                else
                    triangle[height][j] += Math.Min(triangle[height - 1][j], triangle[height - 1][j - 1]);
                answer = Math.Min(answer, triangle[height][j]);
            }
            return answer;
        }
    }
}
