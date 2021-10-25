using System;
using System.Collections.Generic;

namespace CustomEcs.Systems
{
    public class EcsSystem
    {
        private EcsWorld _world;
        private Dictionary<Type, object> _dependencies = new Dictionary<Type, object>();
        private List<IEcsSystem> _allSystems = new List<IEcsSystem>();
        private List<IEcsRunSystem> _runSystems = new List<IEcsRunSystem>();
        private bool _initialized;

        public EcsSystem(EcsWorld world) => _world = world;

        public void Add(IEcsSystem system)
        {
            if (system == null)
            {
                throw new Exception("System is null.");
            }

            _allSystems.Add(system);
            if (system is IEcsRunSystem runSystem)
            {
                _runSystems.Add(runSystem);
            }
        }

        public void Init() => InitSystems();

        private void InitSystems()
        {
            var dependenciesInstaller = new DependenciesInstaller();
            foreach (var system in _allSystems)
            {
                dependenciesInstaller.InstallDependencies(system, _world, _dependencies);

                if (system is IInitSystem initSystem)
                {
                    initSystem.Init();
                }
            }

            _initialized = true;
        }

        public void Inject(object dependency)
        {
            if (_initialized) throw new Exception("Cant inject after initialization.");
            if (dependency == null) throw new Exception("Cant inject null instance.");
            _dependencies.Add(dependency.GetType(), dependency);
        }

        public void Run()
        {
            if (_initialized == false) throw new Exception("EcsSystems should be initialized before.");

            foreach (var runSystem in _runSystems)
            {
                runSystem.Run();
            }
        }
    }
}