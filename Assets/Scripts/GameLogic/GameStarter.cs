using System.Collections.Generic;
using CustomEcs;
using CustomEcs.Systems;
using GameLogic.Descriptions.GameDescriptions;

namespace GameLogic
{
    public class GameStarter
    {
        private EcsWorld _world;
        private EcsSystem _systems;
        private EcsSystem _fixedSystems;
        private EcsSystem _lateSystems;

        public (EcsWorld, List<EcsSystem>) Init(GameDescription gameDescription)
        {
            _world = new EcsWorld();
            _systems = new EcsSystem(_world);
            _fixedSystems = new EcsSystem(_world);
            _lateSystems = new EcsSystem(_world);

            var ecsSystemsList = new List<EcsSystem>() { _systems, _fixedSystems, _lateSystems };

            gameDescription.SetupAll(ecsSystemsList, _world);
            gameDescription.SetupSystems(_systems);
            gameDescription.SetupLateSystems(_lateSystems);
            gameDescription.SetupFixedSystems(_fixedSystems);

            return (_world, ecsSystemsList);
        }

        public void Start()
        {
            _systems.Init();
            _fixedSystems.Init();
            _lateSystems.Init();
        }

        public void UpdateLoop() => _systems.Run();
        public void FixedUpdateLoop() => _fixedSystems.Run();
        public void LateUpdateLoop() => _lateSystems.Run();
    }
}