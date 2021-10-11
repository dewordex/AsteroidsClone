namespace GameLogic.Dependencies.View
{
    public interface IViewLoader
    {
        IAsyncOperationHandle<T> InstantiateAsync<T>(string key) where T : IView;
        IAsyncOperationHandle<IView> InstantiateAsync(string key);
    }
}