using Client.Dependencies.Addressable;

namespace Client.Dependencies
{
    public class DependenciesContainer : BaseDependenciesContainer
    {
        protected override void SetupDependencies()
        {
            Add(new AddressableWrapper());
        }
    }
}