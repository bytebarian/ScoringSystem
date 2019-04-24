using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoringSystem
{
    public class ScoreDeterminant
    {
        private readonly ScoreConfiguration _config;
        private readonly int _factorsCount;
        private readonly List<string> _scoringProperties;
        private readonly List<byte> _scoringWeights;

        public ScoreDeterminant(ScoreConfiguration configuration)
        {
            _config = configuration;
            _factorsCount = configuration.Count;

            _scoringProperties = _config.GetKeys();
            _scoringWeights = _config.GetWeights();
        }

        public List<ScoreItem> GetScoring(List<object> items)
        {
            throw new NotImplementedException();
        }

        private int[] CountingSort(int[] array)
        {
            int[] sortedArray = new int[array.Length];

            // find smallest and largest value
            int minVal = array[0];
            int maxVal = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minVal) minVal = array[i];
                else if (array[i] > maxVal) maxVal = array[i];
            }

            // init array of frequencies
            int[] counts = new int[maxVal - minVal + 1];

            // init the frequencies
            for (int i = 0; i < array.Length; i++)
            {
                counts[array[i] - minVal]++;
            }

            // recalculate
            counts[0]--;
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] = counts[i] + counts[i - 1];
            }

            // Sort the array
            for (int i = array.Length - 1; i >= 0; i--)
            {
                sortedArray[counts[array[i] - minVal]--] = array[i];
            }

            return sortedArray;
        }
    }
}
