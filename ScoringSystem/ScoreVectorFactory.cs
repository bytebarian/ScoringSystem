using System.Numerics;

namespace ScoringSystem
{
    public static class ScoreVectorFactory
    {
        public static ScoreVector GetNewScoreVector(ushort[] values)
        {
            return Vector.IsHardwareAccelerated ? (ScoreVector)new ScoreVectorSIMD(values) : new ScoreVectorNoSIMD(values);
        }
    }
}
