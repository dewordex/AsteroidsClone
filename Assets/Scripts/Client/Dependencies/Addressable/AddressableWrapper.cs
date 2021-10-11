using GameLogic.Dependencies.View;
using UnityEngine.AddressableAssets;

namespace Client.Dependencies.Addressable
{
    public class AddressableWrapper : IViewLoader
    {
        public IAsyncOperationHandle<T> InstantiateAsync<T>(string key) where T : IView => new AsyncOperationHandleWrapper<T>(Addressables.InstantiateAsync(key));
        public IAsyncOperationHandle<IView> InstantiateAsync(string key) => new AsyncOperationHandleWrapper(Addressables.InstantiateAsync(key));
    }
}