using GameLogic.Components;
using GameLogic.Dependencies.View;
using Leopotam.Ecs;

namespace GameLogic.Systems
{
    public class GameEndSystem : IEcsRunSystem
    {
        private EcsFilter<DeathComponent, PlayerComponent> _playerDeathFilter;
        private EcsFilter<GameScoreComponent> _gameScoreFilter;
        private IGameEndView _gameEndView;

        public void Run()
        {
            if (_playerDeathFilter.IsEmpty() == false && _gameScoreFilter.IsEmpty() == false)
            {
                ref var gameScoreComponent = ref _gameScoreFilter.Get1(0);
                _gameEndView.Show(gameScoreComponent.Score);
            }
        }
    }
}