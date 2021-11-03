namespace GameLogic.Descriptions.Variants
{
    public class ScoreDescription : ViewDescription
    {
        public readonly int Score;

        public ScoreDescription(string viewKey, float sizeX, float sizeY, int score) : base(viewKey, sizeX, sizeY)
        {
            Score = score;
        }
    }
}