using GoldenRaspberry.Domain.Entities;
using GoldenRaspberry.Domain.Models;
using GoldenRaspberry.Infrastructure.Context;
using GoldenRaspberry.Infrastructure.Interfaces;

namespace GoldenRaspberry.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddMovies(IEnumerable<Movie> movies)
        {
            _context.Movies.AddRange(movies);
            _context.SaveChanges();
        }

        public IEnumerable<ProducerInterval> GetProducerIntervals()
        {
            var winners = _context.Movies.Where(m => m.IsWinner).ToList();

            var producerIntervals = new List<ProducerInterval>();

            // Obter uma lista de produtores únicos com seus respectivos anos de vitória
            return winners
                .SelectMany(m => m.Producers.Replace("and", ",").Split(",").Select(p => new { Producer = p.Trim(), Year = m.Year })) // Divide produtores
                .GroupBy(p => p.Producer) // Agrupa por produtor
                .SelectMany(g =>
                {
                    var orderedYears = g.OrderBy(m => m.Year).Select(m => m.Year).ToList();
                    return orderedYears
                        .Zip(orderedYears.Skip(1), (prev, next) => new ProducerInterval
                        {
                            Producer = g.Key,
                            Interval = next - prev,
                            PreviousWin = prev,
                            FollowingWin = next
                        });
                })
                .ToList();
        }

        public ProducerInterval GetMaxInterval() =>
            GetProducerIntervals().OrderByDescending(i => i.Interval).FirstOrDefault();

        public ProducerInterval GetMinInterval() =>
            GetProducerIntervals().OrderBy(i => i.Interval).FirstOrDefault();

    }
}
