using CustomEcs;
using GameLogic.Dependencies.View;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Client.Dependencies.Addressable
{
    public abstract class BaseView : MonoBehaviour, IView 
    {
        public EcsEntity EntityLink { get; set; }
        public void Destroy() => Addressables.ReleaseInstance(gameObject);
    }
}