using System.Collections.Generic;

namespace GameLogic.Descriptions.Base
{
    public class DescriptionsContainer<T>
    {
        private Dictionary<string, T> _descriptions = new Dictionary<string, T>();
        protected void Add(string key, T description) => _descriptions.Add(key, description);
        public T Get(string key) => _descriptions[key];
    }
}