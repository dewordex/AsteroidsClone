using System;

namespace GameLogic.Dependencies
{
    public interface IInput
    {
        float Forward { get; }
        float Rotation { get; }
        event Action BulletAttack;
    }
}