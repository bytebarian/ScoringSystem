namespace ScoringSystem
{
    public class ScoreVectorNoSIMD : ScoreVector
    {
        public ScoreVectorNoSIMD(ushort[] values)
        {
            this._values = values;
        }

        public static ScoreVectorNoSIMD operator +(ScoreVectorNoSIMD vleft, ScoreVectorNoSIMD vright)
        {
            var result = new ushort[vleft.Length];

            for (var i = 0; i < vleft.Length; ++i)
            {
                result[i] = (ushort)(vleft._values[i] + vright._values[i]);
            }

            return new ScoreVectorNoSIMD(result);
        }

        public static ScoreVectorNoSIMD operator -(ScoreVectorNoSIMD vleft, ScoreVectorNoSIMD vright)
        {
            var result = new ushort[vleft.Length];

            for (var i = 0; i < vleft.Length; ++i)
            {
                result[i] = (ushort)(vleft._values[i] - vright._values[i]);
            }

            return new ScoreVectorNoSIMD(result);
        }

        public static ScoreVectorNoSIMD operator *(ScoreVectorNoSIMD vleft, ScoreVectorNoSIMD vright)
        {
            var result = new ushort[vleft.Length];

            for (var i = 0; i < vleft.Length; ++i)
            {
                result[i] = (ushort)(vleft._values[i] * vright._values[i]);
            }

            return new ScoreVectorNoSIMD(result);
        }

        public static ScoreVectorNoSIMD operator /(ScoreVectorNoSIMD vleft, ScoreVectorNoSIMD vright)
        {
            var result = new ushort[vleft.Length];

            for (var i = 0; i < vleft.Length; ++i)
            {
                result[i] = (ushort)(vleft._values[i] / vright._values[i]);
            }

            return new ScoreVectorNoSIMD(result);
        }
    }
}
