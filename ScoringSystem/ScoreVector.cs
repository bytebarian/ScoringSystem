using System;

namespace ScoringSystem
{
    public struct ScoreVector
    {
        private ushort[] _values;

        public int Length
        {
            get
            {
                return _values.Length;
            }
        }

        public ScoreVector(ushort[] values)
        {
            this._values = values;
        }

        public ScoreVector Max(ScoreVector max)
        {
            var result = new ushort[Length];

            for (var i = 0; i < Length; ++i)
            {
                result[i] = Math.Max(_values[i], max._values[i]);
            }

            return new ScoreVector(result);
        }

        public ScoreVector Min(ScoreVector min)
        {
            var result = new ushort[Length];

            for (var i = 0; i < Length; ++i)
            {
                result[i] = Math.Min(_values[i], min._values[i]);
            }

            return new ScoreVector(result);
        }

        public static ScoreVector operator +(ScoreVector vleft, ScoreVector vright)
        {
            var result = new ushort[vleft.Length];

            for (var i = 0; i < vleft.Length; ++i)
            {
                result[i] = (ushort)(vleft._values[i] + vright._values[i]);
            }

            return new ScoreVector(result);
        }

        public static ScoreVector operator -(ScoreVector vleft, ScoreVector vright)
        {
            var result = new ushort[vleft.Length];

            for (var i = 0; i < vleft.Length; ++i)
            {
                result[i] = (ushort)(vleft._values[i] - vright._values[i]);
            }

            return new ScoreVector(result);
        }

        public static ScoreVector operator *(ScoreVector vleft, ScoreVector vright)
        {
            var result = new ushort[vleft.Length];

            for (var i = 0; i < vleft.Length; ++i)
            {
                result[i] = (ushort)(vleft._values[i] * vright._values[i]);
            }

            return new ScoreVector(result);
        }

        public static ScoreVector operator /(ScoreVector vleft, ScoreVector vright)
        {
            var result = new ushort[vleft.Length];

            for (var i = 0; i < vleft.Length; ++i)
            {
                result[i] = (ushort)(vleft._values[i] / vright._values[i]);
            }

            return new ScoreVector(result);
        }
    }
}
