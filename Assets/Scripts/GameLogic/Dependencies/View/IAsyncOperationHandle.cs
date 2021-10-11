using System;

namespace GameLogic.Dependencies.View
{
    public interface IAsyncOperationHandle<T> where T : IView
    {
        event Action<IAsyncOperationHandle<T>> Completed;
        T Result { get; }
        bool IsDone { get; }
        float PercentComplete { get; }
    }
}