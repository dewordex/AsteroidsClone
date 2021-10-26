using System.Collections.Generic;
using System.Linq;
using CustomEcs.Systems;
using GameLogic.Dependencies.Base;
using UnityEngine;

namespace Client.Dependencies
{
    public abstract class BaseDependenciesContainer : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _gameObjects;
        private List<object> _dependencies = new List<object>();

        public void InjectDependencies(List<EcsSystem> systems)
        {
            SetupDependencies();
            
            foreach (var component in _gameObjects.Select(go => go.GetComponents(typeof(IInjectableDependency))).SelectMany(components => components))
            {
                foreach (var system in systems)
                {
                    system.Inject(component);
                }
            }

            foreach (var dependency in _dependencies)
            {
                foreach (var system in systems)
                {
                    system.Inject(dependency);
                }
            }
        }

        protected void Add(object dependency) => _dependencies.Add(dependency);
        protected abstract void SetupDependencies();
    }
}