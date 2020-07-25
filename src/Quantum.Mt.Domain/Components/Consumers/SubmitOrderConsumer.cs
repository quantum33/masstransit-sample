using System.Threading.Tasks;
using MassTransit;
using Quantum.Mt.Domain.Models;

namespace Quantum.Mt.Domain.Components.Consumers
{
    public class SubmitOrderConsumer : IConsumer<SubmitOrder>
    {
        public Task Consume(ConsumeContext<SubmitOrder> context) =>
            context.Message.CustomerNumber.Contains("TEST")
                ? RejectOrder(context)
                : AcceptOrder(context);

        private static Task AcceptOrder(ConsumeContext<SubmitOrder> context)
        {
            return context.RespondAsync(new OrderSubmissionAccepted
                {
                    Timestamp = InVar.Timestamp,
                    OrderId = context.Message.OrderId,
                    CustomerNumber = context.Message.CustomerNumber
                });
        }

        private static Task RejectOrder(ConsumeContext<SubmitOrder> context)
        {
            return context.RespondAsync(new OrderSubmissionRejected
            {
                OrderId = context.Message.OrderId,
                Timestamp = InVar.Timestamp,
                CustomerNumber = context.Message.CustomerNumber,
                Reason = "rejected by TEST"
            });
        }
    }
}