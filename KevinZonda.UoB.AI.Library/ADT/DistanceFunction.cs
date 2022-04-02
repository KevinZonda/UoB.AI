﻿using KevinZonda.UoB.AI.Library.Data;

namespace KevinZonda.UoB.AI.Library.ADT
{
    internal abstract class DistanceFunction
    {
        public double CalculateDistance(Vector<double> vector1, Vector<double> vector2)
        {
            return CalculateDistance(vector1.Raw, vector2.Raw);
        }
        public abstract double CalculateDistance(double[] x, double[] y);
    }
}