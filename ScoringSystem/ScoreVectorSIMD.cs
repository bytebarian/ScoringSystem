using System.Numerics;

namespace ScoringSystem
{
    public class ScoreVectorSIMD : ScoreVector
    {
        private static readonly int simdLenght = Vector<ushort>.Count;

        public ScoreVectorSIMD(ushort[] values)
        {
            this._values = values;
        }

        public static ScoreVectorSIMD operator +(ScoreVectorSIMD vleft, ScoreVectorSIMD vright)
        {
            var result = new ushort[vleft.Length];
            var i = 0;
            for(i = 0; i <= result.Length - simdLenght; i += simdLenght)
            {
                var va = new Vector<ushort>(vleft._values, i);
                var vb = new Vector<ushort>(vright._values, i);
                (va + vb).CopyTo(result, i);
            }

            for(; i < vleft.Length; ++i)
            {
                result[i] = (ushort)(vleft._values[i] + vright._values[i]);
            }

            return new ScoreVectorSIMD(result);
        }

        public static ScoreVectorSIMD operator -(ScoreVectorSIMD vleft, ScoreVectorSIMD vright)
        {
            var result = new ushort[vleft.Length];
            var i = 0;
            for (i = 0; i <= result.Length - simdLenght; i += simdLenght)
            {
                var va = new Vector<ushort>(vleft._values, i);
                var vb = new Vector<ushort>(vright._values, i);
                (va - vb).CopyTo(result, i);
            }

            for (; i < vleft.Length; ++i)
            {
                result[i] = (ushort)(vleft._values[i] - vright._values[i]);
            }

            return new ScoreVectorSIMD(result);
        }

        public static ScoreVectorSIMD operator *(ScoreVectorSIMD vleft, ScoreVectorSIMD vright)
        {
            var result = new ushort[vleft.Length];
            var i = 0;
            for (i = 0; i <= result.Length - simdLenght; i += simdLenght)
            {
                var va = new Vector<ushort>(vleft._values, i);
                var vb = new Vector<ushort>(vright._values, i);
                (va * vb).CopyTo(result, i);
            }

            for (; i < vleft.Length; ++i)
            {
                result[i] = (ushort)(vleft._values[i] * vright._values[i]);
            }

            return new ScoreVectorSIMD(result);
        }

        public static ScoreVectorSIMD operator /(ScoreVectorSIMD vleft, ScoreVectorSIMD vright)
        {
            var result = new ushort[vleft.Length];
            var i = 0;
            for (i = 0; i <= result.Length - simdLenght; i += simdLenght)
            {
                var va = new Vector<ushort>(vleft._values, i);
                var vb = new Vector<ushort>(vright._values, i);
                (va / vb).CopyTo(result, i);
            }

            for (; i < vleft.Length; ++i)
            {
                result[i] = (ushort)(vleft._values[i] / vright._values[i]);
            }

            return new ScoreVectorSIMD(result);
        }
    }
}
