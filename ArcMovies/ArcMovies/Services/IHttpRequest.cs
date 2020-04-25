using System.Threading.Tasks;

namespace ArcMovies.Services
{
    public interface IHttpRequest
    {
        Task<TResult> GetAsync<TResult>(string uri);
    }
}
