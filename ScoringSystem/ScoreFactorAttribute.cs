using System;

namespace ScoringSystem
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ScoreFactorAttribute : Attribute
    {
        public string Name { get; private set; }

        public ScoreFactorAttribute(string name)
        {
            Name = name;
        }
    }
}
