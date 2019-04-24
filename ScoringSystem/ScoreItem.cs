namespace ScoringSystem
{
    public class ScoreItem
    {
        public int Score { get; set; }
        public object Item { get; private set; }
        public ScoreVector Factories { get; private set; }

        public ScoreItem(object item, ScoreVector factories)
        {
            Item = item;
            Factories = factories;
        }
    }
}
