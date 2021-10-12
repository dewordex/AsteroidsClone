using GameLogic.Dependencies.View;
using Leopotam.Ecs;
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