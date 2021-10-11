using System;
using GameLogic.Dependencies.View;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Client.Dependencies.Addressable
{
    public class AsyncOperationHandleWrapper<T> : IAsyncOperationHandle<T> where T : IView
    {
        private readonly AsyncOperationHandle<GameObject> _handle;

        public AsyncOperationHandleWrapper(AsyncOperationHandle<GameObject> asyncOperationHandle)
        {
            _handle = asyncOperationHandle;
            _handle.Completed += OnCompleted;
        }

        public event Action<IAsyncOperationHandle<T>> Completed = delegate { };

        public virtual T Result
        {
            get
            {
                var component = _handle.Result.GetComponent<T>();
                if (component == null) Debug.LogError($"[IResourcesLoader] Could not find component {typeof(T)}", _handle.Result);
                return component;
            }
        }

        public bool IsDone => _handle.IsDone;
        public float PercentComplete => _handle.PercentComplete;

        protected virtual void OnCompleted(AsyncOperationHandle<GameObject> handle)
        {
            _handle.Completed -= OnCompleted;
            Completed(this);
        }
    }

    public class AsyncOperationHandleWrapper : AsyncOperationHandleWrapper<IView>
    {
        private GameObject _gameObject;

        protected override void OnCompleted(AsyncOperationHandle<GameObject> handle)
        {
            _gameObject = handle.Result;
            base.OnCompleted(handle);
        }

        public override IView Result => new DefaultView(_gameObject);

        public AsyncOperationHandleWrapper(AsyncOperationHandle<GameObject> asyncOperationHandle) : base(asyncOperationHandle) { }
    }
}