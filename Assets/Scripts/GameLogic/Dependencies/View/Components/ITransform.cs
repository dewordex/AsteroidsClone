﻿using System.Numerics;

namespace GameLogic.Dependencies.View.Components
{
    public interface ITransform
    {
        Vector2 Up { get; }
        Vector2 Position { get; set; }
        void Rotate(float angle);
    }
}