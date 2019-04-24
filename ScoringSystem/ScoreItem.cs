namespace ScoringSystem
{
    public class ScoreItem
    {
        public int Score { get; set; }
        public object Item { get; private set; }
        public float[] Factories { get; private set; }

        public ScoreItem(object item, float[] factories)
        {
            Item = item;
            Factories = factories;
        }
    }
}
