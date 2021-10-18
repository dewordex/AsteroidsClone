namespace GameLogic.Descriptions.Settings
{
    public class UfoSpawnSetting
    {
        public readonly (float Min, float Max) SpawnTimeRange;
        public UfoSpawnSetting((float Min, float Max) spawnTimeRange) => SpawnTimeRange = spawnTimeRange;
    }
}