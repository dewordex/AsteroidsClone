using GameLogic.Dependencies.Base;

namespace GameLogic.Dependencies
{
    public interface ICamera : IInjectableDependency
    {
        float OrthographicSize { get; } 
        float Aspect { get; } 
    }
}