namespace GameLogic.Descriptions.Variants
{
    public class ScoreDescription : ViewDescription
    {
        public readonly int Score;

        public ScoreDescription(string viewKey, int score) : base(viewKey)
        {
            Score = score;
        }
    }
}