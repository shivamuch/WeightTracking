using Domain.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class WeightHistoryResponse
    {
        public WeightHistory Value { get; set; }
        public List<string> ContentTypes { get; set; }
        public List<object> Formatters { get; set; }
        public int StatusCode { get; set; }
    }
}
