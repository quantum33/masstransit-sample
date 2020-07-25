using System;

namespace Quantum.Mt.Domain.Models
{
    // public class SubmitOrder : ISubmitOrder
    // {
    //     public Guid OrderId { get; set; }
    //     
    //     public DateTime Timestamp { get; set; }
    //     
    //     public string CustomerNumber { get; set; }
    // }

    public abstract class SubmitOrder
    {
        public Guid OrderId { get; set; }
        
        public DateTime Timestamp { get; set; }
        
        public string CustomerNumber { get; set; }
    }
}