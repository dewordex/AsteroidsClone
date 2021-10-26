using Client.Dependencies;
using GameLogic;
using GameLogic.Descriptions.GameDescriptions;
using UnityEngine;

namespace Client
{
    [RequireComponent(typeof(DependenciesContainer))]
    public class GameStaterMono : MonoBehaviour
    {
        private DependenciesContainer _dependenciesContainer;
        private GameStarter _gameStarter;

        private void Awake()
        {
            _gameStarter = new GameStarter();
            _dependenciesContainer = GetComponent<DependenciesContainer>();
        }

        private void Start()
        {
            var (_, ecsSystemsList) = _gameStarter.Init(new ReleaseGameDescription());
            _dependenciesContainer.InjectDependencies(ecsSystemsList);
            _gameStarter.Start();
        }

        private void Update() => _gameStarter.UpdateLoop();
        private void LateUpdate() => _gameStarter.LateUpdateLoop();
        private void FixedUpdate() => _gameStarter.FixedUpdateLoop();
    }
}