using System;
using System.Globalization;

class Program
{
    
    static double Function(double x, double a, double b, double n)
    {
        return Math.Pow(a * x + b, n);
    }

   
    static double Integrate(double a, double b, double n, double lower, double upper, double eps)
    {
        int N = 10;  
        double prevIntegral = 0.0, integral = 0.0;

        do
        {
            double h = (upper - lower) / N; 
            integral = 0.0;

            for (int i = 0; i < N; i++)
            {
                double xMid = lower + (i + 0.5) * h; 
                integral += Function(xMid, a, b, n) * h; 
            }

            if (Math.Abs(integral - prevIntegral) < eps) break; 
            prevIntegral = integral;
            N *= 2; 
        } while (true);

        return integral;
    }

    static void Main()
    {
        
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

       
        Console.Write("Введите коэффициенты a, b, n: ");
        string[] input = Console.ReadLine().Split();
        double a = double.Parse(input[0]);
        double b = double.Parse(input[1]);
        double n = double.Parse(input[2]);

        Console.Write("Введите пределы интегрирования (нижний, верхний): ");
        input = Console.ReadLine().Split();
        double lower = double.Parse(input[0]);
        double upper = double.Parse(input[1]);

        Console.Write("Введите точность вычисления eps: ");
        double eps = double.Parse(Console.ReadLine());

       
        double result = Integrate(a, b, n, lower, upper, eps);

        
        Console.WriteLine($"Приближённое значение интеграла: {result:F6}");
        Console.ReadKey();
    }
}
