using System.Threading.Tasks;
using CustomEcs;
using GameLogic.Components;
using GameLogic.Dependencies.View;

namespace GameLogic.Factories
{
    public class BaseViewFactory : BaseFactory
    {
        private IViewLoader _viewLoader;

        public BaseViewFactory(EcsWorld world, IViewLoader viewLoader) : base(world) => _viewLoader = viewLoader;

        public async Task<T> CreateViewAsync<T>(string viewKey) where T : IView
        {
            var view = await _viewLoader.InstantiateAsync<T>(viewKey);
            view.EntityLink = Entity;
            Entity.Replace(new ViewComponentRef<IView>(view));
            Entity.Replace(new ViewComponentRef<T>(view));
            return view;
        }
    }
}