using System.Numerics;

namespace GameLogic.Components
{
    public struct TeleportationSizeComponent
    {
        public Vector2 Size;

        public TeleportationSizeComponent(Vector2 size) => Size = size;
    }
}