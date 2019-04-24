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
            
        }

        private void GetMinMaxVector(List<ScoreItem> items)
        {

        }
    }
}
