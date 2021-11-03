using System.Threading.Tasks;

namespace GameLogic.Dependencies.View
{
    public interface IViewLoader
    {
        Task<T> InstantiateAsync<T>(string key) where T : IView;
    }
}