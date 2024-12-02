using GoldenRaspberry.Application.DTOs;
using GoldenRaspberry.Application.Interfaces;
using GoldenRaspberry.Infrastructure.Interfaces;


namespace GoldenRaspberry.Application.Services
{
    public class MovieAppService : IMovieAppService
    {

        private readonly IMovieRepository _movieRepository;

        public MovieAppService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public ProducerMetricsResponse GetProducerMetrics()
        {
            return new ProducerMetricsResponse
            {
                Max = GetProducerWithMaxInterval(),
                Min = GetProducerWithMinInterval(),
            };
        }

        public ProducerIntervalResponse GetProducerWithMaxInterval()
        {
            var interval = _movieRepository.GetMaxInterval();
            return new ProducerIntervalResponse
            {
                Producer = interval.Producer,
                Interval = interval.Interval,
                PreviousWin = interval.PreviousWin,
                FollowingWin = interval.FollowingWin
            };
        }

        public ProducerIntervalResponse GetProducerWithMinInterval()
        {
            var interval = _movieRepository.GetMinInterval();
            return new ProducerIntervalResponse
            {
                Producer = interval.Producer,
                Interval = interval.Interval,
                PreviousWin = interval.PreviousWin,
                FollowingWin = interval.FollowingWin
            };
        }

    }  
}
