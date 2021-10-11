using GameLogic.Dependencies;
using UnityEngine;

namespace Client.Dependencies
{
    public class DeltaTimeWrapper : IDeltaTime
    {
        public float Value => Time.deltaTime;
    }
}