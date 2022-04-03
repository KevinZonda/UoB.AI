namespace KevinZonda.UoB.AI.Library.Mathematics.Operations
{
    public static class TupleExtra
    {
        public static (TypeX[], TypeY[]) Separate<TypeX, TypeY>(
            this (TypeX, TypeY)[] tuple)
        {
            var t = new TypeX[tuple.Length];
            var v = new TypeY[tuple.Length];
            for (int i = 0; i < tuple.Length; i++)
            {
                t[i] = tuple[i].Item1;
                v[i] = tuple[i].Item2;
            }
            return (t, v);
        }

        public static (TypeX, TypeY)[] Combine<TypeX, TypeY>(
            this (TypeX[], TypeY[]) t)
        {
            var x = t.Item1;
            var y = t.Item2;
            int len = Math.Min(x.Length, y.Length);
            var z = new (TypeX, TypeY)[len];
            for (int i = 0; i < len; i++)
            {
                z[i] = (x[i], y[i]);
            }
            return z;
        }
    }
}
