using GoldenRaspberry.Application.DTOs;

namespace GoldenRaspberry.Application.Interfaces
{
    public interface IMovieAppService
    {
        ProducerMetricsResponse GetProducerMetrics();
    }
}
