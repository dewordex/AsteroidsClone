using System.Numerics;

namespace GameLogic.Descriptions.Variants
{
    public class ViewDescription
    {
        public readonly string ViewKey;
        public readonly Vector2 Size;
        public ViewDescription(string viewKey, float sizeX, float sizeY)
        {
            ViewKey = viewKey;
            Size = new Vector2(sizeX, sizeY);
        }
    }
}