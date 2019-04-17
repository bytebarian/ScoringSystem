using System;
using System.Collections.Generic;

namespace ScoringSystem
{
    public class ScoreDeterminant
    {
        private readonly ScoreConfiguration _config;
        private readonly int _factorsCount;
        private readonly List<string> _scoringProperties;
        private readonly List<byte> _scoringFactors;

        public ScoreDeterminant(ScoreConfiguration configuration)
        {
            _config = configuration;
            _factorsCount = configuration.Count;

            _scoringProperties = _config.GetKeys();
            _scoringFactors = _config.GetWeights();
        }

        public List<ScoreItem> GetScoring(List<object> items)
        {
            throw new NotImplementedException();
        }
    }
}
