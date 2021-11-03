namespace GameLogic.Descriptions.Variants
{
    public class AsteroidSpawnDescription
    {
        private int _asteroidsPerMinuteScale;
        private float _timeMaxDifficulty;
        private int _minAsteroidsPerMinute;

        public AsteroidSpawnDescription(int asteroidsPerMinuteScale, float timeMaxDifficulty, int minAsteroidsPerMinute)
        {
            _asteroidsPerMinuteScale = asteroidsPerMinuteScale;
            _timeMaxDifficulty = timeMaxDifficulty;
            _minAsteroidsPerMinute = minAsteroidsPerMinute;
        }

        public int GetMaxAsteroids(float time) => (int) (_asteroidsPerMinuteScale * (time / _timeMaxDifficulty) + _minAsteroidsPerMinute);
    }
}