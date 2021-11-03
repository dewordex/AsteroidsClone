using System.Threading.Tasks;
using GameLogic.Dependencies.View;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Client.Dependencies.Addressable
{
    public class AddressableWrapper : IViewLoader
    {
        public async Task<T> InstantiateAsync<T>(string key) where T : IView
        {
            var gameObject = await Addressables.InstantiateAsync(key).Task;
            var component = gameObject.GetComponent<T>();
            if (component == null) Debug.LogError($"[IResourcesLoader] Could not find component {typeof(T)}", gameObject);
            return component;
        }
    }
}