using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ScoringSystem
{
    public class SynchronousScoreSIMDDeterminantt : ScoreDeterminant
    {
        public SynchronousScoreSIMDDeterminantt(ScoreConfiguration configuration) : base(configuration) { }

        public override void GetScoring(List<ScoreItem> items)
        {
            GetMinMaxVector(items);
        }

        private void GetMinMaxVector(List<ScoreItem> items)
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
    }
}
