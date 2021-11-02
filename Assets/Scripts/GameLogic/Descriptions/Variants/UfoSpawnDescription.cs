namespace GameLogic.Descriptions.Variants
{
    public class UfoSpawnDescription
    {
        public readonly (float Min, float Max) SpawnTimeRange;
        public UfoSpawnDescription(float spawnTimeMin, float spawnTimeMax) => SpawnTimeRange = (spawnTimeMin, spawnTimeMax);
    }
}