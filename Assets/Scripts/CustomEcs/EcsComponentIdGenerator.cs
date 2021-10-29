using System;
using System.Collections.Generic;

namespace CustomEcs
{
    internal class EcsComponentIdGenerator
    {
        private Dictionary<Type, int> _ids = new Dictionary<Type, int>();
        private int _componentTypesCount;

        public int GenerateId<T>()
        {
            _ids.Add(typeof(T), _componentTypesCount);
            return _componentTypesCount++;
        }

        public bool IsIdGenerated<T>() => _ids.ContainsKey(typeof(T));

        public int GetId<T>() => _ids[typeof(T)];
    }
}