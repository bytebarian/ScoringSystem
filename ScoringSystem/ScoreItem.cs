namespace ScoringSystem
{
    public class ScoreItem
    {
        public int Score { get; private set; }
        public object Item { get; private set; }

        public ScoreItem(int score, object item)
        {
            Score = score;
            Item = item;
        }
    }
}
