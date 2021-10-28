namespace CustomEcs.Groups
{
    public struct Enumerator
    {
        private int _count;
        private int _idx;

        internal Enumerator(IGroup group)
        {
            _count = group.GetEntitiesCount();
            _idx = -1;
        }

        public int Current => _idx;
        public bool MoveNext() => ++_idx < _count;
    }
}