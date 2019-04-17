namespace ScoringSystem
{
    public abstract class ScoreVector
    {
        protected ushort[] _values;

        public int Length
        {
            get
            {
                return _values.Length;
            }
        }

        public int Sum()
        {
            var sum = 0;
            for (var i = 0; i < _values.Length; i++)
            {
                sum += _values[i];
            }
            return sum;
        }
    }
}
