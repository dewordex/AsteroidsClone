using System.Collections.Generic;
using GameLogic.Descriptions.GameDescriptions;
using Leopotam.Ecs;

namespace GameLogic
{
    public class GameStarter
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        private EcsSystems _fixedSystems;
        private EcsSystems _lateSystems;

        public (EcsWorld, List<EcsSystems>) Init(GameDescription gameDescription)
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world, "UpdateSystems");
            _fixedSystems = new EcsSystems(_world, "FixedUpdateSystems");
            _lateSystems = new EcsSystems(_world, "LateUpdateSystems");
            
            var ecsSystemsList = new List<EcsSystems>() { _systems, _fixedSystems, _lateSystems };

            gameDescription.SetupAll(ecsSystemsList);
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

        public void Destroy()
        {
            DestroySystem(ref _systems);
            DestroySystem(ref _lateSystems);
            DestroySystem(ref _fixedSystems);

            _world.Destroy();
            _world = null;
        }

        private void DestroySystem(ref EcsSystems systems)
        {
            systems.Destroy();
            systems = null;
        }
    }
}