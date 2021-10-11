using GameLogic.Dependencies.View;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Client.Dependencies.Addressable
{
    public class DefaultView : IView
    {
        private readonly GameObject _gameObject;
        public DefaultView(GameObject gameObject) => _gameObject = gameObject;

        public void Destroy() => Addressables.ReleaseInstance(_gameObject);
    }
}