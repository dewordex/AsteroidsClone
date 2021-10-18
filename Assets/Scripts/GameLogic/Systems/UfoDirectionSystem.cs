using System.Numerics;
using GameLogic.Components;
using GameLogic.Dependencies.View.Components;
using Leopotam.Ecs;

namespace GameLogic.Systems
{
    public class UfoDirectionSystem : IEcsRunSystem
    {
        private EcsFilter<MotionDirectionComponent, Component<ITransform>, UfoComponent> _ufoFilter;
        private EcsFilter<Component<ITransform>, PlayerComponent> _spaceshipFilter;

        public void Run()
        {
            if (_spaceshipFilter.IsEmpty() == false)
            {
                foreach (var i in _ufoFilter)
                {
                    ref var motionDirectionComponent = ref _ufoFilter.Get1(i);
                    ref var ufoTransform = ref _ufoFilter.Get2(i).Value;
                    var spaceshipTransform = _spaceshipFilter.Get1(0).Value;
                    motionDirectionComponent.Direction =  Vector2.Normalize(spaceshipTransform.Position - ufoTransform.Position);
                }
            }
        }
    }
}