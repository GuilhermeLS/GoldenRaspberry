using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenRaspberry.Application.DTOs
{
    public class ProducerMetricsResponse
    {
        public ProducerIntervalResponse Max { get; set; }
        public ProducerIntervalResponse Min { get; set; }
    }
}
