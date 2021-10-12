﻿using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Dependencies.View.Components;
using Leopotam.Ecs;

namespace GameLogic.Systems
{
    public class MovementInDirectionSystem : IEcsRunSystem
    {
        private EcsFilter<MotionDirectionComponent, Component<ITransform>, VelocityComponent> _filter;
        private IDeltaTime _deltaTime;
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var motionDirectionComponent = ref _filter.Get1(i);
                ref var transform = ref _filter.Get2(i).Value;
                ref var velocityComponent = ref _filter.Get3(i);
                transform.Position += velocityComponent.InstantVelocity.Length() * motionDirectionComponent.Direction * _deltaTime.Value;
            }
        }
    }
}