using System;
using System.Collections.Generic;
using System.Numerics;

namespace ScoringSystem
{
    public class SynchronousScoreSIMDDeterminant : ScoreDeterminant
    {
        public SynchronousScoreSIMDDeterminant(ScoreConfiguration configuration) : base(configuration) { }

        public override void GetScoring(List<ScoreItem> items)
        {
            GetMinMaxVector(items);
            var minMaxDif = SubstractVectors(_vmax, _vmin);
            var proportions = DivideVectors(_vbase, minMaxDif);

            foreach(var item in items)
            {
                var unifiedFactors = Array.ConvertAll(MultiplyVectors(item.Factories, proportions), x => (short)x);
                var scoringVector = MultiplyVectors(unifiedFactors, _scoringWeights);
                item.Score = SumVector(scoringVector);
            }
        }

        protected void GetMinMaxVector(List<ScoreItem> items)
        {
            var simdLenght = Vector<float>.Count;

            foreach (var item in items)
            {
                int i;
                for (i = 0; i <= _factorsCount - simdLenght; i += simdLenght)
                {
                    var vtmax = new Vector<float>(_vmax, i);
                    var vtmin = new Vector<float>(_vmin, i);
                    var vnext = new Vector<float>(item.Factories, i);

                    Vector.Max(vtmax, vnext).CopyTo(_vmax, i);
                    Vector.Min(vtmin, vnext).CopyTo(_vmin, i);
                }

                for (; i < _factorsCount; ++i)
                {
                    _vmax[i] = Math.Max(_vmax[i], item.Factories[i]);
                    _vmin[i] = Math.Min(_vmin[i], item.Factories[i]);
                }
            }
        }

        protected float[] AddVectors(float[] aleft, float[] aright)
        {
            var simdLenght = Vector<float>.Count;

            var result = new float[aleft.Length];
            var i = 0;

            for (i = 0; i <= result.Length - simdLenght; i += simdLenght)
            {
                var va = new Vector<float>(aleft, i);
                var vb = new Vector<float>(aright, i);
                (va + vb).CopyTo(result, i);
            }

            for (; i < aleft.Length; ++i)
            {
                result[i] = (float)(aleft[i] + aright[i]);
            }

            return result;
        }

        protected float[] SubstractVectors(float[] aleft, float[] aright)
        {
            var simdLenght = Vector<float>.Count;

            var result = new float[aleft.Length];
            var i = 0;

            for (i = 0; i <= result.Length - simdLenght; i += simdLenght)
            {
                var va = new Vector<float>(aleft, i);
                var vb = new Vector<float>(aright, i);
                (va - vb).CopyTo(result, i);
            }

            for (; i < aleft.Length; ++i)
            {
                result[i] = (float)(aleft[i] - aright[i]);
            }

            return result;
        }

        protected float[] MultiplyVectors(float[] aleft, float[] aright)
        {
            var simdLenght = Vector<float>.Count;

            var result = new float[aleft.Length];
            var i = 0;

            for (i = 0; i <= result.Length - simdLenght; i += simdLenght)
            {
                var va = new Vector<float>(aleft, i);
                var vb = new Vector<float>(aright, i);
                (va * vb).CopyTo(result, i);
            }

            for (; i < aleft.Length; ++i)
            {
                result[i] = (float)(aleft[i] * aright[i]);
            }

            return result;
        }

        protected float[] DivideVectors(float[] aleft, float[] aright)
        {
            var simdLenght = Vector<float>.Count;

            var result = new float[aleft.Length];
            var i = 0;

            for (i = 0; i <= result.Length - simdLenght; i += simdLenght)
            {
                var va = new Vector<float>(aleft, i);
                var vb = new Vector<float>(aright, i);
                (va / vb).CopyTo(result, i);
            }

            for (; i < aleft.Length; ++i)
            {
                result[i] = (float)(aleft[i] / aright[i]);
            }

            return result;
        }

        protected short[] AddVectors(short[] aleft, short[] aright)
        {
            var simdLenght = Vector<short>.Count;

            var result = new short[aleft.Length];
            var i = 0;

            for (i = 0; i <= result.Length - simdLenght; i += simdLenght)
            {
                var va = new Vector<short>(aleft, i);
                var vb = new Vector<short>(aright, i);
                (va + vb).CopyTo(result, i);
            }

            for (; i < aleft.Length; ++i)
            {
                result[i] = (short)(aleft[i] + aright[i]);
            }

            return result;
        }

        protected short[] SubstractVectors(short[] aleft, short[] aright)
        {
            var simdLenght = Vector<short>.Count;

            var result = new short[aleft.Length];
            var i = 0;

            for (i = 0; i <= result.Length - simdLenght; i += simdLenght)
            {
                var va = new Vector<short>(aleft, i);
                var vb = new Vector<short>(aright, i);
                (va - vb).CopyTo(result, i);
            }

            for (; i < aleft.Length; ++i)
            {
                result[i] = (short)(aleft[i] - aright[i]);
            }

            return result;
        }

        protected short[] MultiplyVectors(short[] aleft, short[] aright)
        {
            var simdLenght = Vector<short>.Count;

            var result = new short[aleft.Length];
            var i = 0;

            for (i = 0; i <= result.Length - simdLenght; i += simdLenght)
            {
                var va = new Vector<short>(aleft, i);
                var vb = new Vector<short>(aright, i);
                (va * vb).CopyTo(result, i);
            }

            for (; i < aleft.Length; ++i)
            {
                result[i] = (short)(aleft[i] * aright[i]);
            }

            return result;
        }

        protected short[] DivideVectors(short[] aleft, short[] aright)
        {
            var simdLenght = Vector<short>.Count;

            var result = new short[aleft.Length];
            var i = 0;

            for (i = 0; i <= result.Length - simdLenght; i += simdLenght)
            {
                var va = new Vector<short>(aleft, i);
                var vb = new Vector<short>(aright, i);
                (va / vb).CopyTo(result, i);
            }

            for (; i < aleft.Length; ++i)
            {
                result[i] = (short)(aleft[i] / aright[i]);
            }

            return result;
        }
    }
}
