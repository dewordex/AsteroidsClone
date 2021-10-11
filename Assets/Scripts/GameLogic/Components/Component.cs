namespace GameLogic.Components
{
    public struct Component<T>
    {
        public T Value;
        public Component(T value) => Value = value;
    }
}