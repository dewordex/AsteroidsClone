using CustomEcs.Groups;
using CustomEcs.Systems;
using GameLogic.Components;
using GameLogic.Dependencies.View;

namespace GameLogic.Systems
{
    public class UpdateRotationViewSystem : IEcsRunSystem
    {
        private Group<RotationComponent, ViewComponentRef<IMovableView>> _group;

        public void Run()
        {
            foreach (var i in _group)
            {
                ref var rotationComponent = ref _group.Get1(i);
                ref var viewComponent = ref _group.Get2(i);
                viewComponent.View.UpdateRotation(rotationComponent.RotationDirection);
            }
        }
    }
}