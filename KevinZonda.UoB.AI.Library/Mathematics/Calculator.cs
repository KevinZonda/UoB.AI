using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KevinZonda.UoB.AI.Library.Mathematics;
public static class Calculator
{
    public static int Factorial(int num)
    {
        int fact = 1;

        for (int i = 2; i <= num; i++)
        {
            fact *= i;
        }

        return fact;
    }

    public static int Ncr(int n, int r)
    {
        // nCr = n! / (r! * (n - r)!)
        return Factorial(n) /
            (Factorial(r) * Factorial(n - r));
    }

    #region Sum

    public static int Sum(int begin, int end, int[] numbers)
    {
        int sum = 0;

        for (int i = begin; i <= end; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }

    public static int Sum(int[] numbers)
    {
        int sum = 0;

        foreach (var n in numbers)
        {
            sum += n;
        }

        return sum;
    }

    public static double Sum(int begin, int end, double[] numbers)
    {
        double sum = 0;

        for (int i = begin; i <= end; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }

    public static double Sum(double[] numbers)
    {
        double sum = 0;

        foreach (var n in numbers)
        {
            sum += n;
        }

        return sum;
    }
    #endregion
}