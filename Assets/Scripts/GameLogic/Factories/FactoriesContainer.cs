using CustomEcs;
using GameLogic.Dependencies.View;

namespace GameLogic.Factories
{
    public class FactoriesContainer
    {
        private EcsWorld _world;
        private IViewLoader _viewLoader;

        public FactoriesContainer(EcsWorld world, IViewLoader viewLoader)
        {
            _world = world;
            _viewLoader = viewLoader;
        }

        public SpaceshipFactory GetSpaceshipFactory() => new SpaceshipFactory(_world, _viewLoader);
        public AsteroidFactory GetAsteroidFactory() => new AsteroidFactory(_world, _viewLoader);
        public BulletFactory GetBulletFactory() => new BulletFactory(_world, _viewLoader);
        public MeteorFactory GetMeteorFactory() => new MeteorFactory(_world, _viewLoader);
        public UfoFactory GetUfoFactory() => new UfoFactory(_world, _viewLoader);
        public BulletWeaponFactory GetBulletWeaponFactory() => new BulletWeaponFactory(_world);
        public LaserWeaponFactory GetLaserWeaponFactory() => new LaserWeaponFactory(_world);
        public BaseViewFactory GetBaseViewFactoryFactory() => new BaseViewFactory(_world, _viewLoader);
    }
}