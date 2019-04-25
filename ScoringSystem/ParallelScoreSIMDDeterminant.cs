using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScoringSystem
{
    public class ParallelScoreSIMDDeterminant : SynchronousScoreSIMDDeterminant
    {
        public ParallelScoreSIMDDeterminant(ScoreConfiguration configuration) : base(configuration)
        {
        }

        public override void GetScoring(List<ScoreItem> items)
        {
            GetMinMaxVector(items);
            var minMaxDif = SubstractVectors(_vmax, _vmin);
            var proportions = DivideVectors(_vbase, minMaxDif);

            Parallel.ForEach(items, (item) =>
            {
                var unifiedFactors = Array.ConvertAll(MultiplyVectors(item.Factories, proportions), x => (short)x);
                var scoringVector = MultiplyVectors(unifiedFactors, _scoringWeights);
                item.Score = SumVector(scoringVector);
            });
        }
    }
}
