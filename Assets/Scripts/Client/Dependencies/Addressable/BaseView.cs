using GameLogic.Dependencies.View;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Client.Dependencies.Addressable
{
    public abstract class BaseView : MonoBehaviour, IView 
    {
        public void Destroy() => Addressables.ReleaseInstance(gameObject);
    }
}