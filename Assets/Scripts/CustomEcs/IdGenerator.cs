using System.Collections.Generic;

namespace CustomEcs
{
    public class IdGenerator
    {
        private Stack<uint> _freeIds = new Stack<uint>();
        private uint _idsCount;

        public uint GetId()
        {
            if (_freeIds.Count == 0)
            {
                return _idsCount++;
            }

            return _freeIds.Pop();
        }

        public void AddFreeId(uint id)
        {
            if (_freeIds.Contains(id) == false)
                _freeIds.Push(id);
        }
    }
}