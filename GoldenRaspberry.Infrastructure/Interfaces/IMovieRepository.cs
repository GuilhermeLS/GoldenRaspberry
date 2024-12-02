using GoldenRaspberry.Domain.Entities;
using GoldenRaspberry.Domain.Models;


namespace GoldenRaspberry.Infrastructure.Interfaces
{
    public interface IMovieRepository
    {
        void AddMovies(IEnumerable<Movie> movies);

        IEnumerable<ProducerInterval> GetProducerIntervals();

        ProducerInterval GetMaxInterval();

        ProducerInterval GetMinInterval();
    }
}
