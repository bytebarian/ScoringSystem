using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoringSystem
{
    public class SynchronousScoreDeterminant : ScoreDeterminant
    {
        public SynchronousScoreDeterminant(ScoreConfiguration configuration) : base(configuration) { }

        public override void GetScoring(List<ScoreItem> items)
        {
            GetMinMaxVector(items);
            var minMaxDif = SubstractVectors(_vmax, _vmin);
            var proportions = DivideVectors(_vbase, minMaxDif);

            foreach (var item in items)
            {
                var unifiedFactors = Array.ConvertAll(MultiplyVectors(item.Factories, proportions), x => (short)x);
                var scoringVector = MultiplyVectors(unifiedFactors, _scoringWeights);
                item.Score = SumVector(scoringVector);
            }
        }

        protected void GetMinMaxVector(List<ScoreItem> items)
        {
            foreach (var item in items)
            {
                for (var i = 0; i < _factorsCount; ++i)
                {
                    _vmax[i] = Math.Max(_vmax[i], item.Factories[i]);
                    _vmin[i] = Math.Min(_vmin[i], item.Factories[i]);
                }
            }
        }

        protected float[] AddVectors(float[] aleft, float[] aright)
        {
            var result = new float[aleft.Length];

            for (var i = 0; i < aleft.Length; ++i)
            {
                result[i] = aleft[i] + aright[i];
            }

            return result;
        }

        protected float[] SubstractVectors(float[] aleft, float[] aright)
        {
            var result = new float[aleft.Length];

            for (var i = 0; i < aleft.Length; ++i)
            {
                result[i] = aleft[i] - aright[i];
            }

            return result;
        }

        protected float[] MultiplyVectors(float[] aleft, float[] aright)
        {
            var result = new float[aleft.Length];

            for (var i = 0; i < aleft.Length; ++i)
            {
                result[i] = aleft[i] * aright[i];
            }

            return result;
        }

        protected float[] DivideVectors(float[] aleft, float[] aright)
        {
            var result = new float[aleft.Length];

            for (var i = 0; i < aleft.Length; ++i)
            {
                result[i] = aleft[i] / aright[i];
            }

            return result;
        }

        protected short[] AddVectors(short[] aleft, short[] aright)
        {
            var result = new short[aleft.Length];

            for (var i = 0; i < aleft.Length; ++i)
            {
                result[i] = (short)(aleft[i] + aright[i]);
            }

            return result;
        }

        protected short[] SubstractVectors(short[] aleft, short[] aright)
        {
            var result = new short[aleft.Length];

            for (var i = 0; i < aleft.Length; ++i)
            {
                result[i] = (short)(aleft[i] - aright[i]);
            }

            return result;
        }

        protected short[] MultiplyVectors(short[] aleft, short[] aright)
        {
            var result = new short[aleft.Length];

            for (var i = 0; i < aleft.Length; ++i)
            {
                result[i] = (short)(aleft[i] * aright[i]);
            }

            return result;
        }

        protected short[] DivideVectors(short[] aleft, short[] aright)
        {
            var result = new short[aleft.Length];

            for (var i = 0; i < aleft.Length; ++i)
            {
                result[i] = (short)(aleft[i] / aright[i]);
            }

            return result;
        }
    }
}
