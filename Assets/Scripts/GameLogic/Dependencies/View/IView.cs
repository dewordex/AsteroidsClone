using Leopotam.Ecs;

namespace GameLogic.Dependencies.View
{
    public interface IView
    {
        EcsEntity EntityLink { get; set; }
        void Destroy();
    }
}