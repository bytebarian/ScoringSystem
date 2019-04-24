using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoringSystem
{
    public abstract class ScoreDeterminant
    {
        protected readonly ScoreConfiguration _config;
        protected readonly int _factorsCount;
        protected readonly List<string> _scoringProperties;
        protected readonly List<byte> _scoringWeights;
        protected float[] _vmax;
        protected float[] _vmin;


        public ScoreDeterminant(ScoreConfiguration configuration)
        {
            _config = configuration;
            _factorsCount = configuration.Count;

            _scoringProperties = _config.GetKeys();
            _scoringWeights = _config.GetWeights();

            _vmax = new float[_factorsCount];
            _vmin = new float[_factorsCount];

            for(var i = 0; i < _factorsCount; i++)
            {
                _vmax[i] = float.MinValue;
                _vmin[i] = float.MaxValue;
            }
        }

        public abstract void GetScoring(List<ScoreItem> items);
    }
}
