using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoringSystem
{
    public class SynchronousScoreDeterminant : ScoreDeterminant
    {
        public SynchronousScoreDeterminant(ScoreConfiguration configuration) : base(configuration) { }

        public override List<ScoreItem> GetScoring(List<object> items, ScoreVector maxFactorVector, ScoreVector minFactorVector)
        {
            foreach(var item in items)
            {
                var scoreFactors = item.GetType().GetProperties()
                    .Where(p => Attribute.IsDefined(p, typeof(ScoreFactorAttribute)) && p.GetValue(item).IsNumber())
                    .Select(pi => (decimal)pi.GetValue(item)).ToArray();

            }

            throw new System.NotImplementedException();
        }
    }
}
