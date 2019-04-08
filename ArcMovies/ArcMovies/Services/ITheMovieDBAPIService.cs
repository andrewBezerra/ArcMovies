using ArcMovies.Models;
using System.Threading.Tasks;

namespace ArcMovies.Services
{
    public interface ITheMovieDBAPIService
    {
        Task<SearchResponse<Movie>> GetUpcomingMoviesAsync(int pageNumber = 1, string language = "en");
        Task<Movie> FindByIdAsync(int movieId, string language = "en");
    }
}
