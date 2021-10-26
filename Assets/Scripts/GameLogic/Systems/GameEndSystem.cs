using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies.View;

namespace GameLogic.Systems
{
    public class GameEndSystem : IEcsRunSystem
    {
        private Group<DeathComponent, PlayerComponent> _playerDeathFilter;
        private Group<GameScoreComponent> _gameScoreFilter;
        private IGameEndView _gameEndView;

        public void Run()
        {
            if (_playerDeathFilter.IsEmpty == false && _gameScoreFilter.IsEmpty == false)
            {
                ref var gameScoreComponent = ref _gameScoreFilter.Get1(0);
                _gameEndView.Show(gameScoreComponent.Score);
            }
        }
    }
}