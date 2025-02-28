using System;

namespace Array_Algorithms{
    class Algorithms{
        static void Main(string[] args){
            int[] numbers = { 5, 2, 8, 1, 9, 3, 7, 4, 6 };
            
            int max = numbers[0];
            int min = numbers[0];
            int sum = 0;
            
            for (int i = 0; i < numbers.Length; i++) {
                if (numbers[i] > max) max = numbers[i];
                if (numbers[i] < min) min = numbers[i];
                sum += numbers[i];
            }
            
            double average = (double)sum / numbers.Length;

            Console.WriteLine($"最大值: {max}");
            Console.WriteLine($"最小值: {min}");
            Console.WriteLine($"平均值: {average}");
            Console.WriteLine($"总和: {sum}");
        }
    }
}