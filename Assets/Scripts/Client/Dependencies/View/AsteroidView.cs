﻿using Client.Dependencies.Addressable;
using Client.Dependencies.View.Components;
using GameLogic.Dependencies.View;
using GameLogic.Dependencies.View.Components;

namespace Client.Dependencies.View
{
    public class AsteroidView : BaseView, IAsteroidView
    {
        public ITransform Transform { get; private set; }
        private void Awake() => Transform = new TransformWrapper(transform);
    }
}