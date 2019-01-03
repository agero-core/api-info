using System.Threading.Tasks;

namespace Agero.Core.ApiInfo
{
    /// <summary>Async API information composer</summary>
    public interface IAsyncApiInfoComposer
    {
        /// <summary>Returns API information</summary>
        Task<ApiInformation> GetAsync();
    }
}