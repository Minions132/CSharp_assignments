using System;

namespace ToeplitzMatrix{
    class Algorithm{
        static void Main(string[] args){
            int[,] matrix = new int[,] {
                {1, 2, 3, 4},
                {5, 1, 2, 3},
                {9, 5, 1, 2}
            };
            
            bool result = IsToeplitzMatrix(matrix);
            Console.WriteLine($"是否为托普利茨矩阵: {result}");
        }
        static bool IsToeplitzMatrix(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i,j] != matrix[i-1,j-1])
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }
    }
}
