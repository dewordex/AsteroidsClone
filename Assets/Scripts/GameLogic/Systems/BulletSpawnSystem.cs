using System.Numerics;
using GameLogic.Components;
using GameLogic.Dependencies;
using GameLogic.Dependencies.View.Components;
using GameLogic.Descriptions;
using GameLogic.Descriptions.Components;
using GameLogic.Descriptions.Entity;
using GameLogic.Descriptions.Ids;
using Leopotam.Ecs;

namespace GameLogic.Systems
{
    public class BulletSpawnSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private IEntityFactory _entityFactory;
        private IInput _input;
        private EntitiesDescriptionsGenerator _entitiesDescriptionsGenerator;
        private EcsFilter<Component<ITransform>, PlayerComponent> _filter;
        private EcsFilter<ShotDelayComponent, BulletComponent> _shootDelayFilter;

        [EcsIgnoreInject] private float _shotDelay;

        public void Init()
        {
            _input.BulletAttack += OnBulletAttack;
            _shotDelay = ((WeaponDescription)_entitiesDescriptionsGenerator.ComponentsContainers[DescriptionIds.BulletWeapon]).ShotDelay;
            _world.NewEntity().Replace(new ShotDelayComponent() { Delay = 0 }).Replace(new BulletComponent());
        }

        private void OnBulletAttack()
        {
            if (_shootDelayFilter.IsEmpty() == false && _filter.IsEmpty() == false && _shootDelayFilter.Get1(0).Delay <= 0)
            {
                _shootDelayFilter.Get1(0).Delay = _shotDelay;
                var transform = _filter.Get1(0).Value;
                var bulletComponentsContainer = new BulletComponentsContainer();
                _entityFactory.StartCreate(bulletComponentsContainer, DescriptionIds.BulletDefault).Completed += handle =>
                {
                    bulletComponentsContainer.View.Transform.Position = transform.Position + transform.Up * 2;
                    bulletComponentsContainer.View.Transform.Rotation = transform.Rotation;
                    bulletComponentsContainer.EcsEntity.Get<MotionDirectionComponent>().Direction = Vector2.Normalize(transform.Position + transform.Up - transform.Position);
                };
            }
        }
    }
}

