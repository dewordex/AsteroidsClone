using CustomEcs;

namespace GameLogic.Dependencies.View
{
    public interface IView
    {
        EcsEntity EntityLink { get; set; }
        void Destroy();
    }
}