namespace CustomEcs.EcsWorldHandlers
{
    internal class DeletedComponentsHandler
    {
        private EcsWordData _ecsWordData;
        public DeletedComponentsHandler(EcsWordData ecsWordData) => _ecsWordData = ecsWordData;
        public void ClearDeletedComponents()
        {
            foreach (var deletedComponentData in _ecsWordData.ComponentsMarkedForDeletion)
            {
                _ecsWordData.GetComponentsPools()[deletedComponentData.ComponentTypeIndex].Delete(deletedComponentData.EntityId);
                RemoveIdentifierForEntityComponent(deletedComponentData.EntityId, deletedComponentData.ComponentTypeIndex);
                if (_ecsWordData.GetEntitiesComponents()[deletedComponentData.EntityId].Count == 0) _ecsWordData.EntityIdGenerator.AddFreeId(deletedComponentData.EntityId);
            }

            _ecsWordData.ComponentsMarkedForDeletion.Clear();
        }

        private void RemoveIdentifierForEntityComponent(uint id, int componentTypeIndex) => _ecsWordData.GetEntitiesComponents()[id].Remove(componentTypeIndex);
    }
}