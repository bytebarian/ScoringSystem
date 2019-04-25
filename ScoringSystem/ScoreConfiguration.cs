using System.Collections.Generic;
using System.Linq;

namespace ScoringSystem
{
    public class ScoreConfiguration
    {
        private readonly Dictionary<string, short> _dict;

        public int Count
        {
            get
            {
                return _dict.Count();
            }
        }

        public ScoreConfiguration(List<ScoreConfigurationItem> items)
        {
            _dict = items.ToDictionary(x => x.Key, x => x.Weight);
        }

        public short GetWeight(string key)
        {
            if (!_dict.ContainsKey(key))
            {
                return 0;
            }

            return _dict[key];
        }

        public List<string> GetKeys()
        {
            return _dict.Keys.ToList();
        }

        public short[] GetWeights()
        {
            return _dict.Values.ToArray();
        }
    }
}
