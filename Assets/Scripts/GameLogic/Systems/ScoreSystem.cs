using CustomEcs;
using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;

namespace GameLogic.Systems
{
    public class ScoreSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private Group<ScoreComponent, DeathComponent> _scoresFilter;
        private Group<GameScoreComponent> _gameScoreFilter;

        public void Init() => _world.NewEntity().Replace(new GameScoreComponent());

        public void Run()
        {
            if (_gameScoreFilter.IsEmpty == false)
            {
                foreach (var i in _scoresFilter)
                {
                    ref var scoreComponent = ref _scoresFilter.Get1(i);
                    ref var gameScoreComponent = ref _gameScoreFilter.Get1(0);

                    gameScoreComponent.Score += scoreComponent.AddingScore;
                }
            }
        }
    }
}