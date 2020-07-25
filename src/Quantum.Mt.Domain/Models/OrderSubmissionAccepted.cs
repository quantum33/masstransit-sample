using System;

namespace Quantum.Mt.Domain.Models
{
    public class OrderSubmissionAccepted
    {
        public Guid OrderId { get; set; }
        public DateTime Timestamp { get; set; }
        public string CustomerNumber { get; set; }
    }
}