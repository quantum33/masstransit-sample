using System;

namespace Quantum.Mt.Domain.Models
{
    public class OrderSubmissionRejected
    {
        public Guid OrderId { get; set; }
        public DateTime Timestamp { get; set; }
        public string CustomerNumber { get; set; }
        public string Reason { get; set; }
    }
}