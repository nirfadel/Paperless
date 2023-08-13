using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paperless.Core.Model
{
    public class BodyResponse
    {
        public Dictionary<int, decimal> GRAPH { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }

        public BodyResponse()
        {
            GRAPH = new Dictionary<int, decimal>();
        }

    }
}
